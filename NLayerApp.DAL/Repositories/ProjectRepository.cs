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
    class ProjectRepository :IRepository<Project>
    {
        private SqlContext db;
        public ProjectRepository(SqlContext sqlContext)
        {
            this.db = sqlContext;
        }

        public async void Create(Project item)
        {
            await db.Projects.AddAsync(item);

        }

        public async void Delete(int id)
        {
            Project project = await db.Projects.FindAsync(id);
            if (project != null)
            {
                db.Projects.Remove(project);
            }
        }

        public IEnumerable<Project> Find(Func<Project, bool> predicate)
        {
            return db.Projects.Where(predicate).ToList();
        }

        public Project Get(int id)
        {
            return db.Projects.Find(id);
        }

        public IEnumerable<Project> GetAll()
        {
            return db.Projects;
        }

        public void Update(Project item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
