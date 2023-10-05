using System;
using System.Threading.Tasks;
using BooksLibraryAPI.Infra.Interfaces;
using Raven.Client.Documents;
using System.Collections.Generic;
using System.Linq;
using Raven.Client.Documents.Linq;


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
            try
            {
                using var session = _documentStore.OpenSession();
                var element = session.Load<T>(id);
                return element;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public async Task<List<T>> GetAllDocuments<T>()
        //{
        //    try
        //    {
        //        using var session = _documentStore.OpenSession();
        //        var elements = await session
        //            .Advanced
        //            .AsyncLuceneQuery<T>()
        //            .ToListAsync();
        //        return elements;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public async Task<List<T>> GetAllDocuments<T>()
        {
            try
            {
                using var session = _documentStore.OpenAsyncSession();
                var elements = await session.Query<T>().ToListAsync();

                return elements;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync<T>(string id)
        {
            try
            {
                using var session = _documentStore.OpenSession();
                var element = session.Load<T>(id);
                 session.Delete(element);
                session.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        //public async Task UpdateAsync<T>(string id)
        //{
        //    try
        //    {
        //        using var session = _documentStore.OpenSession();
        //        var element = session.Load<T>(id);

        //        session.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}

    }
}
