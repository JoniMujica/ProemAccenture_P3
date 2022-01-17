using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Negocio
    {
        List<Cliente> clientes;
        //AccesoDatos accesoDatos;

        public Negocio()
        {
            clientes = new List<Cliente>();
            /*
            {
                new Cliente("ana","lopez",4546485,"callao 123")
            };*/
            //accesoDatos = new AccesoDatos();
        }

        public List<Cliente> Clientes { get => clientes; set => clientes = value; }

        public void Agregar(Cliente cliente)
        {
            //cliente.Id = clientes.Count + 1; //revisar
            //clientes.Add(cliente);
            if (cliente.Id == 0)
            {
                AccesoDatos.InsertarCliente(cliente);
            }
            else
            {
                AccesoDatos.ModificarCliente(cliente);
            }
        }
        public List<Cliente> LeerClientes()
        {
            return AccesoDatos.leerClientes();
        }
    }
}
