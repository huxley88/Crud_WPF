using Crud_WPF.DTO.Cliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud_WPF.Repository.Interfaces
{
    public interface IClienteRepository 
    {
        Task<IEnumerable<List<ClienteDTO>>> ObterTodos(ClienteFiltroDTO filtros);
        Task<ClienteDTO> ObterPorId(int id);
        Task<ClienteDTO> ObterPorCpf(string cpf);
        Task<ClienteDTO> IncluirDTOAsync(ClienteDTO cliente);
        Task<ClienteDTO> AlterarDTOAsync(ClienteDTO cliente);
        Task<ClienteDTO> RemoverDTOAsync(ClienteDTO cliente);
    }
}
