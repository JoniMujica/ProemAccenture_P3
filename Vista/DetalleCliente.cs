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
        FrmPrincipal frmPrincipal;
        public DetalleCliente()
        {
            InitializeComponent();
            negocio = new Negocio();
            frmPrincipal = new FrmPrincipal();
        }
        public DetalleCliente(Negocio negocio,FrmPrincipal frmPrincipal):this()
        {
            this.negocio = negocio;
            this.frmPrincipal = frmPrincipal;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente(txtNombre.Text, txtApellido.Text, int.Parse(txtTelefono.Text), txtDireccion.Text);
            negocio.Agregar(cliente);
            this.frmPrincipal.ActualizarClientes();
            txtNombre.Text = String.Empty;
            txtApellido.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtDireccion.Text = String.Empty;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
