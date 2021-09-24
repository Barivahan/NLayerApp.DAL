using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Repositories
{
    class EFUnitOfWork : IUnitOfWork
    {
        private SqlContext db;
        private ManagerRepository managerRepository;
        private Project projectRepository;
        private Task taskRepository;
        private Team teamRepository;
        private User userRepository;


        public EFUnitOfWork()
        {
            this.db = new SqlContext();
        }

        public IRepository<Project> Managers
        {
            get
            {
                if (managerRepository == null)

                    managerRepository = new ManagerRepository(db);

                return managerRepository;
            }
        }

        public IRepository<Project> Projects => throw new NotImplementedException();

        public IRepository<PmTask> PmTasks => throw new NotImplementedException();

        public IRepository<Team> Teams => throw new NotImplementedException();

        public IRepository<User> Users => throw new NotImplementedException();



        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
