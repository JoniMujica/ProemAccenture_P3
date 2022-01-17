using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class DetalleCliente : Form
    {
        Negocio negocio;
        Cliente cliente;
        //FrmPrincipal frmPrincipal;


        public DetalleCliente()
        {
            InitializeComponent();
            negocio = new Negocio();
            //frmPrincipal = new FrmPrincipal();
        }
        public DetalleCliente(Negocio negocio/*,FrmPrincipal frmPrincipal*/):this()
        {
            this.negocio = negocio;
            //this.frmPrincipal = frmPrincipal;
        }
        public DetalleCliente(Negocio negocio,Cliente cliente):this(negocio)
        {
            this.cliente = cliente;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cliente is null)
            {
                cliente = new Cliente(txtNombre.Text, txtApellido.Text, int.Parse(txtTelefono.Text), txtDireccion.Text);
            }
            else
            {
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Telefono = int.Parse(txtTelefono.Text);
                cliente.Direccion = txtDireccion.Text;
            }
            negocio.Agregar(cliente);
            //this.frmPrincipal.ActualizarClientes();
            LimpiarFormulario();

            DialogResult = DialogResult.OK;
        }

        private void CargarDatos()
        {
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtTelefono.Text = cliente.Telefono.ToString();
            txtDireccion.Text = cliente.Direccion;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = String.Empty;
            txtApellido.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtDireccion.Text = String.Empty;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void DetalleCliente_Load(object sender, EventArgs e)
        {
            if (cliente != null)
            {
                CargarDatos();
            }
        }
    }
}
