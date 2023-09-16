using BulkyWeb.Models.Models;

namespace BulkyWeb.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
        
    }
}
