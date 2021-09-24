using Microsoft.EntityFrameworkCore;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NLayerApp.DAL.Repositories
{
    internal class TeamRepository : IRepository<Team>
    {
        private SqlContext db;
        public TeamRepository(SqlContext sqlContext)
        {
            this.db = sqlContext;
        }
        public async void Create(Team item)
        {
            await db.Teams.AddAsync(item);
        }

        public async void Delete(int id)
        {
            Team team = await db.Teams.FindAsync(id);
            if (team != null)
            {
                db.Teams.Remove(team);
            }
        }

        public IEnumerable<Team> Find(Func<Team, bool> predicate)
        {
            return db.Teams.Where(predicate).ToList();
        }

        public Team Get(int id)
        {
            return db.Teams.Find(id);
        }

        public IEnumerable<Team> GetAll()
        {
            return db.Teams;
        }

        public void Update(Team item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}