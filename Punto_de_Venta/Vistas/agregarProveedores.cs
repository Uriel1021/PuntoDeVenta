using Punto_de_Venta.Conexion;
using Punto_de_Venta.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_Venta.Vistas
{
    public partial class agregarProveedores : Form
    {
        public agregarProveedores()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            listarProveedores listarProveedores = new listarProveedores();
            listarProveedores.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            Daos daos = new Daos();
            proveedor.Nombre = textBox1.Text;
            proveedor.Direccion = textBox2.Text;
            proveedor.Telefono = textBox4.Text;
            proveedor.FechaPedido = textBox5.Text;
            proveedor.DiaSurtido = textBox6.Text;
            proveedor.Cantidad = int.Parse(textBox7.Text);
            proveedor.FormaPago = textBox8.Text;
            proveedor.Plazo = int.Parse(textBox9.Text);
            daos.insertarProveedor(proveedor);
        }
    }
}
