using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaArbolArchivos
{
    public class ArbolSistemaArchivos
    {
        // Punto de entrada del árbol. Todos los nodos son accesibles desde aquí
        public NodoArchivo raiz { get; private set; }

        // Al crear el árbol se genera automáticamente el nodo raíz como carpeta base
        public ArbolSistemaArchivos()
        {
            raiz = new NodoArchivo("root", TipoNodo.Carpeta);
        }

        // Busca el nodo padre por nombre y le agrega un nuevo hijo con el nombre y tipo indicados.
        // Retorna false si el padre no existe o no es una carpeta
        public bool agregarNodo(string rutaPadre, string nombreHijo, TipoNodo tipo)
        {
            NodoArchivo padre = Buscar(rutaPadre);
            if (padre == null || !padre.esCarpeta) return false;

            padre.agregarHijo(new NodoArchivo(nombreHijo, tipo));
            return true;
        }

        // Método público que inicia la búsqueda DFS desde la raíz
        public NodoArchivo Buscar(string nombre)
        {
            return BuscarDFS(raiz, nombre);
        }

        // Búsqueda recursiva en profundidad (DFS). Revisa el nodo actual y luego
        // cada rama hijo hasta encontrar el nodo o agotar el árbol
        private NodoArchivo BuscarDFS(NodoArchivo nodo, string nombre)
        {
            if (nodo.nombre == nombre) return nodo;

            foreach (var hijo in nodo.hijos)
            {
                var resultado = BuscarDFS(hijo, nombre);
                if (resultado != null) return resultado;
            }

            return null;
        }

        // Construye la ruta absoluta del nodo subiendo por las referencias padre
        // hasta llegar a la raíz, insertando cada nombre al inicio de la lista
        public string obtenerRuta(NodoArchivo nodo)
        {
            if (nodo == null) return string.Empty;

            var partes = new List<string>();
            var actual = nodo;

            while (actual != null)
            {
                partes.Insert(0, actual.nombre); // Inserta al inicio para mantener el orden correcto
                actual = actual.padre;
            }

            return "/" + string.Join("/", partes);
        }

        // Inicia el recorrido preorden desde la raíz y devuelve la lista de nodos visitados
        public List<string> recorridoPreOrden()
        {
            var resultado = new List<string>();
            PreOrdenRec(raiz, resultado);
            return resultado;
        }

        // Recorrido preorden: registra el nodo actual antes de visitar sus hijos
        private void PreOrdenRec(NodoArchivo nodo, List<string> lista)
        {
            lista.Add($"[{nodo.tipo}] {obtenerRuta(nodo)}");
            foreach (var hijo in nodo.hijos)
                PreOrdenRec(hijo, lista);
        }

        // Inicia el recorrido postorden desde la raíz y devuelve la lista de nodos visitados
        public List<string> recorridoPostOrden()
        {
            var resultado = new List<string>();
            PostOrdenRec(raiz, resultado);
            return resultado;
        }

        // Recorrido postorden: visita todos los hijos antes de registrar el nodo actual
        private void PostOrdenRec(NodoArchivo nodo, List<string> lista)
        {
            foreach (var hijo in nodo.hijos)
                PostOrdenRec(hijo, lista);
            lista.Add($"[{nodo.tipo}] {obtenerRuta(nodo)}");
        }

        // Métodos públicos que delegan al método interno Contar con el tipo correspondiente
        public int ContarArchivos() => Contar(raiz, TipoNodo.Archivo);
        public int ContarCarpetas() => Contar(raiz, TipoNodo.Carpeta);

        // Recorre el árbol recursivamente contando los nodos que coincidan con el tipo dado
        private int Contar(NodoArchivo nodo, TipoNodo tipo)
        {
            int count = (nodo.tipo == tipo) ? 1 : 0;
            foreach (var hijo in nodo.hijos)
                count += Contar(hijo, tipo);
            return count;
        }

        // Carga la estructura de ejemplo definida en el enunciado del proyecto
        public void cargarEjemplo()
        {
            // Carpetas principales bajo root
            agregarNodo("root", "documentos", TipoNodo.Carpeta);
            agregarNodo("root", "fotos", TipoNodo.Carpeta);
            agregarNodo("root", "sistema", TipoNodo.Carpeta);

            // Archivos dentro de documentos
            agregarNodo("documentos", "cv.pdf", TipoNodo.Archivo);
            agregarNodo("documentos", "manual.pdf", TipoNodo.Archivo);

            // Subcarpeta y archivo dentro de fotos
            agregarNodo("fotos", "vacaciones", TipoNodo.Carpeta);
            agregarNodo("fotos", "foto_perfil.jpg", TipoNodo.Archivo);

            // Archivos dentro de vacaciones
            agregarNodo("vacaciones", "playa.jpg", TipoNodo.Archivo);
            agregarNodo("vacaciones", "volcan.jpg", TipoNodo.Archivo);

            // Archivo dentro de sistema
            agregarNodo("sistema", "config.sys", TipoNodo.Archivo);
        }
    }
}