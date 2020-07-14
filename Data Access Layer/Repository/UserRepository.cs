using Data_Access_Layer.Interfaces;
using MaxsGornTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    class UserRepository : IRepository<User>
    {
        private Context db;

        public UserRepository(Context context)
        {
            this.db = context;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public async Task DeleteAsync(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user != null)
                db.Users.Remove(user);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return null;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public Task<User> GetAsync(int id)
        {
            return db.Users.FindAsync(id);
        }

        public void UpdateAsync(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
