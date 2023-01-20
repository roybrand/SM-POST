using CQRS.core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class AddCommentCommand : BaseCommand
    {
        public Guid Comment { get; set; }

        public string UserName { get; set; }
    }
}
