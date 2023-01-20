using CQRS.core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.core.Events
{
    public class BaseEvent : Message
    {
        protected BaseEvent(string type)
        {
            this.Type = type;
        }
            
        public int Version { get; set; }

        public string Type { get; set; }


    }
}
