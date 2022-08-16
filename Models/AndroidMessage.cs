using GlobalMonService.Services;
using System.ComponentModel.DataAnnotations;

namespace GlobalMonService.Models
{
    public sealed class AndroidMessage:IMessage
    {
        public AndroidMessage(string pushToken, string title, string body, int priority = 10, string? action = "notification")
        {
            PushToken = string.IsNullOrEmpty(pushToken) ? throw new ArgumentNullException(nameof(pushToken)) : pushToken;
            Title = string.IsNullOrEmpty(title) ? throw new ArgumentNullException(nameof(title)) : title;
            Body = string.IsNullOrEmpty(body) ? throw new ArgumentNullException(nameof(body)) : body;
            Priority = priority;
            Action = action;
        }
        public int Id { get; set; }
        [Required]
        [StringLength(152)]
        public string PushToken { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        [StringLength(2000)]
        public string Body { get; set; }
        [Required]
        public int Priority { get; set; }
        [StringLength(64)]
        public string? Action { get; set; }
        public override string ToString()
            => $"PushToken: {PushToken}{Environment.NewLine}Title: {Title}{Environment.NewLine}Body: {Body}{Environment.NewLine}Priority: {Priority}{Environment.NewLine}Action: {Action}";
    }
}
