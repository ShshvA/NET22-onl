using EFPractice.DatabaseAccess.Interfaces;
using EFPractice.DatabaseAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EFPractice.DatabaseAccess.Services;

public class BookLibraryService : IBookLibraryService
{
    private readonly BookLibraryDbContext _dbContext;

    public BookLibraryService(BookLibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /* 1. Получить список всех книг, опубликованных после 2010 года, отсортированных по названию.
     * Вывести: название книги, имя автора, год издания. */
    public List<(string Title, string Name, int? PublicationYear)> GetBooksAfterYear(int year)
    {
        return _dbContext.Books
            .Include(b => b.Author)
            .Where(b => b.PublicationYear >= year)
            .AsEnumerable()
            .Select(b =>
                (
                    Title: b.Title!,
                    Name: $"{b.Author!.FirstName} {b.Author!.LastName}",
                    PublicationYear: b.PublicationYear
                ))
            .ToList();
    }

    /* 2. Найти всех авторов, у которых нет биографии (связь Author → AuthorBiography отсутствует). 
     * Вывести: имя автора и год рождения. */
    public List<(string Name, DateOnly? BirthDate)> GetAuthorsNoBio()
    {
        return _dbContext.Authors
            .Include(a => a.AuthorBiography)
            .Where(a => a.AuthorBiography == null )
            .AsEnumerable()
            .Select(a =>
                (
                    Name: $"{a.FirstName} {a.LastName}",
                    BirthDate: a.BirthDate
                ))
            .ToList();
    }

    /* 3. Получить список членов библиотеки, у которых есть хотя бы одна просроченная книга (дата возврата не указана и дата возврата по плану < сегодня). 
     * Вывести: полное имя члена и количество просроченных книг. */
    public List<(string Name, int CountOverdueBooks)> GetMembersOverdueBooks()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        return _dbContext.Members
            .Where(m => m.Loans.Any(l =>
                l.ReturnDate == null &&
                l.DueDate.HasValue &&
                l.DueDate.Value < today))
            .AsEnumerable()
            .Select(m =>
                (
                    Name: $"{m.FirstName} {m.LastName}",
                    CountOverdueBooks: m.Loans.Count(l =>
                        l.ReturnDate == null &&
                        l.DueDate.HasValue &&
                        l.DueDate.Value < today)
                ))
            .ToList();
    }

    /* 4. Для каждой категории вывести количество книг и среднее количество страниц книг в этой категории. 
     * Отсортировать по убыванию количества книг. */
    public List<(string CategoryName, int BooksCount, int AveragePagesCount)> GetCategoriesStat()
    {
        return _dbContext.Categories
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                        .ThenInclude(b => b!.BookDetail)
                .AsEnumerable()
                .Select(c =>
                    {
                        var uniqueBooks = c.BookCategories
                            .Where(bc => bc.Book != null)
                            .GroupBy(bc => bc.Book!.Id)
                            .Select(g => g.First())
                            .ToList();

                        var booksWithPages = uniqueBooks
                            .Where(bc => 
                                bc.Book!.BookDetail != null &&
                                bc.Book.BookDetail.PageCount > 0)
                            .ToList();

                        return (
                            CategoryName: c.Name!,
                            BooksCount: uniqueBooks.Count,
                            AveragePagesCount: booksWithPages.Any()
                                ? (int)booksWithPages.Average(bc => bc.Book!.BookDetail!.PageCount)
                                : 0
                        );
                    })
                .Where(x => x.BooksCount > 0)
                .OrderByDescending(x => x.BooksCount)
                .ToList();
    }

    /* 5. Найти издателей, у которых нет ни одной книги в базе. 
     * Вывести: название издателя и страну. */
    public List<(string PublisherName, string? PublisherAddress)> GetPublishersWithoutBooks()
    {
        return _dbContext.Publishers
            .Where(p => p.Books.Count == 0 )
            .AsEnumerable()
            .Select(p =>
                (
                    PublisherName: p.Name!,
                    PublisherAddress: p.Address
                ))
            .ToList();
    }

