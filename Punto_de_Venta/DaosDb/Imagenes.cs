using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_Venta.DaosDb
{
    internal class Imagenes
    {
        public String Redimensionar(Image Imagen_Original, string nombre)

        {

            //RUTA DEL DIRECTORIO TEMPORAL

            String DirTemp = Path.GetTempPath() + @"\" + nombre + ".png";

            //IMAGEN ORIGINAL A REDIMENSIONAR

            Bitmap imagen = new Bitmap(Imagen_Original);

            //CREAMOS UN MAPA DE BIT CON LAS DIMENSIONES QUE QUEREMOS PARA LA NUEVA IMAGEN

            Bitmap nuevaImagen = new Bitmap(Imagen_Original.Width, Imagen_Original.Height);

            //CREAMOS UN NUEVO GRAFICO

            Graphics gr = Graphics.FromImage(nuevaImagen);

            //DIBUJAMOS LA NUEVA IMAGEN

            gr.DrawImage(imagen, 0, 0, nuevaImagen.Width, nuevaImagen.Height);

            //LIBERAMOS RECURSOS

            gr.Dispose();

            //GUARDAMOS LA NUEVA IMAGEN ESPECIFICAMOS LA RUTA Y EL FORMATO

            nuevaImagen.Save(DirTemp, System.Drawing.Imaging.ImageFormat.Png);

            //LIBERAMOS RECURSOS

            nuevaImagen.Dispose();

            imagen.Dispose();

            return DirTemp;

        }

        //FUNCION PARA CONVERTIR LA IMAGEN A BYTES

        public Byte[] Imagen_A_Bytes(String ruta)

        {

            FileStream foto = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            Byte[] arreglo = new Byte[foto.Length];

            BinaryReader reader = new BinaryReader(foto);

            arreglo = reader.ReadBytes(Convert.ToInt32(foto.Length));
            foto.Close();
            return arreglo;

        }

        //FUNCION PARA CONVERTIR DE BYTES A IMAGEN

        public Image Bytes_A_Imagen(Byte[] ImgBytes)

        {

            // Bitmap imagen;
            Image i = null;

            Byte[] imageData = ImgBytes;
            if (imageData != null)
            {
                //MemoryStream ms = new MemoryStream(bytes);
                /*using (var ms = new MemoryStream(imageData))
                {
                    imagen = new Bitmap(ms);
                }*/
                using (MemoryStream productImageStream = new MemoryStream(imageData))
                {
                    ImageConverter imageConverter = new ImageConverter();
                    i = imageConverter.ConvertFrom(imageData) as Image;
                }
            }
            //i.Dispose();

            return i;
        }
    }
}
