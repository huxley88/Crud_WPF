using Crud_WPF.DTO.Cliente;
using Crud_WPF.Services.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _clienteServices;

        public ClienteController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpPost]
        public async Task<IActionResult> ObterTodos([FromBody] ClienteFiltroDTO filtros)
        {
            try
            {
                return Ok(await _clienteServices.ObterTodos(filtros));
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                return Ok(await _clienteServices.ObterPorId(id));
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }

        }

        [HttpGet]
        [Route("cpf")]
        public async Task<IActionResult> ObterPorCpf(string cpf)
        {
            try
            {
                return Ok(await _clienteServices.ObterPorCpf(cpf));
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }

        }

        [HttpPost]
        [Route("incluir")]
        public async Task<IActionResult> Post([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                return Ok(await _clienteServices.Incluir(clienteDTO));
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("excel")]
        public async Task<IActionResult> GerarExcel([FromBody] List<ClienteDTO> clientesDTO)
        {
            try
            {
                return Ok(await _clienteServices.GerarExcel(clientesDTO));
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("consumirClientes")]
        public async Task<IActionResult> ConsumirClientes()
        {
            try
            {
                return Ok(await _clienteServices.ConsumirClientes());
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }

        }

        [HttpPost]
        [Route("importarClientes")]
        public async Task<IActionResult> ImportarClientes([FromBody]string arquivo)
        {
            try
            {
                return Ok(await _clienteServices.ImportarClientes(arquivo));
            }

            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("alterar")]
        public async Task<IActionResult> Put([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                return Ok(await _clienteServices.Alterar(clienteDTO));
            }

            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }

        }

        [HttpDelete]
        [Route("excluir")]
        public async Task<IActionResult> Delete([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                return Ok(await _clienteServices.Remover(clienteDTO));
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}
