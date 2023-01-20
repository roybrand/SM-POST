using CQRS.core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class DeletePostCommand : BaseCommand
    {
        public string UserName { get; set; }
    }
}
