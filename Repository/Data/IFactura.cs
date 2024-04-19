using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public interface IFactura
    {
        IEnumerable<FacturaModel> Listar();
        FacturaModel Consultar(int id);
        bool Agregar(FacturaModel factura);
        bool Modificar(FacturaModel factura);
        bool Eliminar(int id);
    }
}
