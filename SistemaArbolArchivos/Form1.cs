namespace SistemaArbolArchivos
{
    public partial class Form1 : Form
    {
        // Instancia del árbol que maneja toda la lógica de datos
        private ArbolSistemaArchivos arbol;

        // Al iniciar el formulario se crea el árbol, se carga el ejemplo y se dibuja el TreeView
        public Form1()
        {
            InitializeComponent();
            arbol = new ArbolSistemaArchivos();
            arbol.cargarEjemplo();
            refrescarTreeView();
        }

        // Limpia el TreeView y lo reconstruye completo desde la raíz del árbol
        private void refrescarTreeView()
        {
            treeViewArchivos.Nodes.Clear();
            var raizUI = CrearNodoUI(arbol.raiz);
            treeViewArchivos.Nodes.Add(raizUI);
            treeViewArchivos.ExpandAll();
        }

        // Convierte un NodoArchivo en un TreeNode visual de forma recursiva.
        // Guarda la referencia al NodoArchivo en la propiedad Tag para uso posterior
        private TreeNode CrearNodoUI(NodoArchivo nodo)
        {
            string icono = nodo.esCarpeta ? "/" : "";
            var nodoUI = new TreeNode(icono + nodo.nombre);
            nodoUI.Tag = nodo; // Vincula el nodo visual con el nodo lógico del árbol

            foreach (var hijo in nodo.hijos)
                nodoUI.Nodes.Add(CrearNodoUI(hijo));

            return nodoUI;
        }

        // Se ejecuta cada vez que el usuario hace clic en un nodo del TreeView.
        // Recupera el NodoArchivo desde Tag y muestra su ruta absoluta en la etiqueta
        private void treeViewArchivos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is NodoArchivo nodo)
                lblRuta.Text = arbol.obtenerRuta(nodo);
        }

        // Valida los campos, determina el tipo de nodo según el RadioButton seleccionado
        // e intenta agregar el nodo al árbol. Refresca el TreeView si la operación es exitosa
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

        // Busca un nodo por nombre en el árbol y muestra su tipo y ruta en el ListBox.
        // Si no se encuentra, informa al usuario
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

        // Ejecuta el recorrido preorden y muestra cada nodo en el ListBox
        private void btnPreorden_Click(object sender, EventArgs e)
        {
            listBoxResultados.Items.Clear();
            listBoxResultados.Items.Add("RECORRIDO PREORDEN");
            foreach (var linea in arbol.recorridoPreOrden())
                listBoxResultados.Items.Add(linea);
        }

        // Ejecuta el recorrido postorden y muestra cada nodo en el ListBox
        private void btnPostorden_Click(object sender, EventArgs e)
        {
            listBoxResultados.Items.Clear();
            listBoxResultados.Items.Add("RECORRIDO POSTORDEN");
            foreach (var linea in arbol.recorridoPostOrden())
                listBoxResultados.Items.Add(linea);
        }

        // Cuenta carpetas y archivos por separado y muestra el resumen en el ListBox
        private void btnConteo_Click(object sender, EventArgs e)
        {
            listBoxResultados.Items.Clear();
            listBoxResultados.Items.Add("CONTEO DE ELEMENTOS:");
            listBoxResultados.Items.Add($"Carpetas: {arbol.ContarCarpetas()}");
            listBoxResultados.Items.Add($"Archivos: {arbol.ContarArchivos()}");
            listBoxResultados.Items.Add($"Total:    {arbol.ContarCarpetas() + arbol.ContarArchivos()}");
        }

        // Evento requerido por el diseñador, sin lógica implementada
        private void lblRuta_Click(object sender, EventArgs e) { }
    }
}