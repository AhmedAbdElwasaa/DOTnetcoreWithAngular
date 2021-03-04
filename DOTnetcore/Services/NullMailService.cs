using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTnetcore.Services
{
    public class NullMailService : IMailService
    {
        private readonly ILogger _logger;

        public NullMailService(ILogger<NullMailService> logger)
        {
            _logger = logger;
        }
        public void SendMessage(string reciver,string subject,string body)
        {
            _logger.LogInformation($"To: {reciver} Subject: {subject} Body: {body}");
        }
    }
}
