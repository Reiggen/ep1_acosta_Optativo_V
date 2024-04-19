using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Services.Logica;

namespace ExamenParcial.Controllers
{
    public class FacturaController : Controller
    {
        private FacturaService facturaService;

        public FacturaController(IConfiguration configuration)
        {
            facturaService = new FacturaService(configuration.GetConnectionString("postgres"));
        }

        [HttpGet("ListarFacturas")]
        public ActionResult<IEnumerable<FacturaModel>> ListarFacturas()
        {
            var facturas = facturaService.Listar();
            return Ok(facturas); 
        }

        [HttpGet("ConsultarFactura/{id}")]
        public ActionResult<FacturaModel> ConsultarFactura(int id)
        {
            var factura = facturaService.Consultar(id);
            if (factura == null)
            {
                return NotFound(); 
            }
            return Ok(factura);
        }

        [HttpPost("AgregarFactura")]
        public ActionResult AgregarFactura(FacturaModel factura)
        {
            facturaService.Agregar(factura);
            return Ok(); 
        }   

        [HttpPut("ModificarFactura")]
        public ActionResult ModificarFactura(FacturaModel factura)
        {
            facturaService.Modificar(factura);
            return Ok(); 
        }

        [HttpDelete("EliminarFactura/{id}")]
        public ActionResult EliminarFactura(int id)
        {
            facturaService.Eliminar(id);
            return Ok(); 
        }
    }
}

