using Crud_WPF.DTO.Cliente;
using System.Collections.Generic;

namespace Crud_WPF.RabbitMQSender
{
    public interface IRabbitMQSender
    {
        void EnviarClienteFila(List<ClienteDTO> cleintes, string queueName);
    }
}
