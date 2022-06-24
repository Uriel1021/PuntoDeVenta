using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_Venta.Modelo
{
    internal class ProductoVenta
    {
        public ProductoVenta()
        {

        }

        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int NumeroUnidades { get; set; }
        public int PrecioPublico { get; set; }
    }
}
