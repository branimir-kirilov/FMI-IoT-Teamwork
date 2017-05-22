using System.Data.Entity;

namespace SmartHive.Data.Contracts
{
    public interface ISmartHiveEntities
    {
        IDbSet<TEntity> DbSet<TEntity>()
            where TEntity : class;

        int SaveChanges();

        void SetAdded<TEntry>(TEntry entity)
            where TEntry : class;

        void SetDeleted<TEntry>(TEntry entity)
           where TEntry : class;
    
        void SetUpdated<TEntry>(TEntry entity)
            where TEntry : class;
    }
}
