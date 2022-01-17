using LogicaNegocio;

namespace Vista
{
    public partial class FrmPrincipal : Form
    {
        Negocio negocio;
        public FrmPrincipal()
        {
            InitializeComponent();
            negocio = new Negocio();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            DetalleCliente detalleCliente = new DetalleCliente(negocio/*,this*/);
            detalleCliente.ShowDialog();
            ActualizarClientes();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ActualizarClientes();
        }
        public void ActualizarClientes()
        {
            this.dgvClientes.DataSource = null;
            this.dgvClientes.DataSource = negocio.LeerClientes();
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente cliente = dgvClientes.CurrentRow.DataBoundItem as Cliente;
            DetalleCliente detalleCliente = new DetalleCliente(negocio,cliente);
            detalleCliente.ShowDialog();
        }
    }
}