namespace GlobalMonService.Services
{
    public sealed class SendResponse
    {
        public SendResponse(string messageId, string status)
        {
            MessageId = messageId;
            Status = status;
        }

        public string MessageId { get; }
        public string Status { get; }
    }
}
