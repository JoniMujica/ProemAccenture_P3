namespace LogicaNegocio
{
    public class Cliente
    {
        private string nombre;
        private string apellido;
        private int id;
        private int telefono;
        private string direccion;

        public Cliente(string nombre, string apellido, int telefono, string direccion)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.direccion = direccion;
        }

        public Cliente(int id, string nombre, string apellido, int telefono, string direccion):this(nombre,apellido,telefono,direccion)
        {
            this.id = id;
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }


        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

    }
}