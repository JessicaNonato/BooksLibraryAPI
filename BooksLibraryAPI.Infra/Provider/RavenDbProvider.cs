using BooksLibraryAPI.Domain.Models.Settings;
using BooksLibraryAPI.Infra.Interfaces;
using Raven.Client.Documents;

namespace BooksLibraryAPI.Infra.Provider
{
    public class RavenDbProvider : IRavenDbProvider
    {
        private readonly BookStoreDatabaseSettings _bookStoreDatabaseSettings;
        public IDocumentStore DocumentStore { get; private set; }
        
        public RavenDbProvider(BookStoreDatabaseSettings bookStoreDatabaseSettings)
        {
            _bookStoreDatabaseSettings = bookStoreDatabaseSettings;
            DocumentStore = GetInitializedDocumentStore();
        }

        private IDocumentStore GetInitializedDocumentStore()
        {
            DocumentStore = CreateDocumentStore();
            DocumentStore.Initialize();
            return DocumentStore;
        }

        private IDocumentStore CreateDocumentStore() =>
            new DocumentStore
            {
                Urls = _bookStoreDatabaseSettings.Urls,
                Database = _bookStoreDatabaseSettings.Name

            };
    }
}
