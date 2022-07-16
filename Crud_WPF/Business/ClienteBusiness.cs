using Crud_WPF.Business.Interfaces;
using Crud_WPF.DTO.Cliente;
using Crud_WPF.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud_WPF.Business
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteBusiness(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<List<ClienteDTO>>> ObterTodos(ClienteFiltroDTO filtros)
        {
            return await _clienteRepository.ObterTodos(filtros);
        }
        public async Task<ClienteDTO> ObterPorId(int id)
        {
            return await _clienteRepository.ObterPorId(id);
        }
        public async Task<ClienteDTO> ObterPorCpf(string cpf)
        {
            return await _clienteRepository.ObterPorCpf(cpf);
        }
        public async Task<ClienteDTO> Incluir(ClienteDTO clienteDTO)
        {
            var clienteExiste = await ObterPorCpf(clienteDTO.Cpf);
            if (clienteExiste != null)
            {
                return clienteExiste;
            }

            clienteDTO.DataInclusao = DateTime.Now;
            clienteDTO.Cpf = clienteDTO.Cpf.Replace(".", "").Replace("-", "");

            return await _clienteRepository.IncluirDTOAsync(clienteDTO);
        }
        public async Task<ClienteDTO> Alterar(ClienteDTO clienteDTO)
        {
            var clienteExiste = await ObterPorId(clienteDTO.Id);
            if (clienteExiste != null)
            {
                return clienteExiste;
            }

            clienteDTO.DataAlteracao = DateTime.Now;
            clienteDTO.Cpf = clienteDTO.Cpf.Replace(".", "").Replace("-", "");

            return await _clienteRepository.AlterarDTOAsync(clienteDTO);
        }
        public async Task<ClienteDTO> Remover(ClienteDTO clienteDTO)
        {
            var clienteExiste = await ObterPorId(clienteDTO.Id);
            return await _clienteRepository.RemoverDTOAsync(clienteDTO);
        }

    }
}
