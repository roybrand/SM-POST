using CQRS.core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Common.Events
{
    public class CommentUpdatedEvent : BaseEvent
    {
        protected CommentUpdatedEvent() : base(nameof(CommentUpdatedEvent))
        {
        }

        public Guid CommentId { get; set; }   
        public string Comment { get; set; }

        public string UserName { get; set; }

        public DateTime EditDate { get; set; }


    }
}
