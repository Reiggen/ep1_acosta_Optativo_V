using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class FacturaService
    {
        private FacturaRepository facturaRepository;

        public FacturaService(string connectionString)
        {
            facturaRepository = new FacturaRepository(connectionString);
        }

        public bool Agregar(FacturaModel modelo)
        {
            if (ValidarFactura(modelo))
            {
                CalcularTotales(modelo);
                return facturaRepository.Agregar(modelo);
            }
            else
            {
                return false;
            }
        }

        public bool Modificar(FacturaModel modelo)
        {
            if (ValidarFactura(modelo))
            {
                CalcularTotales(modelo);
                return facturaRepository.Modificar(modelo);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id)
        {
            return facturaRepository.Eliminar(id);
        }

        public FacturaModel Consultar(int id)
        {
            try
            {
                return facturaRepository.Consultar(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la factura.", ex);
            }
        }

        public IEnumerable<FacturaModel> Listar()
        {
            return facturaRepository.Listar();
        }

        private bool ValidarFactura(FacturaModel factura)
        {
            // Implementa la lógica de validación aquí
            return true;
        }

        private void CalcularTotales(FacturaModel factura)
        {
            factura.total_iva = factura.total_iva5 + factura.total_iva10;
            factura.total = (int)((factura.total_iva5 / 0.05) + (factura.total_iva10 / 0.1)) + factura.total_iva;
        }
    }
}
