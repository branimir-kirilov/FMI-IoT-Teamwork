using SmartHive.Services.Contracts;
using System;
using System.Collections.Generic;
using SmartHive.Models;
using SmartHive.Data.Contracts;

namespace SmartHive.Services
{
    public class HiveService : IHiveService
    {
        private readonly IRepository<Hive> hiveRepository;
        private readonly IUnitOfWork unitOfWork;

        public HiveService(
            IRepository<Hive> hiveRepository,
            IUnitOfWork unitOfWork)
        {
            if (hiveRepository == null)
            {
                throw new ArgumentNullException(nameof(hiveRepository));
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            this.hiveRepository = hiveRepository;
            this.unitOfWork = unitOfWork;
        }

        public Hive GetHiveById(string id)
        {
            return this.hiveRepository.GetById(id);
        }

        public IEnumerable<Hive> GetHivesByUserId(string id)
        {
            throw new NotImplementedException();
        }

    }
}
