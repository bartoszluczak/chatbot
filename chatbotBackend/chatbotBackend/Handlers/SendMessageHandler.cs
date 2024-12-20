using chatbotBackend.Commands;
using chatbotBackend.Models;
using chatbotBackend.Repositories;
using MediatR;

namespace chatbotBackend.Handlers
{
    public class SendMessageHandler : IRequestHandler<SendMessageCommand, Message>
    {
        private readonly IMessageRepository _messageRepository;

        public SendMessageHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Message> Handle(SendMessageCommand command, CancellationToken cancellationToken)
        {
            var newMessage = new Message()
            {
                Id = command.Id,
                Content = command.Content,
                Role = command.Role,
                Mark = command.Mark,
                ConversationId = command.ConversationId,
                Timestamp = command.Timestamp,
            };

            return await _messageRepository.SendMessageAsync(newMessage);
        }

    }
}
