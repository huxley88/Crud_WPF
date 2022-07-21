using Crud_WPF.DTO.Cliente;
using Crud_WPF.Repository.Interfaces;
using Crud_WPF.Services.Interfaces;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Crud_WPF.RabbitMQConsumer
{
    public class RabbitMQConsumer : IRabbitMQConsumer
    {
        private ILogger _logger;
        private IConnection _connection;
        private IModel _channel;
        private const string ClienteQueure = "clientesQueue";
        private readonly IClienteRepository _clienteRepository;


        public RabbitMQConsumer(ILogger<RabbitMQConsumer> logger, IClienteRepository clienteRepository)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            _logger = logger;
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(ClienteQueure, ExchangeType.Direct);
            _clienteRepository = clienteRepository;
        }

        public async Task ConsumirClienteFila()
        {
            try
            {
                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += (chanel, evt) =>
                {
                    try
                    {
                       var content = Encoding.UTF8.GetString(evt.Body.ToArray());

                        if (!string.IsNullOrEmpty(content))
                        {
                            List<ClienteDTO> clientes = JsonSerializer.Deserialize<List<ClienteDTO>>(content);
                            GravarClientes(clientes).GetAwaiter().GetResult();
                            _channel.BasicAck(evt.DeliveryTag, false);
                        }
                    }

                    catch (System.Exception ex)
                    {
                        _logger.LogError("Erro ao deserializar cliente", ex);
                        _channel.BasicNack(evt.DeliveryTag, false, true);
                    }
                };
                _channel.BasicConsume(ClienteQueure, false, consumer);
            }

            catch (System.Exception ex)
            {
                _logger.LogError("Erro ao consumir cliente da fila", ex);
                throw;
            }
        }

        public async Task GravarClientes(List<ClienteDTO> clientes)
        {
            await _clienteRepository.ImportarClientes(clientes);
        }
    }
}