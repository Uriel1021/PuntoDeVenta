using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_Venta.Modelo
{
    internal class Venta
    {
        public Venta()
        {
        }
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int CostoPublico { get; set; }
        public int Total { get; set; }
    }
}
