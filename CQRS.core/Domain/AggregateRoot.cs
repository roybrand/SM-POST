using CQRS.core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.core.Domain
{
    
    public abstract  class AggregateRoot
    {
        protected Guid _id;

        private readonly List<BaseEvent> _changes = new();

        public Guid Id
        {
            get { return _id; } 
        }

        public int Version { get; set; } = -1;

        public IEnumerable<BaseEvent> GetUnCommitedChanges()
        {
            return _changes;    
        }

        public void MarkChanchesAsCommited()
        {
            _changes.Clear();
        }

        private void ApplyChange(BaseEvent @event, bool isNew)
        {
            var method = this.GetType().GetMethod("Apply", new Type[] { @event.GetType() });

            if(method == null)
            {
                throw new ArgumentNullException(nameof(method), $"The apply method wasnt found in the aggregate for{@event.GetType().Name}");
            }

            method.Invoke(this, new object[] { @event }); 
            
            if(isNew)
            {
                _changes.Add(@event);   
            }
        }  

        protected void RaiseEvent(BaseEvent @event)
        {
            ApplyChange(@event, true);
        }

        public void ReplayEvents(IEnumerable<BaseEvent> events)
        {
            foreach(var @event in events)
            {
                ApplyChange(@event,false);
            } 
        }

    }
}
