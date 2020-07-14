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
    class SoundRepository : IRepository<Sound>
    {
        private Context db;
        public SoundRepository(Context context)
        {
            this.db = context;
        }

        public void Create(Sound item)
        {
            db.Sounds.Add(item);
        }

        public async Task DeleteAsync(int id)
        {
            Sound order = await db.Sounds.FindAsync(id);
            if (order != null)
                db.Sounds.Remove(order);
        }

        public IEnumerable<Sound> Find(Func<Sound, bool> predicate)
        {
            return null;
        }

        public Sound Get(int id)
        {
            return db.Sounds.Find(id);
        }
        public async Task<Sound> GetAsync(int id)
        {
            return await db.Sounds.FindAsync(id);
        }

        public IEnumerable<Sound> GetAll()
        {
            return db.Sounds;
        }

        public void UpdateAsync(Sound item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

    }
}
