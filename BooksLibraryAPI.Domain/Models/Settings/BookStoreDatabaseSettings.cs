using System;
namespace BooksLibraryAPI.Domain.Models.Settings
{
    public class BookStoreDatabaseSettings
    {
        public BookStoreDatabaseSettings()
        {
            Name = "BookStore";
            Urls = new[] { "http://localhost:9094" };
            // Name = string.Empty;
            // Urls = Array.Empty<string>();
        }

        public string Name { get; set; }
        public string[] Urls { get; set; }

    }
}
