using DatabaseEntityProofOfConcept.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace DatabaseEntityProofOfConcept.Utils
{
    public abstract class GenericRepository<C, T> :
        IGenericRepository<T> where T : class where C : DbContext, new()
    {
        public C Context { get; set; } = new C();

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = Context.Set<T>();
            return query;
        }

        public virtual void Insert(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }
    }
}
