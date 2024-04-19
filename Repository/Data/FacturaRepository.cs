using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace Repository.Data
{
    public class FacturaRepository : IFactura
    {
        private IDbConnection conexionDB;

        public FacturaRepository(string connectionString)
        {
            conexionDB = new DbConection(connectionString).dbConnection();
        }

        public bool Agregar(FacturaModel factura)
        {
            try
            {
                if (ValidarNumeroFactura(factura.nro_factura))
                {
                    if (conexionDB.Execute("INSERT INTO factura(id_cliente, nro_factura, fecha_hora, total, total_iva5, total_iva10, total_iva, total_letras, sucursal)" +
                                          "VALUES (@id_cliente, @nro_factura, @fecha_hora, @total, @total_iva5, @total_iva10, @total_iva, @total_letras, @sucursal)", factura) > 0)
                        return true;
                    else
                        return false;
                }
                else
                {
                    // El número de factura no cumple con el patrón especificado, puedes lanzar una excepción, loguear un error, o realizar alguna otra acción según tus necesidades
                    throw new ArgumentException("El número de factura no cumple con el patrón especificado.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Modificar(FacturaModel factura)
        {
            try
            {
                if (ValidarNumeroFactura(factura.nro_factura))
                {
                    if (conexionDB.Execute("UPDATE factura SET id_cliente = @id_cliente, nro_factura = @numero_factura, fecha_hora = @fecha_hora, total = @total, " +
                                          "total_iva5 = @total_iva5, total_iva10 = @total_iva10, total_iva = @total_tva, total_letras = @total_letras, sucursal = @sucursal " +
                                          "WHERE id = @Id", factura) > 0)
                        return true;
                    else
                        return false;
                }
                else
                {
                    // El número de factura no cumple con el patrón especificado, puedes lanzar una excepción, loguear un error, o realizar alguna otra acción según tus necesidades
                    throw new ArgumentException("El número de factura no cumple con el patrón especificado.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarNumeroFactura(string numeroFactura)
        {
            // Patrón regex para el número de factura: 3 primeros caracteres numéricos, 4to carácter guión, posiciones del 5 al 7 con datos numéricos, 8va posición con guión, 6 caracteres últimos con datos numéricos
            string patron = @"^\d{3}-\d{3}-\d{6}$";

            // Comprobar si el número de factura coincide con el patrón
            return Regex.IsMatch(numeroFactura, patron);
        }

        public bool Eliminar(int id)
        {
            try
            {
                if (conexionDB.Execute("DELETE FROM factura WHERE id = @Id", new { Id = id }) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FacturaModel Consultar(int id)
        {
            try
            {
                return conexionDB.QuerySingleOrDefault<FacturaModel>("SELECT * FROM factura WHERE id = @Id", new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<FacturaModel> Listar()
        {
            try
            {
                return conexionDB.Query<FacturaModel>("SELECT * FROM factura");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
