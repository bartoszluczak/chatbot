using System.Runtime.CompilerServices;
using chatbotBackend.Models;

namespace chatbotBackend.Repositories
{
    public interface IMessageRepository
    {
        public Task<List<Message>> GetMessagesListAsync();
        public Task<Message> GetMessageByIdAsync(string id);
        public Task<Message> SendMessageAsync(Message message);
        public Task<int> UpdateMessageMarkAsync(Message message);
        IAsyncEnumerable<string> StreamResponse(Message message, CancellationToken cancellationToken);
    }
}
