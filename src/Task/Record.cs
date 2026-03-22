
public class Record
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int BookId { get; set; }
    public int Year { get; set; }

    public Record(string title, string author, int bookId, int year)
    {
        Title = title;
        Author = author;
        BookId = bookId;
        Year = year;
    }

    public override string ToString()
    {
        return $"[{BookId} {Title} - {Author} ({Year})]";
    }
}