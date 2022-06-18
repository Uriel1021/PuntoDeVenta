using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Punto_de_Venta.Conexion;
using Punto_de_Venta.Modelo;

namespace Punto_de_Venta.Vistas
{
    public partial class agregarProducto : Form
    {
        public agregarProducto()
        {
            InitializeComponent();
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            listarProducto listarproducto = new listarProducto();
            listarproducto.Show();
        }
        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Daos daos = new Daos();
            Producto producto = new Producto();

            producto.CategoriaId = comboBox1.SelectedIndex;
            producto.Descripcion = textBox2.Text;
            producto.NumeroUnidades = int.Parse(textBox4.Text);
            producto.PrecioProveedor = int.Parse(textBox5.Text);
            producto.PrecioUnitario= int.Parse(textBox6.Text);
            producto.PrecioPublico = int.Parse(textBox7.Text);
            producto.CodigoBarra = textBox8.Text;
            producto.FechaEntrada = textBox9.Text;
            daos.insertarProducto(producto);
            MessageBox.Show("Se ha guardado la imagen en la db");
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            //ProductoInterfaz productoIDao = new ProductoDao();
            //img = productoIDao.obtener(openFileDialog1, pictureBox1);
        }

        private void agregarProducto_Load(object sender, EventArgs e)
        {
            String servidor = "localhost"; //Aqui va tu servidor
            String bd = "puntoDeVenta"; //Aqui va el nombre de la db
            String usuario = "postgres"; //Aqui va tu usuario
            String password = "Root";//Aqui va tu contraseña
            String puerto = "5432"; //Puerto de conexión
            //Instancia  de la clase NpgsqlConnection
            string cadenaDeConexionTabla = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = cadenaDeConexionTabla;
            conexion.Open();
            NpgsqlCommand query = new NpgsqlCommand();
            query.CommandText = "SELECT categoria FROM categoria;";
            query.Connection = conexion;
            NpgsqlDataReader rd = query.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd[0]);
            }
            rd.Close(); 
        }
    }
}
