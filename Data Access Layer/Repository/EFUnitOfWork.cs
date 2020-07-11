using Data_Access_Layer.Interfaces;
using MaxsGornTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private Context db;
        private SoundRepository SoundRepository;
        private UserRepository UserRepository;

        public EFUnitOfWork()
        {
            db = new Context();
        }
        public IRepository<Sound> Sounds
        {
            get
            {
                if (SoundRepository == null)
                    SoundRepository = new SoundRepository(db);
                return SoundRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (UserRepository == null)
                    UserRepository = new UserRepository(db);
                return UserRepository;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
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
