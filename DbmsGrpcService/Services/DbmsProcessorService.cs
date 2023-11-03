using DbmsGrpc;
using Grpc.Core;

namespace DbmsGrpc.Services
{
    public class DbmsProcessorService : DbmsProcessor.DbmsProcessorBase
    {
        private readonly ILogger<DbmsProcessorService> _logger;
        public DbmsProcessorService(ILogger<DbmsProcessorService> logger)
        {
            _logger = logger;
        }

        
    }
}