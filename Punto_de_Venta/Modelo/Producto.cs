using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_Venta.Modelo
{
    internal class Producto
    {
        public Producto()
        {
        }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int NumeroUnidades { get; set; }
        public int PrecioProveedor { get; set; }
        public int PrecioUnitario { get; set; }
        public int PrecioPublico { get; set; }
        public string CodigoBarra { get; set; }
        public string FechaEntrada { get; set; }
        public int CategoriaId { get; set; }
    }
}