    /* 6. Получить книги, которые относятся к более чем одной категории. 
     * Для каждой книги вывести название и список категорий (с датой добавления категории в книгу). */
    public List<(string Title, List<(string? Name, DateOnly? AddedDate)> CategoryNames)> GetBooksWithMoreOneCat()
    {
        return _dbContext.Books
            .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
            .Where(b => b.BookCategories.Count > 1)
            .AsEnumerable()
            .Select(b =>
                (
                    Title: b.Title!,
                    CategoryNames: b.BookCategories.Select(bc => (bc.Category, bc.AddedDate))
                        .Select(x => (x.Category!.Name, x.AddedDate))
                        .ToList()
                ))
            .ToList();
    }

    /* 7. Для каждого автора вывести: имя автора, количество книг и самую популярную книгу (по количеству выдач). Если книг нет — вывести 0. */
    public List<(string Name, int BookCount, string PopularBook)> GetAuthorsPopularBooks()
    {
        return _dbContext.Authors
                    .Select(a => new
                        {
                            AuthorId = a.Id,
                            FirstName = a.FirstName!,
                            LastName = a.LastName!,
                            Books = a.Books.Select(b => new
                                {
                                    BookId = b.Id,
                                    Title = b.Title!,
                                    LoanCount = b.Loans.Count
                                })
                                .ToList()
                        })
                    .AsEnumerable()
                    .Select(a =>
                        {
                            var bookCount = a.Books.Count;
                            string popularBook = "Отсутствует";

                            if (bookCount > 0)
                            {
                                var mostPopularBook = a.Books
                                    .OrderByDescending(b => b.LoanCount)
                                    .First();

                                if(mostPopularBook.LoanCount > 0)
                                {
                                    popularBook = mostPopularBook.Title;
                                }
                            }

                            return (
                                Name: $"{a.FirstName} {a.LastName}",
                                BookCount: bookCount,
                                PopularBook: popularBook
                                );
                        })
                    .ToList();
    }

    /* 8. Найти членов библиотеки, которые брали книги ТОЛЬКО из категории «Фантастика». 
     * Вывести: полное имя члена и общее количество выдач. */
    public List<(string Name, int IssuanceCount)> GetMembersByCategory(string category)
    {
        return _dbContext.Members
            .Include(m => m.Loans)
                .ThenInclude(l => l.Book)
                    .ThenInclude(b => b.BookCategories)
                        .ThenInclude(bc => bc.Category)
            .Where(m => m.Loans.Any())
                .Select(m => new
                {
                    Name = $"{m.FirstName} {m.LastName}",
                    AllLoansWithCategory = m.Loans.All(l =>
                        l.Book != null && l.Book.BookCategories.Count > 0 && l.Book.BookCategories.Any(bc => bc.Category!.Name == category)),
                    IssuanceCount = m.Loans.Count()
                })
            .Where(x => x.AllLoansWithCategory)
            .AsEnumerable()
            .Select(x => 
                (
                    Name: x.Name,
                    IssuanceCount: x.IssuanceCount
                ))
            .ToList();
    }

    /* 9. Получить книги с детальной информацией (включая ISBN, количество страниц, цену), отсортированные по цене по убыванию. 
     * Обработать случай, когда у книги нет детальной информации. */
    public List<(Book Book, bool IsHasBookDetails)> GetBooksWithInfo()
    {
        return _dbContext.Books
            .Include(b => b.BookDetail)
            .OrderByDescending(b => b.Price)
            .AsEnumerable()
            .Select(b =>
                (
                    Book: b,
                    IsHasBookDetails: b.BookDetail == null ? false : true
                ))
            .ToList();
    }

    /* 10. Для каждого издателя вывести: название издателя, количество книг и название самой новой книги (по году издания). Если книг нет — пропустить издателя. */
    public List<(string PublisherName, int BookCount, string? BookName)> GetPublishersWithBooks()
    {
        return _dbContext.Publishers
            .Include(p => p.Books)
            .Where(p => p.Books.Count > 0)
            .AsEnumerable()
            .Select(p =>
                (
                    PublisherName: p.Name!,
                    BookCount: p.Books.Count,
                    BookName: p.Books.OrderByDescending(b => b.PublicationYear).First().Title
                ))
            .ToList();
    }


