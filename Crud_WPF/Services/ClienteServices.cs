using Crud_WPF.Business.Interfaces;
using Crud_WPF.DTO.Cliente;
using Crud_WPF.Interfaces;
using Crud_WPF.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud_WPF.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteBusiness _clienteBusiness;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteServices(IClienteBusiness clienteBusiness, IUnitOfWork unitOfWork)
        {
            _clienteBusiness = clienteBusiness;
            _unitOfWork = unitOfWork;
        }

        public async Task<ClienteDTO> Incluir(ClienteDTO clienteDTO)
        {
            return await _clienteBusiness.Incluir(clienteDTO);
        }

        public async Task<ClienteDTO> Alterar(ClienteDTO clienteDTO)
        {
            return await _clienteBusiness.Alterar(clienteDTO);
        }

        public async Task<ClienteDTO> Remover(ClienteDTO clienteDTO)
        {
            return await _clienteBusiness.Remover(clienteDTO);
        }

        public async Task<ClienteDTO> ObterPorId(int id)
        {
            return await _clienteBusiness.ObterPorId(id);
        }

        public async Task<ClienteDTO> ObterPorCpf(string cpf)
        {
            return await _clienteBusiness.ObterPorCpf(cpf);
        }
        public async Task<IEnumerable<List<ClienteDTO>>> ObterTodos(ClienteFiltroDTO filtros)
        {
            return await _clienteBusiness.ObterTodos(filtros);
        }
    }
}
