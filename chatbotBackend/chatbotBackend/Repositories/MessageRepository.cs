using System.Data;
using chatbotBackend.Data;
using chatbotBackend.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using NLipsum.Core;
using System.Runtime.CompilerServices;

namespace chatbotBackend.Repositories
{
    public class MessageRepository: IMessageRepository
    {
        private readonly DbContextClass _dbContext;
        private LipsumGenerator lipsumGenerator = new LipsumGenerator();
        public MessageRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Message>> GetMessagesListAsync()
        {
            return await _dbContext.Messages.ToListAsync();
        }

        public async Task<Message> GetMessageByIdAsync(string Id)
        {
            return await _dbContext.Messages.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<Message> SendMessageAsync(Message message)
        {
            _dbContext.Messages.Add(message);

            Random rnd = new Random();

            var paragraphOptions = new Paragraph() { MinimumSentences = 1, MaximumSentences = (uint)rnd.Next(1, 500) };
            var lp = lipsumGenerator.GenerateParagraphs(1, paragraphOptions).First();


            Guid uuid = Guid.NewGuid();
            var newMessage = new Message()
            {
                Id = uuid.ToString(),
                Content = lp,
                Role = "System",
                Mark = "",
                ConversationId = message.ConversationId,
                Timestamp = DateTime.Now
            };

            _dbContext.Messages.Add(newMessage);
            await _dbContext.SaveChangesAsync();

            return newMessage;
        }

        public async Task<int> UpdateMessageMarkAsync(Message message)
        {
            _dbContext.Messages.Update(message);
            return await _dbContext.SaveChangesAsync();
        }

        public async IAsyncEnumerable<string> StreamResponse(Message message, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            _dbContext.Messages.Add(message);

            Random rnd = new Random();
            var paragraphOptions = new Paragraph() { MinimumSentences = 1, MaximumSentences = (uint)rnd.Next(1, 500) };
            var lp = lipsumGenerator.GenerateSentences(100);

           
            foreach (string responseSentence in lp) {
      
                await Task.Delay(1000);
      
                yield return responseSentence; 
            }
        }
    }
}
