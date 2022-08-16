using GlobalMonService.Services;
using System.ComponentModel.DataAnnotations;

namespace GlobalMonService.Models
{
    public sealed class IosMessage:IMessage
    {
        public IosMessage(string deviceToken, string message, string title, string? badge = null)
        {
            DeviceToken = string.IsNullOrEmpty(deviceToken) ? throw new ArgumentNullException(nameof(deviceToken)) : deviceToken;
            Message = string.IsNullOrEmpty(message) ? throw new ArgumentNullException(nameof(message)) : message;
            Title = string.IsNullOrEmpty(title) ? throw new ArgumentNullException(nameof(title)) : title;
            Badge = badge;                 
        }
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string DeviceToken{get;set;}
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        [StringLength(2000)]
        public string Message { get; set; }
        [Required]
        [StringLength(2000)]
        public string? Badge { get; set; }
        public override string ToString()
            => $"DeviceToken: {DeviceToken}{Environment.NewLine}Title: {Title}{Environment.NewLine}Message: {Message}{Environment.NewLine}Badge: {Badge}";
    }
}
