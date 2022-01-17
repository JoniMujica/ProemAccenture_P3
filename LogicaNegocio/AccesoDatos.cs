using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LogicaNegocio
{
    public class AccesoDatos
    {
        public List<Cliente> leerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            SqlConnection connection = new SqlConnection("Server=JONII;Database=proem;Trusted_Connection=True;");

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.Text; //indica que le vamos a pasar la Query como texto
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
    }
}
