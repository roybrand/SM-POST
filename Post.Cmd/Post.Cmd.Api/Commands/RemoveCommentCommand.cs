﻿using CQRS.core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class RemoveCommentCommand :BaseCommand
    {
        public Guid CommentId { get; set; }
        public string UserName { get; set; } 
    }
}
