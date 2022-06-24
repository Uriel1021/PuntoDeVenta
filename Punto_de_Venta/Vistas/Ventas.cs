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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            inicio inicio = new inicio();
            inicio.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string valor = textBox1.Text;
            Daos daos = new Daos();
            List<ProductoVenta> lista = new List<ProductoVenta>();
            lista = daos.BuscarProductoVenta(valor);
            dgv_control.DataSource = lista;
        }

        private void dgv_control_MouseClick(object sender, MouseEventArgs e)
        {
            int valor = dgv_control.CurrentRow.Index;
            txtId.Text = dgv_control[0, valor].Value.ToString();
            txtDescrib.Text = dgv_control[1, valor].Value.ToString();
            txtCant.Text = dgv_control[2, valor].Value.ToString();
            txtPrecio.Text = dgv_control[3, valor].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Daos daos = new Daos();
            int total = (int.Parse(txtCant.Text))*(int.Parse(txtPrecio.Text));
            int hola = total;
            Venta venta = new Venta();
            venta.IdProducto = int.Parse(txtId.Text);
            venta.Descripcion = txtDescrib.Text;
            venta.Cantidad = int.Parse(txtCant.Text);
            venta.CostoPublico = int.Parse(txtPrecio.Text);
            venta.Total = hola;
            daos.insertarVenta(venta);
            List<Venta> lista = new List<Venta>();
            lista = daos.ConsultaVenta();
            dataGridView1.DataSource = lista;
        }
    }
}
