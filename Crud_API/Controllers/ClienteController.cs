using Crud_WPF.DTO.Cliente;
using Crud_WPF.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize]
        public async Task<IActionResult> ObterTodos([FromBody] ClienteFiltroDTO filtros)
        {
            return Ok(await _clienteServices.ObterTodos(filtros));
        }

        [HttpGet]
        [Route("id")]
        [Authorize]
        public async Task<IActionResult> ObterPorId(int id)
        {
            return Ok(await _clienteServices.ObterPorId(id));
        }

        [HttpGet]
        [Route("cpf")]
        [Authorize]
        public async Task<IActionResult> ObterPorCpf(string cpf)
        {
            return Ok(await _clienteServices.ObterPorCpf(cpf));
        }

        [HttpPost]
        [Route("incluir")]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] ClienteDTO clienteDTO)
        {
            return Ok(await _clienteServices.Incluir(clienteDTO));
        }

        [HttpPut]
        [Route("alterar")]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] ClienteDTO clienteDTO)
        {
            return Ok(await _clienteServices.Alterar(clienteDTO));
        }

        [HttpDelete]
        [Route("excluir")]
        [Authorize]
        public async Task<IActionResult> Delete([FromBody] ClienteDTO clienteDTO)
        {
            return Ok(await _clienteServices.Remover(clienteDTO));
        }
    }
}
