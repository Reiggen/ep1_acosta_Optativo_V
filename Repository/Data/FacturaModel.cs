using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class FacturaModel
    {
        public int id { get; set; }
        public int id_cliente { get; set; }
        public string nro_factura { get; set; }
        public DateTime fecha_hora { get; set; }
        public int total { get; set; }
        public int total_iva5 { get; set; }
        public int total_iva10 { get; set; }
        public int total_iva { get; set; }
        public string total_letras { get; set; }
        public string sucursal { get; set; }
    }
}
