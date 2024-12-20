using System.Data;
using chatbotBackend.Commands;
using chatbotBackend.Repositories;
using MediatR;

namespace chatbotBackend.Handlers
{
    public class UpdateMessageMarkHandler: IRequestHandler<UpdateMessageMarkCommand, int>
    {
        private readonly IMessageRepository _messageRepository;

        public UpdateMessageMarkHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<int> Handle(UpdateMessageMarkCommand command, CancellationToken cancellationToken)
        {
            var messageDetails = await _messageRepository.GetMessageByIdAsync(command.Id);
            if (messageDetails == null)
                return default;

            messageDetails.Mark = command.Mark;

            return await _messageRepository.UpdateMessageMarkAsync(messageDetails);
        }
    }
}
