using System.Collections.Generic;

namespace Study.LabWork3.Storage;

public class Author
{
    public int Id { get; set; }

    // добавили required
    public required string Name { get; set; }

    public List<Book> Books { get; set; } = new List<Book>();
}
