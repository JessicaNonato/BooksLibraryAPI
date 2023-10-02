using Raven.Client.Documents;

namespace BooksLibraryAPI.Infra.Interfaces
{
    public interface IRavenDbProvider
    {
        IDocumentStore DocumentStore { get; }
    }
}
