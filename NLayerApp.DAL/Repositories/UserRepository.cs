using Microsoft.EntityFrameworkCore;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NLayerApp.DAL.Repositories
{
    internal class UserRepository : IRepository<User>
    {
        private SqlContext db;
        public UserRepository(SqlContext sqlContext)
        {
            this.db = sqlContext;
        }
        public async void Create(User item)
        {
            await db.Users.AddAsync(item);
        }

        public async void Delete(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}