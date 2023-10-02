using System.Threading.Tasks;

namespace BooksLibraryAPI.Infra.Interfaces
{
    public interface IGenericRepository
    {
        Task SaveAsync<T>(T document, string id, string collection);
        T GetDocumentById<T>(string id);

    }
}
