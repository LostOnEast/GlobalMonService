namespace GlobalMonService.Services
{
    public interface ISenderService
    {
        Task<SendResponse> Send(IMessage message);
        string? GetStatusMessage(string messageId);
    }
}