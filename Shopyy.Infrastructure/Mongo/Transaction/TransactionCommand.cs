using System;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Mongo.Transaction
{
    public class TransactionCommand
    {
        private Func<Task> _task;

        public async Task Execute() => await _task();

        public TransactionCommand(Func<Task> task)
        {
            _task = task;
        }

        public static implicit operator TransactionCommand(Func<Task> task)
        {
            return new TransactionCommand(task);
        }
    }
}
