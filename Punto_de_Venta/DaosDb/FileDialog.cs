using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_Venta.DaosDb
{
    internal class FileDialog
    {
        public Image obtener(OpenFileDialog openFileDialog, PictureBox pictureBox)
        {
            string ruta = "";
            Image image = null;
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //guarda la dirección del archivo en una variable del tipo string.
                    ruta = openFileDialog.FileName;
                    //Si el archivo que se eligió en el explorador de Windows es una imagen, se muestra la imagen en control pictureBox1.

                    pictureBox.Image = Image.FromFile(ruta);
                    image = pictureBox.Image;
                }
                else
                {
                    MessageBox.Show("Error al cargar imagen");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return image;
        }
    }
}
