
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
        public string genre { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
    }
}
