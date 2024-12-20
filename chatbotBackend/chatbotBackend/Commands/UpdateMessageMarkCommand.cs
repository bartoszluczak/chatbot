using MediatR;

namespace chatbotBackend.Commands
{
    public class UpdateMessageMarkCommand: IRequest<int>
    {
        public string Id {  get; set; }
        public string Mark { get; set; }

        public UpdateMessageMarkCommand(string id, string mark)
        {
            Id = id;
            Mark = mark;

        }
    }
}
