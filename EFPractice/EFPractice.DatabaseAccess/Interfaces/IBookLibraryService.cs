using EFPractice.DatabaseAccess.Models;

namespace EFPractice.DatabaseAccess.Interfaces;

public interface IBookLibraryService
{
    List<(string Name, DateOnly? BirthDate)> GetAuthorsNoBio();
    List<(string Name, int BookCount, string PopularBook)> GetAuthorsPopularBooks();
    List<(string Title, string Name, int? PublicationYear)> GetBooksAfterYear(int year);
    List<(Book Book, bool IsHasBookDetails)> GetBooksWithInfo();
    List<(string Title, List<(string? Name, DateOnly? AddedDate)> CategoryNames)> GetBooksWithMoreOneCat();
    List<(string CategoryName, int BooksCount, int AveragePagesCount)> GetCategoriesStat();
    List<(string Name, int IssuanceCount)> GetMembersByCategory(string category);
    List<(string Name, int CountOverdueBooks)> GetMembersOverdueBooks();
    List<(string PublisherName, int BookCount, string? BookName)> GetPublishersWithBooks();
    List<(string PublisherName, string? PublisherAddress)> GetPublishersWithoutBooks();
    public void InitData();
}
