namespace BulkyWeb.Repository
{
    public interface IUnitOfWork : ICategoryRepository
    {
        void Save();
    }
}
