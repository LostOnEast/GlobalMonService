using GlobalMonService.Models;
using System.Data.Entity;

namespace GlobalMonService.Services
{
    public class SQLMessageComandsRepository : IRepository<IMessage>
    {
        private MessageContext db;

        public SQLMessageComandsRepository()
        {
            this.db = new MessageContext();
        }

        public IEnumerable<IMessage> GetList()
        {
            return db.MessageCommands;
        }

        public IMessage Get(int id)
        {
            return db.MessageCommands.Find(id);
        }

        public void Create(IMessage messageCommand)
        {
            db.MessageCommands.Add(messageCommand);
        }

        public void Update(IMessage messageCommand)
        {
            db.Entry(messageCommand).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            IMessage messageCommand = db.MessageCommands.Find(id);
            if (messageCommand != null)
                db.MessageCommands.Remove(messageCommand);
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
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
    public class MessageContext : DbContext
    {
        public MessageContext() : base("DefaultConnection")
        { }
        public DbSet<IMessage> MessageCommands { get; set; }
    }
}
