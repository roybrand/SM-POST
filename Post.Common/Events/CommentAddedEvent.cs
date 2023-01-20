using CQRS.core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Common.Events
{
    public class CommentAddedEvent : BaseEvent
    {
        public CommentAddedEvent() : base(nameof(CommentAddedEvent))
        {
        }

        public Guid CommentID { get; set; }

        public string Comment { get; set; }

        public string UserName { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
