using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
   public interface ICliente
   {
        IEnumerable<ClienteModel> listar();
        ClienteModel consultar(int id);
        bool agregar(ClienteModel cliente);
        bool modificar(ClienteModel cliente);
        bool eliminar(int id);
    }
}
