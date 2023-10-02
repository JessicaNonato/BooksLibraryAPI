
namespace BooksLibraryAPI.Domain.Entities
{
    public class BookEntity
    {
        public string bookId { get; set; }
        public string author { get; set; }
        public string imageLink { get; set; }
        public string description { get; set; }
        public int pages { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public string editora { get; set; }
    }
}
