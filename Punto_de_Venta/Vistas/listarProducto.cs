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
using Punto_de_Venta.Modelo;
using Punto_de_Venta.Vistas;

namespace Punto_de_Venta
{
    public partial class listarProducto : Form
    {
        public listarProducto()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            inicio inicio = new inicio();
            inicio.Show();
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            agregarProducto agregarProducto = new agregarProducto();
            agregarProducto.Show();
        }

        private void listarProducto_Load(object sender, EventArgs e)
        {
            List<Producto> datos = new List<Producto>();
            Daos daos = new Daos();
            datos = daos.ConsultaProducto();
            dgv_control.DataSource = datos;
        }
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            int i = dgv_control.CurrentRow.Index;
            int valor = int.Parse(dgv_control[0, i].Value.ToString());
            Daos daos = new Daos();
            daos.eliminar(valor);
            listarProducto listarProducto = new listarProducto();
            listarProducto.Show();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            string valor = bunifuTextbox1.text;
            List<Producto> datos = new List<Producto>();
            Daos daos = new Daos();
            datos = daos.BuscarProducto(valor);
            dgv_control.DataSource = datos;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            bool click = bunifuFlatButton2.Enabled;
            if (click == true)
            {
                int i = dgv_control.CurrentRow.Index;

                string uno = dgv_control[0, i].Value.ToString(); 
                string dos = dgv_control[1, i].Value.ToString();
                string tres = dgv_control[2, i].Value.ToString();
                string cuatro = dgv_control[3, i].Value.ToString();
                string cinco = dgv_control[4, i].Value.ToString();
                string seis = dgv_control[5, i].Value.ToString();
                string siete = dgv_control[6, i].Value.ToString();
                string ocho = dgv_control[7, i].Value.ToString();

                modificarProducto modificarproducto = new modificarProducto();
                modificarproducto.Show();
                modificarproducto.recuperarValores(uno,dos,tres,cuatro,cinco,seis,siete,ocho);
                this.Hide();
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            bool click = bunifuFlatButton2.Enabled;
            if (click == true)
            {
                int i = dgv_control.CurrentRow.Index;

                string uno = dgv_control[0, i].Value.ToString();
                string dos = dgv_control[1, i].Value.ToString();
                string tres = dgv_control[2, i].Value.ToString();
                string cuatro = dgv_control[3, i].Value.ToString();
                string cinco = dgv_control[4, i].Value.ToString();
                string seis = dgv_control[5, i].Value.ToString();
                string siete = dgv_control[6, i].Value.ToString();
                string ocho = dgv_control[7, i].Value.ToString();

                detallesProducto detallesProducto = new detallesProducto();
                detallesProducto.Show();
                detallesProducto.recuperarValores(uno, dos, tres, cuatro, cinco, seis, siete,ocho);
                this.Hide();
            }
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Imagen imagen = new Imagen();
            imagen.Show();
            this.Hide();
        }
    }
}
