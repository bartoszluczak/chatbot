using chatbotBackend.Models;
using MediatR;

namespace chatbotBackend.Queries
{
    public class GetMessageByIdQuery: IRequest<Message>
    {
        public string Id { get; set; }
    }
}
