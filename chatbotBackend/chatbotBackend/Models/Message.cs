namespace chatbotBackend.Models
{
    public class Message
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public string Content { get; set; }
        public string Mark {  get; set; }
        public string ConversationId { get; set; }
        public DateTime Timestamp { get; set; }

    }
}