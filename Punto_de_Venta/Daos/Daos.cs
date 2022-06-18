using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Npgsql;
using Dapper;
using Punto_de_Venta.Modelo;

namespace Punto_de_Venta.Conexion
{
    internal class Daos
    {
        public Daos()
        {
        }
        static String servidor = "localhost"; //Aqui va tu servidor
        static String bd = "puntoDeVenta"; //Aqui va el nombre de la db
        static String usuario = "postgres"; //Aqui va tu usuario
        static String password = "Root";//Aqui va tu contraseña
        static String puerto = "5432"; //Puerto de conexión
        //Instancia  de la clase NpgsqlConnection
        NpgsqlConnection conexion = new NpgsqlConnection();
        //Cadena con la información necesaria para establecer la conexión a la DB
        public String cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";

        //Método que permite establcer al conexión incial
        public NpgsqlConnection establecerConexion()
        {
            try{
                if (conexion.State == ConnectionState.Closed){
                    conexion.ConnectionString = cadenaConexion;
                    conexion.Open();
                    MessageBox.Show("Se conectó correctamente a la base de datos");
                }else{
                    MessageBox.Show("La conexión ya esta hecha");
                }
            }catch (NpgsqlException e){
                MessageBox.Show("No se pudo conectar a la base de datos de PostgreSQL, error: " + e.ToString());
            }
            return conexion;
        }
        //Permite cerrar la conexión a la db
        public NpgsqlConnection cerrarConexionADb()
        {
            try{
                if (conexion.State == ConnectionState.Open){
                    conexion.Close();
                    MessageBox.Show("Se ha cerrado la conexión a la DB");
                }else{
                    MessageBox.Show("La conexión ya ha finalizado");
                }
            }catch (NpgsqlException e){
                MessageBox.Show("Error al cerrar la base de datos de PostgreSQL, error: " + e.ToString());
            }
            return conexion;
        }


        public void insertarCategoria(Categoria categoria)
        {
            NpgsqlConnection connectionInsertarElement = new NpgsqlConnection(cadenaConexion);
            string QUERY_INSERT_ELEMENTOS = String.Format("INSERT INTO categoria(categoria) VALUES ('{0}');", categoria.CategoriaName);
            NpgsqlCommand commandInsert = new NpgsqlCommand(QUERY_INSERT_ELEMENTOS, connectionInsertarElement);
            try
            {
                if (connectionInsertarElement.State == System.Data.ConnectionState.Closed)
                {
                    connectionInsertarElement.Open();
                    //MessageBox.Show("La conexion se ha abierto........");
                }
                else
                {
                    //MessageBox.Show("La conexion ya se encuentra abierta.....");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                if (connectionInsertarElement.State == System.Data.ConnectionState.Open)
                {
                    {
                        commandInsert.ExecuteNonQuery();
                        MessageBox.Show("Se ha guardado tu informacion");
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void insertarProducto(Producto producto)
        {
            NpgsqlConnection connectionInsertarElement = new NpgsqlConnection(cadenaConexion);
            string QUERY_INSERT_ELEMENTOS = String.Format("INSERT INTO public.producto(descripcion, unidades,proveedor , unitario, publico, barra, entrega, categoria)VALUES('{0}',{1},{2},{3},{4},'{5}','{6}',{7});", producto.Descripcion, producto.NumeroUnidades, producto.PrecioProveedor, producto.PrecioUnitario, producto.PrecioPublico, producto.CodigoBarra, producto.FechaEntrada, producto.CategoriaId);
            NpgsqlCommand commandInsert = new NpgsqlCommand(QUERY_INSERT_ELEMENTOS, connectionInsertarElement);
            try
            {
                if (connectionInsertarElement.State == System.Data.ConnectionState.Closed)
                {
                    connectionInsertarElement.Open();
                    //MessageBox.Show("La conexion se ha abierto........");
                }
                else
                {
                    //MessageBox.Show("La conexion ya se encuentra abierta.....");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                if (connectionInsertarElement.State == System.Data.ConnectionState.Open)
                {
                    commandInsert.ExecuteNonQuery();
                    MessageBox.Show("Se ha guardado tu informacion.......");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<Producto> consultar()
        {
            establecerConexion();
            string query = "SELECT * FROM producto ORDER BY producto ASC;";
            if (establecerConexion().State == ConnectionState.Open)
            {
                return conexion.Query<Producto>(query).ToList();
            }
            else
            {
                establecerConexion();
                MessageBox.Show("Se conectó correctamente a la base de datos");
                return conexion.Query<Producto>(query).ToList();
            }
        }


        public void eliminar(int productoId)
        {
            NpgsqlConnection connectionInsertarElement = new NpgsqlConnection(cadenaConexion);
            string QUERY_INSERT_ELEMENTOS = String.Format("DELETE FROM producto WHERE producto like ('{0}');",productoId);
            NpgsqlCommand commandInsert = new NpgsqlCommand(QUERY_INSERT_ELEMENTOS, connectionInsertarElement);
            try
            {
                if (connectionInsertarElement.State == System.Data.ConnectionState.Closed)
                {
                    connectionInsertarElement.Open();
                    //MessageBox.Show("La conexion se ha abierto........");
                }
                else
                {
                    //MessageBox.Show("La conexion ya se encuentra abierta.....");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                if (connectionInsertarElement.State == System.Data.ConnectionState.Open)
                {
                    {
                        commandInsert.ExecuteNonQuery();
                        MessageBox.Show("Se ha eliminado tu informacion");
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public List<Producto> buscarId(int valor)
        {
            Daos dbConection = new Daos();
            string query = "SELECT * FROM producto WHERE productoId like ('" + valor + "') ORDER BY productoId ASC;";
            if (dbConection.establecerConexion().State == ConnectionState.Open)
            {
                return conexion.Query<Producto>(query).ToList();
            }
            else
            {
                dbConection.establecerConexion();
                MessageBox.Show("Se conectó correctamente a la base de datos");
                return conexion.Query<Producto>(query).ToList();
            }
        }
    }
}
