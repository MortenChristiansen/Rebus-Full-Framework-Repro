using Rebus.Handlers;
using Rebus.Pipeline;
using System;
using System.Threading.Tasks;

namespace Repro.Rebus
{
    public class RebusEventHandler : IHandleMessages<Message>
    {
        private readonly IMessageContext _context;

        public RebusEventHandler(IMessageContext context)
        {
            _context = context;
        }

        public Task Handle(Message message)
        {
            Console.WriteLine($"Received Message in RebusEventHandler)");

            return Task.CompletedTask;
        }
    }
}