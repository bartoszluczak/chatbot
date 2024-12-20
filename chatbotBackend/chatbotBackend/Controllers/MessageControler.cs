using System.Data;
using System.Xml.Linq;
using chatbotBackend.Commands;
using chatbotBackend.Models;
using chatbotBackend.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace chatbotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageControler : ControllerBase
    {
        private readonly IMediator mediator;
        public MessageControler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Message>> GetMessagesListAsync()
        {
            var messages = await mediator.Send(new GetMessagesQuery());
            return messages;
        }

        [HttpPost]
        public async Task<Message> SendMessageAsync(Message message)
        {
            var messageDetails = await mediator.Send(new SendMessageCommand(
                message.Id,
                message.Content,
                message.Role,
                message.Mark,
                message.ConversationId,
                DateTime.Now
                ));

            return messageDetails;
        }

        [HttpPut]
        public async Task<int> UpdateMessageMarkAsync(Message message)
        {
            var isMessageMarkUpdated = await mediator.Send(new UpdateMessageMarkCommand(
              message.Id,
              message.Mark));

            return isMessageMarkUpdated;
        }

        [HttpPost]
        [Route("stream")]
        public IAsyncEnumerable<string> Stream(Message message, CancellationToken cancellationToken)
        {
           return mediator.CreateStream(new StreamResponseCommand(message), cancellationToken);
        }
    }
}
