namespace GlobalMonService.Services
{
    internal interface IMessageStatusDb
    {
        void SaveMessageStatus(string messageId, string status);
        string? GetMessageStatus(string messageId);
    }
}
