using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Punto_de_Venta.Conexion;
using Punto_de_Venta.DaosDb;
using Punto_de_Venta.Modelo;

namespace Punto_de_Venta.Vistas
{
    public partial class Imagen : Form
    {
        Image img;
        ModelImag modelImg = new ModelImag();
        Daos daos = new Daos();
        public Imagen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DaosDb.FileDialog imagen = new DaosDb.FileDialog();
            img = imagen.obtener(openFileDialog1, pictureBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                Daos daos = new Daos();
                Imagenes imagen = new Imagenes();
                String data = imagen.Redimensionar(img, "temporal");
                modelImg.img = imagen.Imagen_A_Bytes(data);
                MessageBox.Show("imagen convertida");
                daos.insertarImagen(modelImg,6);
            }
            else
            {
                if (radioButton2.Checked)
                {
                    Daos daos = new Daos();
                    Imagenes imagen = new Imagenes();
                    String data = imagen.Redimensionar(img, "temporal");
                    modelImg.img = imagen.Imagen_A_Bytes(data);
                    MessageBox.Show("imagen convertida");
                    daos.insertarImagen(modelImg, 1);
                }
            }
        }
    }
}
