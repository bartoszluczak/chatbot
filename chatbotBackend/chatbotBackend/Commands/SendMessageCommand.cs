using chatbotBackend.Models;
using MediatR;

namespace chatbotBackend.Commands
{
    public class SendMessageCommand: IRequest<Message>
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string Role { get; set; }
        public string Mark {  get; set; }
        public string ConversationId { get; set; }
        public DateTime Timestamp { get; set; }

        public SendMessageCommand(string id, string content, string role, string mark, string conversationId, DateTime timestamp)
        {
            Id = id;
            Content = content;
            Role = role;
            Mark = mark;
            ConversationId = conversationId;
            Timestamp = timestamp;

        }
    }
}
    