using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Punto_de_Venta.Vistas;

namespace Punto_de_Venta
{
    public partial class inicio : Form
    {
        public inicio()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.Show();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            listarProducto productos = new listarProducto();
            productos.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            agregarCategoria agregarCategoria = new agregarCategoria();
            agregarCategoria.Show();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            listarProveedores listarproveedores = new listarProveedores();
            listarproveedores.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();
            venta.Show();
            this.Hide();
        }
    }
}
