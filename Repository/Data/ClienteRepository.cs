using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Repository.Data
{
    public class ClienteRepository : ICliente
    {
        private IDbConnection conexionDB;

        public ClienteRepository(string connectionString)
        {
            conexionDB = new DbConection(connectionString).dbConnection();
        }
        public bool agregar(ClienteModel cliente)
        {
            try
            {
                if (conexionDB.Execute("INSERT INTO cliente(nombre, apellido, documento, mail, celular, estado)" +
                                      "VALUES (@nombre, @apellido, @documento, @mail, @celular, @estado)", cliente) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool modificar(ClienteModel cliente)
        {
            try
            {
                if (conexionDB.Execute("UPDATE cliente SET nombre = @nombre, apellido = @apellido, documento = @documento, " +
                                      "mail = @mail, celular = @celular, estado = @estado WHERE id = @id", cliente) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool eliminar(int id)
        {
            try
            {
                if (conexionDB.Execute("DELETE FROM cliente WHERE id = @id", new { id }) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteModel consultar(int id)
        {
            try
            {
                return conexionDB.QuerySingleOrDefault<ClienteModel>("SELECT * FROM cliente WHERE id = @id", new { id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ClienteModel> listar()
        {
            try
            {
                return conexionDB.Query<ClienteModel>("SELECT * FROM cliente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
