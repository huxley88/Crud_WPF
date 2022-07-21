using System.Threading.Tasks;

namespace Crud_WPF.RabbitMQConsumer
{
    public interface IRabbitMQConsumer
    {
        Task ConsumirClienteFila();
    }
}
