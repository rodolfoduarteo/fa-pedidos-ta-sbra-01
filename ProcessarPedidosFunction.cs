using System.Threading.Tasks;
using Func.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Services;

namespace Func.PedidosFunction
{
    public class ProcessarPedidosFunction
    {
        private readonly NotificationService _notificationService;
        public ProcessarPedidosFunction(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [FunctionName("ProcessarPedidosFunction")]
        public async Task ProcessarPedido([ServiceBusTrigger("pedidos", Connection = "SBTASBRA01_SERVICEBUS")]Pedido pedido, ILogger log)
        {
            await _notificationService.NotifyAsync("Loja Azure", $"[FUNC] Olá {pedido.Cliente}, seu pedido {pedido.Numero} foi processado e está em separação no estoque!");
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {pedido.Numero}");
        }
    }
}
