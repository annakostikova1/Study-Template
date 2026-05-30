namespace Study.LabWork3.Storage;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }

    // внешние ключи для связи с автором
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}
