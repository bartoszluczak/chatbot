using chatbotBackend.Commands;
using chatbotBackend.Models;
using chatbotBackend.Repositories;
using MediatR;

namespace chatbotBackend.Handlers
{
    public class StreamResponseHandler: IStreamRequestHandler<StreamResponseCommand, string>
    {
        private readonly IMessageRepository _messageRepository;

        public StreamResponseHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IAsyncEnumerable<string> Handle(StreamResponseCommand command, CancellationToken cancellationToken)
        {
            return _messageRepository.StreamResponse(command.Message, cancellationToken);
        }
    }
}
