using GlobalMonService.Models;

namespace GlobalMonService.Services
{
    public sealed class SenderService : ISenderService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageStatusDb _messageStatusDb;

        public SenderService(IServiceProvider serviceProvider,
            IMessageStatusDb messageStatusDb)
        {
            _serviceProvider = serviceProvider;
            _messageStatusDb = messageStatusDb;
        }

        public async Task<SendResponse> Send(IMessage message)
        {
            var sendResponse = await SendAsync(message);
            _messageStatusDb.SaveMessageStatus(sendResponse.MessageId, sendResponse.Status);
            return sendResponse;
        }

        private Task<SendResponse> SendAsync<T>(T message) where T : IMessage
        {
            var method = typeof(SenderService).GetMethod(nameof(GenericSend));
            if (method == null)
                throw new Exception("Failed start service. Cannot register services");

            var generic = method.MakeGenericMethod(message.GetType());
            object[] args = { _serviceProvider, message };
            var result = generic.Invoke(null, args);
            return result as Task<SendResponse>;
        }

        public static Task<SendResponse> GenericSend<T>(IServiceProvider serviceProvider, T message) where T : IMessage
        {
            var sender = serviceProvider.GetRequiredService<ISender<T>>();
            return sender.Send(message);
        }

        public string? GetStatusMessage(string messageId) => _messageStatusDb.GetMessageStatus(messageId);
    }
    public static class SendServiceExtensions
    {
        public static IServiceCollection AddSendService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddTransient<IMessageStatusDb, MessageStatusDb>();
            serviceCollection.AddTransient<ISenderService, SenderService>();
            serviceCollection.AddTransient(typeof(ISender<IosMessage>), typeof(IosSender));
            serviceCollection.AddTransient(typeof(ISender<AndroidMessage>), typeof(AndroidSender));
            return serviceCollection;
        }
    }
}
