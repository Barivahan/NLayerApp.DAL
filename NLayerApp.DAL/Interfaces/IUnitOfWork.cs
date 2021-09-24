using NLayerApp.DAL.Entities;
using System;


namespace NLayerApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       
        IRepository<Project> Projects { get; }
        IRepository<Task> Tasks { get; }
        IRepository<Team> Teams { get; }
        IRepository<User> Users { get; }

        void Save();
    }
}
