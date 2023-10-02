using System.Threading.Tasks;
using BooksLibraryAPI.Infra.Interfaces;
using Raven.Client.Documents;

namespace BooksLibraryAPI.Infra.Implementations
{
    public class GenericRepository: IGenericRepository
    {
        private readonly IDocumentStore _documentStore;

        public GenericRepository(IRavenDbProvider ravenDbProvider)
        {
            _documentStore = ravenDbProvider.DocumentStore;
        }

        public async Task SaveAsync<T>( T document, string id, string collection)
        {
            using var session = _documentStore.OpenAsyncSession();
            await session.StoreAsync(document, id);

            session.Advanced.GetMetadataFor(document)["@collection"] = collection;
            await session.SaveChangesAsync();

        }

        public T GetDocumentById<T>(string id)
        {
            using var session = _documentStore.OpenSession();

            var document = session.Load<T>(id);

            return document;
        }

    }
}
