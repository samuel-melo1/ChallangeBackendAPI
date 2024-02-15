using BackendChallengeApi.Core.Model;
using BackendChallengeApi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using BackendChallengeApi.Core.DTO;

namespace BackendChallengeApi.Controllers
{

    [ApiController]
    [Route("/api/v1/")]
    public class ClienteController : ControllerBase
    {

        private ClientService _clientService;

        public ClienteController(ClientService clientService)
        {
            this._clientService = clientService;
        } 

        [HttpPost("/salvar")]
        public async Task<IActionResult> SaveCliente([FromBody] ClienteDTO clienteDTO)
        {
            var cliente = new Cliente
             {
                Name = clienteDTO.Name,
                Cnpj = clienteDTO.Cnpj,
                Endereco = clienteDTO.Endereco,
                Telefone = clienteDTO.Telefone
            };

            return Ok(await _clientService.SaveCliente(cliente));  
        }

        [HttpGet("/buscarClientes")]
        public async Task<IActionResult> ListClientes()
        {
            return Ok(await _clientService.GetAllClientes()); 
        }

        [HttpDelete("/deleteCliente/{id_client}")]
        public async Task<IActionResult> DeleteCliente([FromRoute] int id_client)
        {
            Boolean deleteCliente = await _clientService.RemoveClienteAsync(id_client);
            return Ok(deleteCliente); 
        }

        [HttpPut("/editClientes/{id_client}")]
        public async Task<IActionResult> EditarCliente([FromRoute] int id_client, [FromBody] ClienteDTO clienteDTO)
        {
            var cliente_atualizado = new Cliente
            {
                Name = clienteDTO.Name,
                Cnpj = clienteDTO.Cnpj,
                Endereco = clienteDTO.Endereco,
                Telefone = clienteDTO.Telefone
            };

             await _clientService.EditarCliente(id_client, cliente_atualizado);
             return Ok(cliente_atualizado); 
        }

        [HttpGet("/buscarCliente/{id_client}")]
        public async Task<IActionResult> BuscarClienteID([FromRoute] int id_client)
        {
           
            return Ok(await _clientService.BuscarPorCodigo(id_client));
        }

    }
}
