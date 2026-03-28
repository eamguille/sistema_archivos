namespace SistemaArbolArchivos
{
    public partial class Form1 : Form
    {

        private ArbolSistemaArchivos arbol;

        public Form1()
        {
            InitializeComponent();
            arbol = new ArbolSistemaArchivos();
            arbol.cargarEjemplo();
            refrescarTreeView();
        }

        // Metodo para refrescar el treeView
        private void refrescarTreeView()
        {
            treeViewArchivos.Nodes.Clear();
            var raizUI = CrearNodoUI(arbol.raiz);
            treeViewArchivos.Nodes.Add(raizUI);
            treeViewArchivos.ExpandAll();
        }

        private TreeNode CrearNodoUI(NodoArchivo nodo)
        {
            string icono = nodo.esCarpeta ? "/" : "";
            var nodoUI = new TreeNode(icono + nodo.nombre);
            nodoUI.Tag = nodo;

            foreach (var hijo in nodo.hijos)
            {
                nodoUI.Nodes.Add(CrearNodoUI(hijo));
            }

            return nodoUI;
        }

        // Metodo para cargar nodos despyes de seleccionar nodo en el arbol de nodos
        private void treeViewArchivos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is NodoArchivo nodo)
            {
                lblRuta.Text = arbol.obtenerRuta(nodo);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string padre = txtNodoPadre.Text.Trim();
            string hijo = txtNodoHijo.Text.Trim();

            if (string.IsNullOrEmpty(padre) || string.IsNullOrEmpty(hijo))
            {
                MessageBox.Show("Completa los campos de padre e hijo.", "Aviso");
                return;
            }

            TipoNodo tipo = rbCarpeta.Checked ? TipoNodo.Carpeta : TipoNodo.Archivo;
            bool ok = arbol.agregarNodo(padre, hijo, tipo);

            if (ok)
            {
                refrescarTreeView();
                txtNodoHijo.Clear();
                listBoxResultados.Items.Add($"Nodo '{hijo}' agregado bajo '{padre}'.");
            }
            else
            {
                MessageBox.Show($"No se encontro la carpeta '{padre}' o no es una carpeta.", "Error");
            }
        }

        // Metodo para buscar nodos
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscar.Text.Trim();
            if (string.IsNullOrEmpty(nombre)) return;

            NodoArchivo encontrado = arbol.Buscar(nombre);
            listBoxResultados.Items.Clear();

            if (encontrado != null)
            {
                listBoxResultados.Items.Add($"Encontrado: {encontrado.nombre}");
                listBoxResultados.Items.Add($"  Tipo: {encontrado.tipo}");
                listBoxResultados.Items.Add($"  Ruta: {arbol.obtenerRuta(encontrado)}");
                lblRuta.Text = arbol.obtenerRuta(encontrado);
                txtBuscar.Clear();
            }
            else
            {
                listBoxResultados.Items.Add($"'{nombre}' no encontrado.");
            }
        }

        private void btnPreorden_Click(object sender, EventArgs e)
        {
            listBoxResultados.Items.Clear();
            listBoxResultados.Items.Add(" RECORRIDO PREORDEN ");
            foreach (var linea in arbol.recorridoPreOrden())
            {
                listBoxResultados.Items.Add(linea);
            }
        }

        private void btnPostorden_Click(object sender, EventArgs e)
        {
            listBoxResultados.Items.Clear();
            listBoxResultados.Items.Add(" RECORRIDO POSTORDEN ");
            foreach (var linea in arbol.recorridoPostOrden())
            {
                listBoxResultados.Items.Add(linea);
            }
        }

        private void btnConteo_Click(object sender, EventArgs e)
        {
            listBoxResultados.Items.Clear();
            listBoxResultados.Items.Add("CONTEO DE ELEMENTOS:");
            listBoxResultados.Items.Add($"Carpetas: {arbol.ContarCarpetas()}");
            listBoxResultados.Items.Add($"Archivos: {arbol.ContarArchivos()}");
            listBoxResultados.Items.Add($"  Total: {arbol.ContarCarpetas() + arbol.ContarArchivos()}");
        }

        private void lblRuta_Click(object sender, EventArgs e)
        {

        }

    }
}
