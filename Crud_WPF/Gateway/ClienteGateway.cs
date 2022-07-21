using Crud_WPF.DTO.Cliente;
using Crud_WPF.Gateway.HttpClientBase;
using Crud_WPF.Gateway.ServicesFactorysAPI;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Crud_WPF.Gateway.Classes
{
    public partial class ClienteGateway
    {
        private readonly ClienteFactoryAPI _ClienteFactoryAPI = new ClienteFactoryAPI();


        public async Task<List<ClienteDTO>> ObterTodos(ClienteFiltroDTO filtros)
        {
            var retornoAPI = await USEHttpClienteAPI.Current.EfetuarRequisicaoAPI<ClienteFiltroDTO, List<ClienteDTO>>(_ClienteFactoryAPI.ObterTodos(), filtros, HttpMethod.Post);
            if (retornoAPI == null || !retornoAPI.retornoRequisicaoSucesso)
                throw new Exception(retornoAPI.MensagemErro);

            return retornoAPI.retornoRequisicoAPI;
        }
        public async Task<ClienteDTO> ObterPorId(int id)
    {
            var retornoAPI = await USEHttpClienteAPI.Current.EfetuarRequisicaoGetAPI<ClienteDTO>(_ClienteFactoryAPI.ObterPorId(id));

            if (retornoAPI == null || !retornoAPI.retornoRequisicaoSucesso)
                throw new Exception(retornoAPI.MensagemErro);

            return retornoAPI.retornoRequisicoAPI;
        }
        public async Task<bool> ComsumirClientes()
        {
            var retornoAPI = await USEHttpClienteAPI.Current.EfetuarRequisicaoGetAPI<string>(_ClienteFactoryAPI.ConsumirClientes());


            if (retornoAPI == null || !retornoAPI.retornoRequisicaoSucesso)
                throw new Exception(retornoAPI.MensagemErro);

            return true;
        }
        public async Task<bool> ImportarClientes(string arquivo)
        {
            var retornoAPI = await USEHttpClienteAPI.Current.EfetuarRequisicaoAPI<string, string>(_ClienteFactoryAPI.ImportarClientes(), arquivo, HttpMethod.Post);


            if (retornoAPI == null || !retornoAPI.retornoRequisicaoSucesso)
                throw new Exception(retornoAPI.MensagemErro);

            return true;
        }
        public async Task<ClienteDTO> Incluir(ClienteDTO Cliente)
        {
            var retornoAPI = await USEHttpClienteAPI.Current.EfetuarRequisicaoAPI<ClienteDTO, ClienteDTO>(_ClienteFactoryAPI.Incluir(), Cliente, HttpMethod.Post);

            if (retornoAPI == null || !retornoAPI.retornoRequisicaoSucesso)
                throw new Exception(retornoAPI.MensagemErro);

            return retornoAPI.retornoRequisicoAPI;
        }
        public async Task<List<ClienteDTO>> GerarExcel(List<ClienteDTO> Clientes)
        {
            var retornoAPI = await USEHttpClienteAPI.Current.EfetuarRequisicaoAPI<List<ClienteDTO>, List<ClienteDTO>>(_ClienteFactoryAPI.GerarExcel(), Clientes, HttpMethod.Post);

            if (retornoAPI == null || !retornoAPI.retornoRequisicaoSucesso)
                throw new Exception(retornoAPI.MensagemErro);

            return retornoAPI.retornoRequisicoAPI;
        }
        public async Task<ClienteDTO> Alterar(ClienteDTO Cliente)
        {
            var retornoAPI = await USEHttpClienteAPI.Current.EfetuarRequisicaoAPI<ClienteDTO, ClienteDTO>(_ClienteFactoryAPI.Alterar(), Cliente, HttpMethod.Put);

            if (retornoAPI == null || !retornoAPI.retornoRequisicaoSucesso)
                throw new Exception(retornoAPI.MensagemErro);

            return retornoAPI.retornoRequisicoAPI;
        }
        public async Task<ClienteDTO> Remover(ClienteDTO Cliente)
        {
            var retornoAPI = await USEHttpClienteAPI.Current.EfetuarRequisicaoAPI<ClienteDTO, ClienteDTO>(_ClienteFactoryAPI.Excluir(), Cliente, HttpMethod.Delete);

            if (retornoAPI == null || !retornoAPI.retornoRequisicaoSucesso)
                throw new Exception(retornoAPI.MensagemErro);

            return retornoAPI.retornoRequisicoAPI;
        }

    }
}
