using SmartHive.Data.Contracts;
using System;

namespace SmartHive.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISmartHiveEntities dbContext;

        public UnitOfWork(ISmartHiveEntities dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException("Context cant be null");
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {

        }
    }
}
