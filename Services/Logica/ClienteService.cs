using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class ClienteService(string connectionString)
    {
        ClienteRepository clienteRepository = new ClienteRepository(connectionString);

        public bool Agregar(ClienteModel modelo)
        {
            if (validacionCliente(modelo))
                return clienteRepository.agregar(modelo);
            else
                return false;
        }

        public bool Modificar(ClienteModel modelo)
        {
            if (validacionCliente(modelo))
                return clienteRepository.modificar(modelo);
            else
                return false;
        }

        public bool Eliminar(int id)
        {
            return clienteRepository.eliminar(id);
        }

        public ClienteModel Consultar(int id)
        {
            try
            {
                return clienteRepository.consultar(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ClienteModel> Listar()
        {
            return clienteRepository.listar();
        }


        private bool validacionCliente(ClienteModel cliente)
        {
            if (cliente == null) 
                return false;
            if(string.IsNullOrEmpty(cliente.Nombre))
                return false;
            return true;
        }
    }
}
