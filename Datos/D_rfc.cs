using Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_rfc
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
        public void Agregar(E_rfc rfc)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("agregar_rfc", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@nombre", rfc.nombre);
                comando.Parameters.AddWithValue("@apellidoPa", rfc.apellidoPa);
                comando.Parameters.AddWithValue("@apellidoMa", rfc.apellidoMa);
                comando.Parameters.AddWithValue("fechaNac", rfc.fechaNac);
                comando.Parameters.AddWithValue("@activo", 1);
                comando.Parameters.AddWithValue("@rfc", rfc.RFC);

                comando.ExecuteNonQuery();

            }
            catch (Exception ex) 
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<E_rfc> Mostrar_todos()
        {
            List<E_rfc> lista = new List<E_rfc>();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("mostrar_todos_rfc", conexion);
                comando.CommandType= CommandType.StoredProcedure;

                SqlDataReader reader= comando.ExecuteReader();

                while (reader.Read())
                {
                    E_rfc listado = new E_rfc();

                    listado.idUsuario = Convert.ToInt32(reader["idUsuario"]);
                    listado.nombre = reader["nombre"].ToString();
                    listado.apellidoPa = reader["apellidoPa"].ToString();
                    listado.apellidoMa = reader["apellidoMa"].ToString();
                    listado.fechaNac = Convert.ToDateTime(reader["fechaNac"]);
                    lista.Add(listado);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }

        public E_rfc mostrarPorId(int id)
        {
            E_rfc lista = new E_rfc();

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("mostrar_Id_rfc", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idUsuario", id);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {

                    lista.idUsuario = Convert.ToInt32(reader["idUsuario"]);
                    lista.nombre = reader["nombre"].ToString();
                    lista.apellidoPa = reader["apellidoPa"].ToString();
                    lista.apellidoMa = reader["apellidoMa"].ToString();
                    lista.fechaNac = Convert.ToDateTime(reader["fechaNac"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }

        public void Actualizar(E_rfc rfc)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("actualizar_rfc", conexion);

                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("idUsuario", rfc.idUsuario);
                comando.Parameters.AddWithValue("@nombre", rfc.nombre);
                comando.Parameters.AddWithValue("@apellidoPa", rfc.apellidoPa);
                comando.Parameters.AddWithValue("@apellidoMa", rfc.apellidoMa);
                comando.Parameters.AddWithValue("@fechaNac", rfc.fechaNac);
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void Eliminar(E_rfc rfc)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("eliminar_rfc", conexion);

                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("idUsuario", rfc.idUsuario);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public int mostrarActivos()
        {
            SqlConnection conexion = new SqlConnection (cadenaConexion);
            int totalActivos = 0;
            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("contar_activos", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    totalActivos = reader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return totalActivos;
        }

        public List<E_rfc> Buscar(string texto)
        {
            //Creamos la lista para almaecnar las peliculas
            List<E_rfc> lista = new List<E_rfc>();
            //Creamos el objeto conexion
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                //Abrimos la conexión
                conexion.Open();
                //Crear el objeto para ejecutar el stores procedure
                //Le pasamos el nombre del stored procedure a ejecutar
                SqlCommand comando = new SqlCommand("Buscar_rfc", conexion);
                //Le indicamos al objeto comando que va a ejecutar un stores procedure
                comando.CommandType = CommandType.StoredProcedure;

                //Pasamos el valor del parametro
                comando.Parameters.AddWithValue("@texto", texto);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    //Creamos un objeto de la clase pelicula
                    E_rfc rfc = new E_rfc();

                    rfc.idUsuario = Convert.ToInt32(reader["idUsuario"]);
                    rfc.nombre = reader["nombre"].ToString();
                    rfc.apellidoPa = reader["apellidoPa"].ToString();
                    rfc.apellidoMa = reader["apellidoMa"].ToString();

                    lista.Add(rfc);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }

    }
}
