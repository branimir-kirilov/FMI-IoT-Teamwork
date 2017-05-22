using System.Linq;

namespace SmartHive.Data.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        T GetById(object id);
        IQueryable<T> GetAll { get; }

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
