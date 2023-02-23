using CQRS.core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.core.Infrastructure
{
    public interface ICommandDispatcher
    {
        public  void RegisterHandler<T>(Func<T, Task> handler) where T : BaseCommand;

        public Task SendAsync(BaseCommand command);    
    }
}
