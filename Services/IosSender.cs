using GlobalMonService.Models;

namespace GlobalMonService.Services
{
    internal sealed class IosSender : ISender<IosMessage>
    {
        private readonly object _lockObject = new();
        private static int _countSend;

        public async Task<SendResponse> Send(IosMessage message)
        {
            var random = new Random();
            await Task.Delay(random.Next(500, 2000));

            lock (_lockObject)
            {
                var idMessage = $"{Guid.NewGuid()}";
                if (_countSend == 5)
                {
                    _countSend = 0;
                    Console.WriteLine($"{nameof(IosSender)} [FAILED SEND MESSAGE] {idMessage}{Environment.NewLine}{message}");
                    return new SendResponse(idMessage, "Не доставлено");
                }

                _countSend++;
                Console.WriteLine($"{nameof(IosSender)} [SUCCESS SEND MESSAGE] {idMessage}{Environment.NewLine}{message}");
                return new SendResponse(idMessage, "Доставлено");
            }
        }
    }
}
