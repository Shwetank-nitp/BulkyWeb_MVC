namespace BulkyWeb.Repository
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        void Save();
    }
}
