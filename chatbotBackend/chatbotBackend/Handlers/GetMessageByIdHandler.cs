using chatbotBackend.Models;
using chatbotBackend.Queries;
using chatbotBackend.Repositories;
using MediatR;

namespace chatbotBackend.Handlers
{
    public class GetMessageByIdHandler: IRequestHandler<GetMessageByIdQuery, Message>
    {
        private readonly IMessageRepository _messageRepository;

        public GetMessageByIdHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Message> Handle(GetMessageByIdQuery query, CancellationToken cancellationToken)
        {
            return await _messageRepository.GetMessageByIdAsync(query.Id);
        }
    }
}
