using Microsoft.EntityFrameworkCore;

namespace Interview.BusinessLogic.Common
{
    public sealed class ContextFactory
    {
        private readonly string _connectionString;

        public ContextFactory(CommandsConnectionString connectionString)
        {
            _connectionString = connectionString.Value;
        }

        internal DbContext CreateContext()
        {
            return new OrdersContext(_connectionString);
        }
    }
}
