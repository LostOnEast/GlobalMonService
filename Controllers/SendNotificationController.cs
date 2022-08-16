using GlobalMonService.Models;
using GlobalMonService.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMonService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendNotificationController : ControllerBase
    {
      
        private readonly ILogger<SendNotificationController> _logger;
        private readonly IMessageSenderService _messageSender;

        public SendNotificationController(ILogger<SendNotificationController> logger, IMessageSenderService messageSender)
        {
            _logger = logger;
            _messageSender = messageSender;
        }

        [HttpGet(Name = "MessageResult")]
        public string Get(IMessage message)
        {         
            return _messageSender.GetStatusMessage(message.Id); ;
        }
        [HttpPost(Name = "SendNotification")]
        public Task<SendResponse> Post(IMessage messageCommand)
        { 
            return _messageSender.Send(messageCommand);
        }
    }
}