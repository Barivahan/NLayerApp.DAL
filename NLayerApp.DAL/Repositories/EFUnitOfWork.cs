using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;

namespace NLayerApp.DAL.Repositories
{
    class EFUnitOfWork : IUnitOfWork
    {
        private SqlContext db;


        private ProjectRepository projectRepository;
        private TaskRepository taskRepository;
        private TeamRepository teamRepository;
        private UserRepository userRepository;


        public EFUnitOfWork()
        {
            this.db = new SqlContext();
        }

        public IRepository<Project> Projects
        {
            get
            {
                if (projectRepository == null)

                    projectRepository = new ProjectRepository(db);
                return projectRepository;
            }
        }

        public IRepository<Entities.Task> Tasks
        {
            get
            {
                if (taskRepository == null)
                    taskRepository = new TaskRepository(db);
                return taskRepository;
            }
        }

        public IRepository<Team> Teams
        {
            get
            {
                if (teamRepository == null)
                    teamRepository = new TeamRepository(db);
                return teamRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }



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
