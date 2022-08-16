namespace GlobalMonService.Services
{
    public interface IMessageStatusDb
    {
        void SaveMessageStatus(string messageId, string status);
        string? GetMessageStatus(string messageId);
    }
}
