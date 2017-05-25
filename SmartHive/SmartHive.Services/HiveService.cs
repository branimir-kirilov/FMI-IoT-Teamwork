using SmartHive.Services.Contracts;
using System;
using System.Collections.Generic;
using SmartHive.Models;
using SmartHive.Data.Contracts;
using System.Linq;
using SmartHive.Factories;

namespace SmartHive.Services
{
    public class HiveService : IHiveService
    {
        private readonly IRepository<Hive> hiveRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHiveFactory hiveFactory;

        public HiveService(
            IRepository<Hive> hiveRepository,
            IUnitOfWork unitOfWork,
            IHiveFactory hiveFactory)
        {
            if (hiveRepository == null)
            {
                throw new ArgumentNullException(nameof(hiveRepository));
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            if (hiveFactory == null)
            {
                throw new ArgumentNullException(nameof(hiveFactory));
            }

            this.hiveRepository = hiveRepository;
            this.unitOfWork = unitOfWork;
            this.hiveFactory = hiveFactory;
        }

        public Hive CreateHive(string name, string dataKey, string userId)
        {
            var hive = this.hiveFactory.CreateHive(name, dataKey, userId);

            this.hiveRepository.Add(hive);
            this.unitOfWork.Commit();

            return hive;
        }

        public void EditHive(int id, string name, string dataKey)
        {
            var hive = this.hiveRepository.GetById(id);

            if (hive != null)
            {
                hive.Name = name;
                hive.DataKey = dataKey;

                this.hiveRepository.Update(hive);
                this.unitOfWork.Commit();
            }
        }

        public Hive GetHiveById(string id)
        {
            return this.hiveRepository.GetById(id);
        }

        public IEnumerable<Hive> GetHivesByUserId(string id)
        {
            return this.hiveRepository.GetAll.Where(h => h.UserId == id).ToList();
        }

    }
}
