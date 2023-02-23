using CQRS.core.Domain;
using Post.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Cmd.Domain.aggregates
{
    public class PostAggregate: AggregateRoot
    {
        private bool _active;

        private string _author;

        private readonly Dictionary<Guid, Tuple<string, string>> _comments = new();

        public bool Active
        {
            get => _active; set => _active = value;     
        }

        public PostAggregate() { }

        public PostAggregate(Guid id, string author,string message)
        {
            RaiseEvent(new PostCreatedEvent
            {
                
                Id = id,
                Author = author,
                Message = message,
                DatePosted = DateTime.Now

            });     

        }

        public void Apply(PostCreatedEvent @event)
        {
            _id = @event.Id;
            _active = true; 
            _author = @event.Author;    
        }

        public void EditMessage(string message)
        {
            if (!_active)
            {
                throw new InvalidOperationException("you cannot edit the message of inactive post");
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                throw new InvalidOperationException($"The value of  {nameof(message)} cannot be null or empty");
            }

            RaiseEvent(new MessageUpdatedEvent
            {
                Id = _id,   
                Message = message
            });
        }

        public void Apply (MessageUpdatedEvent @event)
        {
            _id = @event.Id;
        }

        public void LikePost()
        {
            if (!_active)
            {
                throw new InvalidOperationException("you cannot like an  inactive post");
            }

            RaiseEvent(new PostLikedEvent
            {
                Id = _id
            });
        }

            
    }
}
