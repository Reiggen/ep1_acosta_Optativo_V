using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class ClienteModel
    {
        public int Id { get; set; } 
        public int Id_banco { get; set; } 
        public string Nombre { get; set; } 
        public string Apellido { get; set; } 
        public string Documento { get; set; } 
        public string Mail { get; set; } 
        public string Celular { get; set; } 
        public string Estado { get; set; } 
    }
}
