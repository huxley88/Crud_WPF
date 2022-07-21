using Crud_WPF.DTO.Cliente;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Crud_WPF.RabbitMQSender
{
    public class RabbitMQSender : IRabbitMQSender
    {
        private readonly ILogger<RabbitMQSender> _logger;
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;

        public RabbitMQSender(ILogger<RabbitMQSender> logger)
        {
            _logger = logger;
            _hostName = "localhost";
            _password = "guest";
            _userName = "guest";
        }

        public void EnviarClienteFila(List<ClienteDTO> clientes, string queueName)
        {
            if (VerificaConexao())
            {
                try
                {
                    var channel = _connection.CreateModel();
                    channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
                    byte[] body = ObterMensagemByteArray(clientes);
                    channel.BasicPublish(
                        exchange: "", routingKey: queueName, basicProperties: null, body: body);
                }
                catch (System.Exception ex)
                {
                    _logger.LogError("Erro ao incluir clientes na fila", ex);
                    throw;
                }
            }
        }

        private byte[] ObterMensagemByteArray(List<ClienteDTO> clientes)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            var json = JsonSerializer.Serialize<List<ClienteDTO>>((List<ClienteDTO>)clientes, options);
            var body = Encoding.UTF8.GetBytes(json);
            return body;
        }

        private void CriarConexao()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostName,
                    UserName = _userName,
                    Password = _password
                };
                _connection = factory.CreateConnection();
            }
            catch (System.Exception ex)
            {
                _logger.LogError("Erro ao criar conexão", ex);
                throw;
            }
        }

        private bool VerificaConexao()
        {
            if (_connection != null) return true;
            CriarConexao();
            return _connection != null;
        }
    }
}
