using Crud_WPF.DTO.Cliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud_WPF.Business.Interfaces
{
    public interface IClienteBusiness
    {
        Task<IEnumerable<List<ClienteDTO>>> ObterTodos(ClienteFiltroDTO filtros);
        Task<ClienteDTO> ObterPorId(int id);
        Task<ClienteDTO> ObterPorCpf(string cpf);
        Task<ClienteDTO> Incluir(ClienteDTO clienteDTO);
        Task<ClienteDTO> Alterar(ClienteDTO clienteDTO);
        Task<ClienteDTO> Remover(ClienteDTO clienteDTO);
    }
}
