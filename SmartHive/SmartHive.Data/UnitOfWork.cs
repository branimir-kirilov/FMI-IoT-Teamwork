using SmartHive.Data.Contracts;
using System;

namespace SmartHive.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISmartHiveEntities dbContext;

        public UnitOfWork(ISmartHiveEntities dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("Context cant be null");
            }

            this.dbContext = dbContext;
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