    /* Заполнение таюлиц данными */
    public void InitData()
    {
        //Создано с использование AI, за недостоверность информации вините китайцев

        _dbContext.Loans.RemoveRange(_dbContext.Loans);
        _dbContext.SaveChanges();

        _dbContext.MemberContacts.RemoveRange(_dbContext.MemberContacts);
        _dbContext.SaveChanges();

        _dbContext.Members.RemoveRange(_dbContext.Members);
        _dbContext.SaveChanges();

        _dbContext.BookCategories.RemoveRange(_dbContext.BookCategories);
        _dbContext.SaveChanges();

        _dbContext.BookDetails.RemoveRange(_dbContext.BookDetails);
        _dbContext.SaveChanges();

        _dbContext.Books.RemoveRange(_dbContext.Books);
        _dbContext.SaveChanges();

        _dbContext.Categories.RemoveRange(_dbContext.Categories);
        _dbContext.SaveChanges();

        _dbContext.AuthorBiographies.RemoveRange(_dbContext.AuthorBiographies);
        _dbContext.SaveChanges();

        _dbContext.Authors.RemoveRange(_dbContext.Authors);
        _dbContext.SaveChanges();

        _dbContext.Publishers.RemoveRange(_dbContext.Publishers);
        _dbContext.SaveChanges();

        // 1. Создаем классических авторов (русские писатели)
        var classicAuthors = new List<Author>
            {
                new Author
                {
                    FirstName = "Лев",
                    LastName = "Толстой",
                    BirthDate = new DateOnly(1828, 9, 9),
                    Country = "Россия"
                },
                new Author
                {
                    FirstName = "Федор",
                    LastName = "Достоевский",
                    BirthDate = new DateOnly(1821, 11, 11),
                    Country = "Россия"
                },
                new Author
                {
                    FirstName = "Антон",
                    LastName = "Чехов",
                    BirthDate = new DateOnly(1860, 1, 29),
                    Country = "Россия"
                }
            };

        // 2. Создаем современных авторов (популярны после 2010)
        var modernAuthors = new List<Author>
            {
                new Author
                {
                    FirstName = "Гузель",
                    LastName = "Яхина",
                    BirthDate = new DateOnly(1977, 6, 1),
                    Country = "Россия"
                },
                new Author
                {
                    FirstName = "Виктор",
                    LastName = "Пелевин",
                    BirthDate = new DateOnly(1962, 11, 22),
                    Country = "Россия"
                },
                new Author
                {
                    FirstName = "Дмитрий",
                    LastName = "Глуховский",
                    BirthDate = new DateOnly(1979, 6, 12),
                    Country = "Россия"
                }
            };

        var allAuthors = classicAuthors.Concat(modernAuthors).ToList();
        _dbContext.Authors.AddRange(allAuthors);
        _dbContext.SaveChanges();

        // 3. Создаем биографии авторов
        var authorBiographies = new List<AuthorBiography>
            {
                // Классические авторы
                new AuthorBiography
                {
                    AuthorId = allAuthors[0].Id,
                    Education = "Казанский университет",
                    Awards = "Орден Святой Анны, Орден Святого Владимира",
                    BiographyText = "Лев Николаевич Толстой — один из наиболее известных русских писателей и мыслителей."
                },
                new AuthorBiography
                {
                    AuthorId = allAuthors[1].Id,
                    Education = "Главное инженерное училище",
                    Awards = null,
                    BiographyText = "Фёдор Михайлович Достоевский — русский писатель, мыслитель, философ и публицист."
                },
                new AuthorBiography
                {
                    AuthorId = allAuthors[2].Id,
                    Education = "Московский университет, медицинский факультет",
                    Awards = "Пушкинская премия",
                    BiographyText = "Антон Павлович Чехов — русский писатель, прозаик, драматург, врач."
                },
                // Современные авторы
                new AuthorBiography
                {
                    AuthorId = allAuthors[3].Id,
                    Education = "Казанский государственный педагогический институт",
                    Awards = "Большая книга, Ясная Поляна",
                    BiographyText = "Гузель Яхина — российская писательница, сценарист, лауреат премий «Большая книга» и «Ясная Поляна»."
                },
                new AuthorBiography
                {
                    AuthorId = allAuthors[4].Id,
                    Education = "Московский институт стали и сплавов",
                    Awards = "Национальный бестселлер, Премия Андрея Белого",
                    BiographyText = "Виктор Пелевин — российский писатель, автор культовых романов в жанре постмодернизма."
                }
            };

        _dbContext.AuthorBiographies.AddRange(authorBiographies);
        _dbContext.SaveChanges();

        // 4. Создаем издательства
        var publishers = new List<Publisher>
            {
                new Publisher
                {
                    Name = "АСТ",
                    Address = "Москва, ул. Правды, 24",
                    Website = "https://ast.ru"
                },
                new Publisher
                {
                    Name = "Эксмо",
                    Address = "Москва, ул. Зорге, 1",
                    Website = "https://eksmo.ru"
                },
                new Publisher
                {
                    Name = "Речь",
                    Address = "Санкт-Петербург, наб. реки Мойки, 32",
                    Website = "https://rech-deti.ru"
                },
                new Publisher
                {
                    Name = "Редакция Елены Шубиной",
                    Address = "Москва, ул. Садовая-Спасская, 20",
                    Website = "https://shubina.ru"
                }
            };

        _dbContext.Publishers.AddRange(publishers);
        _dbContext.SaveChanges();

        // 5. Создаем книги (классика и современность)
        var books = new List<Book>
            {
                // Классические книги
                new Book
                {
                    Title = "Война и мир",
                    ISBN = "978-5-17-090254-5",
                    PublicationYear = 1869,
                    Price = 1200.50m,
                    AuthorId = allAuthors[0].Id,
                    PublisherId = publishers[0].Id
                },
                new Book
                {
                    Title = "Анна Каренина",
                    ISBN = "978-5-04-099524-8",
                    PublicationYear = 1877,
                    Price = 950.00m,
                    AuthorId = allAuthors[0].Id,
                    PublisherId = publishers[1].Id
                },
                new Book
                {
                    Title = "Преступление и наказание",
                    ISBN = "978-5-17-090678-9",
                    PublicationYear = 1866,
                    Price = 850.75m,
                    AuthorId = allAuthors[1].Id,
                    PublisherId = publishers[0].Id
                },
                // Современные книги (после 2010)
                new Book
                {
                    Title = "Зулейха открывает глаза",
                    ISBN = "978-5-17-090987-2",
                    PublicationYear = 2015,
                    Price = 650.00m,
                    AuthorId = allAuthors[3].Id, // Гузель Яхина
                    PublisherId = publishers[3].Id
                },
                new Book
                {
                    Title = "Дети мои",
                    ISBN = "978-5-17-109014-2",
                    PublicationYear = 2018,
                    Price = 720.00m,
                    AuthorId = allAuthors[3].Id,
                    PublisherId = publishers[3].Id
                },
                new Book
                {
                    Title = "iПсихоз",
                    ISBN = "978-5-699-87654-3",
                    PublicationYear = 2017,
                    Price = 580.00m,
                    AuthorId = allAuthors[4].Id, // Виктор Пелевин
                    PublisherId = publishers[1].Id
                },
                new Book
                {
                    Title = "Метро 2033",
                    ISBN = "978-5-699-44215-4",
                    PublicationYear = 2010,
                    Price = 690.00m,
                    AuthorId = allAuthors[5].Id, // Дмитрий Глуховский
                    PublisherId = publishers[1].Id
                },
                new Book
                {
                    Title = "Текст",
                    ISBN = "978-5-17-107622-1",
                    PublicationYear = 2017,
                    Price = 550.00m,
                    AuthorId = allAuthors[5].Id,
                    PublisherId = publishers[0].Id
                }
            };

        _dbContext.Books.AddRange(books);
        _dbContext.SaveChanges();

        // 6. Создаем детали книг
        var bookDetails = new List<BookDetail>
            {
                // Классика
                new BookDetail
                {
                    BookId = books[0].Id,
                    Summary = "Роман-эпопея, описывающий русское общество в эпоху войн против Наполеона.",
                    PageCount = 1225,
                    Language = "Русский",
                    Edition = 1
                },
                new BookDetail
                {
                    BookId = books[1].Id,
                    Summary = "Трагическая история замужней женщины, полюбившей блестящего офицера.",
                    PageCount = 864,
                    Language = "Русский",
                    Edition = 1
                },
                new BookDetail
                {
                    BookId = books[2].Id,
                    Summary = "История бывшего студента Родиона Раскольникова, совершившего убийство.",
                    PageCount = 592,
                    Language = "Русский",
                    Edition = 1
                },
                // Современные
                new BookDetail
                {
                    BookId = books[3].Id,
                    Summary = "Роман о раскулаченной татарской крестьянке Зулейхе, отправленной в Сибирь в 1930-е годы.",
                    PageCount = 508,
                    Language = "Русский",
                    Edition = 1
                },
                new BookDetail
                {
                    BookId = books[4].Id,
                    Summary = "История поволжского немца Якоба Баха, учителя в маленькой колонии Гнаденталь.",
                    PageCount = 496,
                    Language = "Русский",
                    Edition = 1
                },
                new BookDetail
                {
                    BookId = books[5].Id,
                    Summary = "Сборник рассказов, исследующий влияние технологий на сознание современного человека.",
                    PageCount = 320,
                    Language = "Русский",
                    Edition = 1
                },
                new BookDetail
                {
                    BookId = books[6].Id, // Метро 2033
                    Summary = "Постапокалиптический роман о выживании человечества после ядерной войны. Главный герой Артём отправляется в опасное путешествие по тоннелям московского метро, чтобы спасти свою станцию от новой угрозы.",
                    PageCount = 384,
                    Language = "Русский",
                    Edition = 1
                },
                new BookDetail
                {
                    BookId = books[7].Id, // Текст
                    Summary = "Психологический триллер о бывшем заключённом Илье Горюнове, который получает телефон убитого им человека и начинает жить его жизнью, читая переписку и входя в его социальные круги.",
                    PageCount = 416,
                    Language = "Русский",
                    Edition = 1
                }
            };

        _dbContext.BookDetails.AddRange(bookDetails);
        _dbContext.SaveChanges();

        // 7. Создаем категории (добавим современные жанры)
        var categories = new List<Category>
            {
                new Category
                {
                    Name = "Русская классика",
                    Description = "Произведения русских классиков литературы"
                },
                new Category
                {
                    Name = "Роман",
                    Description = "Крупные повествовательные произведения"
                },
                new Category
                {
                    Name = "Драма",
                    Description = "Произведения драматического жанра"
                },
                new Category
                {
                    Name = "Современная проза",
                    Description = "Произведения современных авторов"
                },
                new Category
                {
                    Name = "Исторический роман",
                    Description = "Художественные произведения на историческую тему"
                },
                new Category
                {
                    Name = "Постапокалиптика",
                    Description = "Жанр о жизни после глобальной катастрофы"
                },
                new Category
                {
                    Name = "Бестселлер",
                    Description = "Популярные книги, пользующиеся большим спросом"
                }
            };

        _dbContext.Categories.AddRange(categories);
        _dbContext.SaveChanges();

        // 8. Создаем связи книг с категориями
        var bookCategories = new List<BookCategory>
            {
                // Классика
                new BookCategory
                {
                    BookId = books[0].Id,
                    CategoryId = categories[0].Id, // Русская классика
                    AddedDate = new DateOnly(2024, 1, 15)
                },
                new BookCategory
                {
                    BookId = books[0].Id,
                    CategoryId = categories[1].Id, // Роман
                    AddedDate = new DateOnly(2024, 1, 15)
                },
                new BookCategory
                {
                    BookId = books[1].Id,
                    CategoryId = categories[0].Id, // Русская классика
                    AddedDate = new DateOnly(2024, 1, 16)
                },
                // Современные книги
                new BookCategory
                {
                    BookId = books[3].Id,
                    CategoryId = categories[3].Id, // Современная проза
                    AddedDate = new DateOnly(2024, 2, 1)
                },
                new BookCategory
                {
                    BookId = books[3].Id,
                    CategoryId = categories[4].Id, // Исторический роман
                    AddedDate = new DateOnly(2024, 2, 1)
                },
                new BookCategory
                {
                    BookId = books[3].Id,
                    CategoryId = categories[6].Id, // Бестселлер
                    AddedDate = new DateOnly(2024, 2, 1)
                },
                new BookCategory
                {
                    BookId = books[6].Id,
                    CategoryId = categories[5].Id, // Постапокалиптика
                    AddedDate = new DateOnly(2024, 2, 2)
                },
                new BookCategory
                {
                    BookId = books[6].Id,
                    CategoryId = categories[6].Id, // Бестселлер
                    AddedDate = new DateOnly(2024, 2, 2)
                }
            };

        _dbContext.BookCategories.AddRange(bookCategories);
        _dbContext.SaveChanges();

        // 9. Создаем читателей
        var members = new List<Member>
            {
                new Member
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Email = "ivanov@example.com",
                    BirthDate = new DateOnly(1990, 5, 15)
                },
                new Member
                {
                    FirstName = "Мария",
                    LastName = "Петрова",
                    Email = "petrova@example.com",
                    BirthDate = new DateOnly(1985, 8, 22)
                },
                new Member
                {
                    FirstName = "Алексей",
                    LastName = "Сидоров",
                    Email = "sidorov@example.com",
                    BirthDate = new DateOnly(1995, 3, 10)
                },
                new Member
                {
                    FirstName = "Анна",
                    LastName = "Смирнова",
                    Email = "smirnova@example.com",
                    BirthDate = new DateOnly(2000, 7, 30)
                }
            };

