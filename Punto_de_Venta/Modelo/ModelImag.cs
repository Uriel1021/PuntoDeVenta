using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_Venta.Modelo
{
    internal class ModelImag
    {
        public Byte[] img { get; set; }
        public Image imagenModel { get; set; }
        public string nombreImg { get; set; }

        public ModelImag()
        {

        }

        public ModelImag(Byte[] img)
        {
            this.img = img;
        }
    }
}
