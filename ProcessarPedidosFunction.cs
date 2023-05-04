using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Pedidos.Function
{
    public class ProcessarPedidosFunction
    {
        [FunctionName("ProcessarPedidosFunction")]
        public void Run([ServiceBusTrigger("pedidos", Connection = "SBTASBRA01_SERVICEBUS")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
