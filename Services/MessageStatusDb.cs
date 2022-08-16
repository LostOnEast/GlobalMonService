using Microsoft.Extensions.Caching.Memory;

namespace GlobalMonService.Services
{
    internal sealed class MessageStatusDb : IMessageStatusDb
    {
        private readonly IMemoryCache _memoryCache;

        public MessageStatusDb(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void SaveMessageStatus(string messageId, string status) => _memoryCache.Set(messageId, status, TimeSpan.FromHours(8));

        public string? GetMessageStatus(string messageId) => _memoryCache.TryGetValue(messageId, out string status) ? status : null;
    }
}
