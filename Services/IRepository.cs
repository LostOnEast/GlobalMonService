namespace GlobalMonService.Services
{
    interface IRepository<T>: IDisposable
    {
        IEnumerable<IMessage> GetList();
        IMessage Get(int id);
        void Create(IMessage item);
        void Update(IMessage item);
        void Delete(int id);
        void Save();
    }
}
