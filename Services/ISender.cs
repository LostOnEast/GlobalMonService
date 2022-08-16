namespace GlobalMonService.Services
{
    internal interface ISender<in T> where T : IMessage
    {
        Task<SendResponse> Send(T message);
    }
    public interface IMessage
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
