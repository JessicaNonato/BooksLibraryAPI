using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace BooksLibraryAPI.API.Models
{
    public class Book
    {
        public ObjectId Id { get; set; }
        public string author { get; set; } = null!;
        public string imageLink { get; set; } = null;
        public string description { get; set; } = null;
        public int pages { get; set; }
        public string title { get; set; } = null!;
        public int year { get; set; }
        public string editora { get; set; } = null;
    }
}
