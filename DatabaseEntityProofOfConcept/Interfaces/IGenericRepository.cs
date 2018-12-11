using System.Linq;

namespace DatabaseEntityProofOfConcept.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Save();
    }
}
