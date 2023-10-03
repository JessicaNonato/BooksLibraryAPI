using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibraryAPI.Domain.Models.Settings
{
    public class OrderStoreDatabaseSettings
    {

            public OrderStoreDatabaseSettings()
            {
                Name = "OrderStoreDatabase";
                Urls = new[] { "http://localhost:9094" };
                // Name = string.Empty;
                // Urls = Array.Empty<string>();
            }

            public string Name { get; set; }
            public string[] Urls { get; set; }

    }
}
