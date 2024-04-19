using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.Data;
using Services.Logica;

namespace ExamenParcial.Controllers
{
    public class ClienteController(IConfiguration configuration) : Controller
    {
        private ClienteService clienteService = new ClienteService(configuration.GetConnectionString("postgres"));

    [HttpGet("Listar")]
    public ActionResult<IEnumerable<ClienteModel>> ListarClientes()
    {
        var clientes = clienteService.Listar();
        return Ok(clientes); 
    }

    [HttpGet("Consultar Cliente /{id}")]
    public ActionResult<ClienteModel> ConsultarCliente(int id)
    {
        var cliente = clienteService.Consultar(id);
        if (cliente == null)
        {
            return NotFound(); 
        }
        return Ok(cliente);
    }

    [HttpPost("Agregar Cliente")]
        public ActionResult agregar(Repository.Data.ClienteModel cliente)
        {
            clienteService.Agregar(cliente);
            return Ok(); 
        }   

    [HttpPut("Modificar Cliente")]
        public ActionResult ModificarCliente(ClienteModel cliente)
        {
            clienteService.Modificar(cliente);
            return Ok(); 
        }

        [HttpDelete("Eliminar Cliente/ {id}")]
        public ActionResult EliminarCliente(int id)
        {
            clienteService.Eliminar(id);
            return Ok(); 
        }
    }
}
