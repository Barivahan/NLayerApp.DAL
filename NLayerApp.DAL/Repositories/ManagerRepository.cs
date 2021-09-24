using Microsoft.EntityFrameworkCore;
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
    class ManagerRepository : IRepository<Manager>
    {
        private SqlContext db;
        public ManagerRepository(SqlContext sqlContext)
        {
            this.db = sqlContext;
        }

        public async void Create(Manager item)
        {
            await db.Managers.AddAsync(item);

        }

        public async void Delete(int id)
        {
            Manager manager = await db.Managers.FindAsync(id);
            if (manager != null)
            {
                db.Managers.Remove(manager);
            }
        }

        public IEnumerable<Manager> Find(Func<Manager, bool> predicate)
        {
            return db.Managers.Where(predicate).ToList();
        }

        public Manager Get(int id)
        {
            return db.Managers.Find(id);
        }

        public IEnumerable<Manager> GetAll()
        {
            return db.Managers;
        }

        public void Update(Manager item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
