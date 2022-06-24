using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using Npgsql;
using Punto_de_Venta.Modelo;

namespace Punto_de_Venta.Conexion
{
    internal class Daos
    {
        static String servidor = "localhost"; //Servidor
        static String bd = "puntoDeVenta"; //Nombre de la base de datos
        static String usuario = "postgres"; //usuario
        static String password = "Root";//contraseña
        static String puerto = "5432"; //Puerto de conexión
        //Instancia  de la clase NpgsqlConnection
        NpgsqlConnection conexion = new NpgsqlConnection();
        //Cadena con la información necesaria para establecer la conexión a la DB
        public String cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
        //Método que permite verificar si la base de datos esta abierta
        public void ConectionState(NpgsqlConnection conexion)
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public NpgsqlConnection CloseConexion(NpgsqlConnection conexionDB)
        {
            try {
                if (conexionDB.State == ConnectionState.Open) {
                    conexionDB.Close();
                }
            } catch (NpgsqlException e) {
                MessageBox.Show(e.ToString());
            }
            return conexion;
        }
        public void insertarCategoria(Categoria categoria)
        {
            NpgsqlConnection connection = new NpgsqlConnection(cadenaConexion);
            string QUERY_INSERT_ELEMENTOS = String.Format("INSERT INTO categoria(categoria) VALUES ('{0}');", categoria.CategoriaName);
            NpgsqlCommand commandInsert = new NpgsqlCommand(QUERY_INSERT_ELEMENTOS, connection);
            ConectionState(connection);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    {
                        commandInsert.ExecuteNonQuery();
                        MessageBox.Show("Se ha guardado la información correctamente");
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConexion(connection);
        }
        public List<Categoria> ConsultaCategoria()
        {
            List<Categoria> listaRetorna = new List<Categoria>();
            string cadenaDeConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
            NpgsqlConnection connection = new NpgsqlConnection(cadenaDeConexion);
            string QUERY_CONSULTA = "SELECT * FROM categoria ORDER BY categoriaid DESC;";
            NpgsqlCommand commandConsulta = new NpgsqlCommand(QUERY_CONSULTA, connection);
            ConectionState(connection);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    NpgsqlDataReader dataReader2 = commandConsulta.ExecuteReader();
                    while (dataReader2.Read())
                    {
                        Categoria categoria = new Categoria();
                        categoria.CategoriaId = dataReader2.GetInt16(0);
                        categoria.CategoriaName = dataReader2.GetString(1);
                        listaRetorna.Add(categoria);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConexion(connection);
            return listaRetorna;
        }
        public void insertarProducto(Producto producto)
        {
            NpgsqlConnection connection = new NpgsqlConnection(cadenaConexion);
            string QUERY_INSERT_ELEMENTOS = String.Format("INSERT INTO public.producto(descripcion, unidades,proveedor , unitario, publico, barra, entrega, categoria)VALUES('{0}',{1},{2},{3},{4},'{5}','{6}',{7});", producto.Descripcion, producto.NumeroUnidades, producto.PrecioProveedor, producto.PrecioUnitario, producto.PrecioPublico, producto.CodigoBarra, producto.FechaEntrada, producto.CategoriaId);
            NpgsqlCommand commandInsert = new NpgsqlCommand(QUERY_INSERT_ELEMENTOS, connection);
            ConectionState(connection);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    commandInsert.ExecuteNonQuery();
                    MessageBox.Show("Se ha guardado tu informacion.......");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConexion(connection);
        }
        public void eliminar(int productoId)
        {
            NpgsqlConnection connection = new NpgsqlConnection(cadenaConexion);
            string QUERY_INSERT_ELEMENTOS = String.Format("DELETE FROM producto WHERE producto={0};", productoId);
            NpgsqlCommand commandInsert = new NpgsqlCommand(QUERY_INSERT_ELEMENTOS, connection);
            ConectionState(connection);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
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
            CloseConexion(connection);
        }
        public List<Producto> ConsultaProducto()
        {
            List<Producto> listaRetorna = new List<Producto>();
            string cadenaDeConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
            NpgsqlConnection connection = new NpgsqlConnection(cadenaDeConexion);
            string QUERY_CONSULTA = "SELECT * FROM producto;";
            NpgsqlCommand commandConsultaDos = new NpgsqlCommand(QUERY_CONSULTA, connection);
            ConectionState(connection);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    NpgsqlDataReader dataReader2 = commandConsultaDos.ExecuteReader();
                    while (dataReader2.Read())
                    {
                        Producto producto = new Producto();
                        producto.ProductoId = dataReader2.GetInt16(0);
                        producto.Descripcion = dataReader2.GetString(1);
                        producto.NumeroUnidades = dataReader2.GetInt16(2);
                        producto.PrecioProveedor = dataReader2.GetInt16(3);
                        producto.PrecioUnitario = dataReader2.GetInt16(4);
                        producto.PrecioPublico = dataReader2.GetInt16(5);
                        producto.CodigoBarra = dataReader2.GetString(6);
                        producto.FechaEntrada = dataReader2.GetString(7);
                        producto.CategoriaId = dataReader2.GetInt16(8);
                        listaRetorna.Add(producto);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConexion(connection);
            return listaRetorna;
        }
        public List<Producto> BuscarProducto(string prod)
        {
            List<Producto> listaRetorna = new List<Producto>();
            string cadenaDeConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
            NpgsqlConnection connection = new NpgsqlConnection(cadenaDeConexion);
            string QUERY_CONSULTA = string.Format("SELECT * FROM producto WHERE descripcion LIKE '%{0}%' LIMIT 1;", prod);
            NpgsqlCommand commandConsultaDos = new NpgsqlCommand(QUERY_CONSULTA, connection);
            ConectionState(connection);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    NpgsqlDataReader dataReader2 = commandConsultaDos.ExecuteReader();
                    while (dataReader2.Read())
                    {
                        Producto producto = new Producto();
                        producto.ProductoId = dataReader2.GetInt16(0);
                        producto.Descripcion = dataReader2.GetString(1);
                        producto.NumeroUnidades = dataReader2.GetInt16(2);
                        producto.PrecioProveedor = dataReader2.GetInt16(3);
                        producto.PrecioUnitario = dataReader2.GetInt16(4);
                        producto.PrecioPublico = dataReader2.GetInt16(5);
                        producto.CodigoBarra = dataReader2.GetString(6);
                        producto.FechaEntrada = dataReader2.GetString(7);
                        producto.CategoriaId = dataReader2.GetInt16(8);
                        listaRetorna.Add(producto);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConexion(connection);
            return listaRetorna;
        }

        public void modificarProducto(int valor, Producto product)
        {
            NpgsqlConnection connection = new NpgsqlConnection(cadenaConexion);
            string QUERY_INSERT_ELEMENTOS = string.Format("UPDATE producto SET  descripcion ='{0}', unidades ={1}, proveedor ={2}, unitario ={3}, publico ={4}, barra ='{5}', entrega ='{6}' WHERE producto = {7} ;", product.Descripcion, product.NumeroUnidades, product.PrecioProveedor, product.PrecioUnitario, product.PrecioPublico, product.CodigoBarra, product.FechaEntrada, valor);
            NpgsqlCommand commandInsert = new NpgsqlCommand(QUERY_INSERT_ELEMENTOS, connection);
            ConectionState(connection);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    commandInsert.ExecuteNonQuery();
                    MessageBox.Show("Se ha guardado tu informacion.......");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConexion(connection);
        }
        public void insertarProveedor(Proveedor proveedor)
        {
            NpgsqlConnection connection = new NpgsqlConnection(cadenaConexion);
            string QUERY_INSERT_ELEMENTOS = String.Format("INSERT INTO public.proveedor(nombre, direccion, telefono, fechapedido, diasurtido, cantidad, formapago, plazo) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', {5}, '{6}', {7}); ",proveedor.Nombre,proveedor.Direccion,proveedor.Telefono,proveedor.FechaPedido,proveedor.DiaSurtido,proveedor.Cantidad,proveedor.FormaPago,proveedor.Plazo);
            NpgsqlCommand commandInsert = new NpgsqlCommand(QUERY_INSERT_ELEMENTOS, connection);
            ConectionState(connection);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    commandInsert.ExecuteNonQuery();
                    MessageBox.Show("Se ha guardado tu informacion.......");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConexion(connection);
        }
        public List<Proveedor> ConsultaProveedor()
        {
            List<Proveedor> listaRetorna = new List<Proveedor>();
            string cadenaDeConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
            NpgsqlConnection connection = new NpgsqlConnection(cadenaDeConexion);
            string QUERY_CONSULTA = "SELECT * FROM proveedor;";
            NpgsqlCommand commandConsulta = new NpgsqlCommand(QUERY_CONSULTA, connection);
            ConectionState(connection);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    NpgsqlDataReader dataReader2 = commandConsulta.ExecuteReader();
                    while (dataReader2.Read())
                    {
                        Proveedor proveedor = new Proveedor();
                        proveedor.ProveedorId = dataReader2.GetInt16(0);
                        proveedor.Nombre = dataReader2.GetString(1);
                        proveedor.Direccion = dataReader2.GetString(2);
                        proveedor.Telefono = dataReader2.GetString(3);
                        proveedor.FechaPedido = dataReader2.GetString(4);
                        proveedor.DiaSurtido = dataReader2.GetString(5);
                        proveedor.Cantidad = dataReader2.GetInt16(6);
                        proveedor.FormaPago = dataReader2.GetString(7);
                        proveedor.Plazo = dataReader2.GetInt16(8);
                        listaRetorna.Add(proveedor);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConexion(connection);
            return listaRetorna;
        }

        public List<Proveedor> BuscarProveedor(string prod)
        {
            List<Proveedor> listaRetorna = new List<Proveedor>();
            string cadenaDeConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
            NpgsqlConnection connection = new NpgsqlConnection(cadenaDeConexion);
            string QUERY_CONSULTA = string.Format("SELECT * FROM proveedor WHERE nombre like '%{0}%';", prod);
            NpgsqlCommand commandConsultaDos = new NpgsqlCommand(QUERY_CONSULTA, connection);
            ConectionState(connection);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    NpgsqlDataReader dataReader2 = commandConsultaDos.ExecuteReader();
                    while (dataReader2.Read())
                    {
                        Proveedor proveedor = new Proveedor();
                        proveedor.ProveedorId = dataReader2.GetInt16(0);
                        proveedor.Nombre = dataReader2.GetString(1);
                        proveedor.Direccion = dataReader2.GetString(2);
                        proveedor.Telefono = dataReader2.GetString(3);
                        proveedor.FechaPedido = dataReader2.GetString(4);
                        proveedor.DiaSurtido = dataReader2.GetString(5);
                        proveedor.Cantidad = dataReader2.GetInt16(6);
                        proveedor.FormaPago = dataReader2.GetString(7);
                        proveedor.Plazo = dataReader2.GetInt16(8);

                        listaRetorna.Add(proveedor);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConexion(connection);
            return listaRetorna;
        }
        public void modificarProveedor(int valor, Proveedor proveedor)
        {
            NpgsqlConnection connection = new NpgsqlConnection(cadenaConexion);
            string QUERY_INSERT_ELEMENTOS = string.Format("UPDATE proveedor SET nombre='{0}', direccion='{1}', telefono='{2}', fechapedido='{3}', diasurtido='{4}', cantidad={5}, formapago='{6}', plazo={7} WHERE provedor={8};",proveedor.Nombre,proveedor.Direccion,proveedor.Telefono,proveedor.FechaPedido,proveedor.DiaSurtido,proveedor.Cantidad,proveedor.FormaPago,proveedor.Plazo,valor);
            NpgsqlCommand commandInsert = new NpgsqlCommand(QUERY_INSERT_ELEMENTOS, connection);
            ConectionState(connection);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    commandInsert.ExecuteNonQuery();
                    MessageBox.Show("Se ha guardado tu informacion.......");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConexion(connection);
        }
        public void eliminarProveedor(int proveedorId)
        {
            NpgsqlConnection connection = new NpgsqlConnection(cadenaConexion);
            string QUERY_INSERT_ELEMENTOS = String.Format("DELETE FROM proveedor WHERE provedor={0};", proveedorId);
            NpgsqlCommand commandInsert = new NpgsqlCommand(QUERY_INSERT_ELEMENTOS, connection);
            ConectionState(connection);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
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
            CloseConexion(connection);
        }
        public List<ProductoVenta> BuscarProductoVenta(string prod)
        {
            List<ProductoVenta> listaRetorna = new List<ProductoVenta>();
            string cadenaDeConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
            NpgsqlConnection connection = new NpgsqlConnection(cadenaDeConexion);
            string QUERY_CONSULTA = string.Format("SELECT producto,descripcion,unidades,publico FROM producto WHERE descripcion LIKE '%{0}%' LIMIT 1;", prod);
            NpgsqlCommand commandConsultaDos = new NpgsqlCommand(QUERY_CONSULTA, connection);
            ConectionState(connection);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    NpgsqlDataReader dataReader2 = commandConsultaDos.ExecuteReader();
                    while (dataReader2.Read())
                    {
                        ProductoVenta producto = new ProductoVenta();
                        producto.ProductoId = dataReader2.GetInt16(0);
                        producto.Descripcion = dataReader2.GetString(1);
                        producto.NumeroUnidades = dataReader2.GetInt16(2);
                        producto.PrecioPublico = dataReader2.GetInt16(3);
                        listaRetorna.Add(producto);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConexion(connection);
            return listaRetorna;
        }
















        public void insertarVenta(Venta venta)
        {
            NpgsqlConnection connection = new NpgsqlConnection(cadenaConexion);
            string QUERY_INSERT_ELEMENTOS = String.Format("INSERT INTO venta(idproducto, descripcion, cantidad, publico, total) VALUES ({0}, '{1}', {2}, {3}, {4});", venta.IdProducto,venta.Descripcion,venta.Cantidad,venta.CostoPublico,venta.Total);
            NpgsqlCommand commandInsert = new NpgsqlCommand(QUERY_INSERT_ELEMENTOS, connection);
            ConectionState(connection);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    commandInsert.ExecuteNonQuery();
                    MessageBox.Show("Se ha guardado tu informacion.......");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConexion(connection);
        }
        public List<Venta> ConsultaVenta()
        {
            List<Venta> listaRetorna = new List<Venta>();
            string cadenaDeConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
            NpgsqlConnection connection = new NpgsqlConnection(cadenaDeConexion);
            string QUERY_CONSULTA = "SELECT * FROM venta;";
            NpgsqlCommand commandConsulta = new NpgsqlCommand(QUERY_CONSULTA, connection);
            ConectionState(connection);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    NpgsqlDataReader dataReader2 = commandConsulta.ExecuteReader();
                    while (dataReader2.Read())
                    {
                        Venta venta = new Venta();
                        venta.Id = dataReader2.GetInt16(0);
                        venta.IdProducto = dataReader2.GetInt16(1);
                        venta.Descripcion = dataReader2.GetString(2);
                        venta.Cantidad = dataReader2.GetInt16(3);
                        venta.CostoPublico = dataReader2.GetInt16(4);
                        venta.Total = (int)dataReader2.GetInt64(5);
                        listaRetorna.Add(venta);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConexion(connection);
            return listaRetorna;
        }

        public void insertarImagen(ModelImag modelImg,int valor)
        {
            string cadenaDeConexionTabla = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
            NpgsqlConnection connectionInsertarElement = new NpgsqlConnection(cadenaDeConexionTabla);
            string QUERY_INSERT_ELEMENTOS = "UPDATE producto SET imagen= @img WHERE producto="+valor+";";
            NpgsqlCommand commandInsert = new NpgsqlCommand(QUERY_INSERT_ELEMENTOS, connectionInsertarElement);
            //6. Abrir la conexión a la db
            try
            {
                if (connectionInsertarElement.State == System.Data.ConnectionState.Closed)
                {
                    NpgsqlParameter param = commandInsert.CreateParameter();
                    param.ParameterName = "@img";
                    param.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea;
                    param.Value = modelImg.img;
                    commandInsert.Parameters.Add(param);
                    connectionInsertarElement.Open();
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

                    MessageBox.Show("Se ha guardado correctamente la imagen");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConexion(connectionInsertarElement);
        }



        public Byte[] consultarTodo(int id)
        {
            Byte[] data = null;
            string cadenaDeConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
            NpgsqlConnection connectionConsultar = new NpgsqlConnection(cadenaDeConexion);
            string query = string.Format("SELECT producto FROM imagen WHERE producto={0};", id);
            NpgsqlCommand commandConsultar = new NpgsqlCommand(query, connectionConsultar);
            ConectionState(connectionConsultar);
            try
            {
                if (connectionConsultar.State == System.Data.ConnectionState.Open)
                {
                    NpgsqlDataReader dataReader = commandConsultar.ExecuteReader();

                    while (dataReader.Read())
                    {
                        data = (Byte[])dataReader[0];
                    }

                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            CloseConexion(connectionConsultar);
            return data;

        }
    }
}