using BulkyWeb.DataAccess.Data;

namespace BulkyWeb.Repository
{
    public class UnitOfWork :CategoryRepository, IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
