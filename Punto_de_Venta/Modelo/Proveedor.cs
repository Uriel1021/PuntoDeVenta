using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_Venta.Modelo
{
    internal class Proveedor
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string FechaPedido { get; set; }
        public string DiaSurtido { get; set; }
        public int Cantidad { get; set; }
        public string FormaPago { get; set; }
        public int Plazo { get; set; }
    }
}
