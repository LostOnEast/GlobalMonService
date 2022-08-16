using GlobalMonService.Models;

namespace GlobalMonService.Services
{
    public interface IMessageSenderService
    {
       

        Task<SendResponse> Send(IMessage message);
        string? GetStatusMessage(int messageId);

    }
}
