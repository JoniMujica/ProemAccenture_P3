using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LogicaNegocio
{
    public static class AccesoDatos
    {

        private static SqlConnection connection;
        private static SqlCommand cmd;

        static AccesoDatos()
        {
            connection = new SqlConnection("Server=JONII;Database=proem;Trusted_Connection=True;");
            cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
        }
        public static List<Cliente> leerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                connection.Open();

                cmd.CommandText = "select * from Clientes"; //Ejecuta la consulta
                SqlDataReader reader = cmd.ExecuteReader(); //ejecuta la consulta y lo formatea en SqlDataReader

                while (reader.Read()) //VERIFICA SI HAY FILAS POR LEER
                {
                    clientes.Add(new Cliente(int.Parse(reader["Id"].ToString()),
                        reader["Nombre"].ToString(),
                        reader["Apellido"].ToString(), 
                        int.Parse(reader["Telefono"].ToString()), 
                        reader["Direccion"].ToString()));
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

            return clientes;

        }

        public static void InsertarCliente(Cliente cliente)
        {

            try
            {
                connection.Open();
                cmd.CommandText = "INSERT INTO Clientes (Nombre,Apellido,Direccion,Telefono)" +
                                  " VALUES (@nombre,@apellido,@direccion,@telefono)"; //con los @ defino cuales seran las variables la cuales despues asignare valor
                cmd.Parameters.AddWithValue("@nombre",cliente.Nombre); //aca llamo a la variable definida anteriormente y le asigno un valor
                cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