        _dbContext.Members.AddRange(members);
        _dbContext.SaveChanges();

        // 10. Создаем контакты читателей
        var memberContacts = new List<MemberContact>
            {
                new MemberContact
                {
                    MemberId = members[0].Id,
                    Phone = "+7 (999) 123-45-67",
                    Address = "ул. Ленина, д. 10, кв. 5",
                    City = "Москва"
                },
                new MemberContact
                {
                    MemberId = members[1].Id,
                    Phone = "+7 (999) 234-56-78",
                    Address = "пр. Победы, д. 25, кв. 12",
                    City = "Санкт-Петербург"
                },
                new MemberContact
                {
                    MemberId = members[2].Id,
                    Phone = "+7 (999) 345-67-89",
                    Address = "ул. Садовая, д. 3, кв. 7",
                    City = "Екатеринбург"
                }
            };

        _dbContext.MemberContacts.AddRange(memberContacts);
        _dbContext.SaveChanges();

        // 11. Создаем записи о выдачах книг (включая современные)
        var loans = new List<Loan>
            {
                // Классика
                new Loan
                {
                    BookId = books[0].Id,
                    MemberId = members[0].Id,
                    LoanDate = new DateOnly(2024, 1, 10),
                    DueDate = new DateOnly(2024, 2, 10),
                    ReturnDate = new DateOnly(2024, 1, 25)
                },
                new Loan
                {
                    BookId = books[1].Id,
                    MemberId = members[1].Id,
                    LoanDate = new DateOnly(2024, 1, 12),
                    DueDate = new DateOnly(2024, 2, 12)
                },
                // Современные книги
                new Loan
                {
                    BookId = books[3].Id, // Зулейха открывает глаза
                    MemberId = members[2].Id,
                    LoanDate = new DateOnly(2026, 1, 1),
                    DueDate = new DateOnly(2026, 2, 1),
                    ReturnDate = new DateOnly(2026, 2, 6)
                },
                new Loan
                {
                    BookId = books[6].Id, // Метро 2033
                    MemberId = members[3].Id,
                    LoanDate = new DateOnly(2026, 1, 5),
                    DueDate = new DateOnly(2026, 2, 5)
                }
            };

        _dbContext.Loans.AddRange(loans);
        _dbContext.SaveChanges();

        Console.WriteLine($"Инициализация данных завершена успешно!");
        Console.WriteLine($"Создано: {allAuthors.Count} авторов, {books.Count} книг, {members.Count} читателей");
        Console.WriteLine($"Из них современных авторов: {modernAuthors.Count}");
    }
}
