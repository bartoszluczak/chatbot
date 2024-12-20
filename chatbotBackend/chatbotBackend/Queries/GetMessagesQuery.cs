using chatbotBackend.Models;
using MediatR;

namespace chatbotBackend.Queries
{
    public class GetMessagesQuery: IRequest<List<Message>>
    {
    }
}
