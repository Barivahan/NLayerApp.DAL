using Microsoft.EntityFrameworkCore;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Repositories
{
    class TaskRepository : IRepository<Entities.Task>
    {
        private SqlContext db;
        public TaskRepository(SqlContext sqlContext)
        {
            this.db = sqlContext;
        }
        public async void Create(Entities.Task item)
        {
            await db.Tasks.AddAsync(item);
        }

        public async void Delete(int id)
        {
            Entities.Task task = await db.Tasks.FindAsync(id);
            if (task != null)
            {
                db.Tasks.Remove(task);
            }
        }

        public IEnumerable<Entities.Task> Find(Func<Entities.Task, bool> predicate)
        {
            return db.Tasks.Where(predicate).ToList();
        }

        public Entities.Task Get(int id)
        {
            return db.Tasks.Find(id);
        }

        public IEnumerable<Entities.Task> GetAll()
        {
            return db.Tasks;
        }

        public void Update(Entities.Task item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
