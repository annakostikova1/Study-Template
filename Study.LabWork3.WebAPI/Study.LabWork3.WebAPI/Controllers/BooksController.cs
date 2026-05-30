using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Study.LabWork3.Storage;
using Study.LabWork3.Logic;

namespace Study.LabWork3.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookService service = new BookService();

    [HttpGet("books")]
    public List<Book> GetBooks() => service.GetAllBooks();

    [HttpPost("book")]
    public void PostBook(Book book) => service.AddBook(book);

    [HttpGet("authors")]
    public List<Author> GetAuthors() => service.GetAllAuthors();

    [HttpPost("author")]
    public void PostAuthor(Author author) => service.AddAuthor(author);

    [HttpGet("publishers")]
    public List<Publisher> GetPublishers() => service.GetAllPublishers();

    [HttpPost("publisher")]
    public void PostPublisher(Publisher publisher) => service.AddPublisher(publisher);
}
