using System.Collections.Generic;
using System.Linq;
using Study.LabWork3.Storage;

namespace Study.LabWork3.Logic;

public class BookService
{
    public List<Book> GetAllBooks()
    {
        using var db = new BookDbContext();
        return db.Books.ToList();
    }

    public void AddBook(Book book)
    {
        using var db = new BookDbContext();
        db.Books.Add(book);
        db.SaveChanges();
    }

    // методы для авторов
    public List<Author> GetAllAuthors()
    {
        using var db = new BookDbContext();
        return db.Authors.ToList();
    }

    public void AddAuthor(Author author)
    {
        using var db = new BookDbContext();
        db.Authors.Add(author);
        db.SaveChanges();
    }

    // методы для издательств
    public List<Publisher> GetAllPublishers()
    {
        using var db = new BookDbContext();
        return db.Publishers.ToList();
    }

    public void AddPublisher(Publisher publisher)
    {
        using var db = new BookDbContext();
        db.Publishers.Add(publisher);
        db.SaveChanges();
    }
}
