using chatbotBackend.Models;
using chatbotBackend.Queries;
using chatbotBackend.Repositories;
using MediatR;

namespace chatbotBackend.Handlers
{
    public class GetMessagesListHandler: IRequestHandler<GetMessagesQuery, List<Message>>
    {
        private readonly IMessageRepository _messageRepository;

        public GetMessagesListHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<List<Message>> Handle(GetMessagesQuery query, CancellationToken cancellationToken)
        {
            return await _messageRepository.GetMessagesListAsync();
        }
    }

}
    