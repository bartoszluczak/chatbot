using chatbotBackend.Models;
using MediatR;

namespace chatbotBackend.Commands
{
    public class StreamResponseCommand : IStreamRequest<string>
    {
        public Message Message { get; }

        public StreamResponseCommand(Message message)
        {
            Message = message;
        }
    }
}
