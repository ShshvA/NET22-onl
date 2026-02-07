using EFPractice.DatabaseAccess.Interfaces;
using EFPractice.DatabaseAccess.Models;

namespace EFPractice.DatabaseAccess.Services;

public class BookLibraryService : IBookLibraryService
{
    private readonly BookLibraryDbContext _dbContext;

    public BookLibraryService(BookLibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void InitData()
    {
        
  
    }
}
