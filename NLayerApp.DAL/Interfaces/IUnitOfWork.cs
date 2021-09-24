using NLayerApp.DAL.Entities;
using System;


namespace NLayerApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Project> Managers { get; }
        IRepository<Project> Projects { get; }
        IRepository<PmTask> PmTasks { get; }
        IRepository<Team> Teams { get; }
        IRepository<User> Users { get; }

        void Save();
    }
}
