using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaArbolArchivos
{
    public class ArbolSistemaArchivos
    {

        public NodoArchivo raiz { get; private set; }

        public ArbolSistemaArchivos()
        {
            raiz = new NodoArchivo("root", TipoNodo.Carpeta);
        }

        // Metodo para agregar nodo por ruta
        public bool agregarNodo(string  rutaPadre, string nombreHijo, TipoNodo tipo)
        {
            NodoArchivo padre = Buscar(rutaPadre);
            if (padre == null || !padre.esCarpeta) return false;

            padre.agregarHijo(new NodoArchivo(nombreHijo, tipo));
            return true;
        }




        // Busqueda
        public NodoArchivo Buscar(string nombre)
        {
            return BuscarDFS(raiz, nombre);
        }

        private NodoArchivo BuscarDFS(NodoArchivo nodo, string nombre)
        {
            if (nodo.nombre == nombre) return nodo; 

            foreach(var hijo in nodo.hijos)
            {
                var resultado = BuscarDFS(hijo, nombre);
                if (resultado != null) return resultado;
            }

            return null; 
        }


        // Metodo para obtener ruta absoluta
        public string obtenerRuta(NodoArchivo nodo)
        {
            if (nodo == null) return string.Empty;

            var partes = new List<string>();
            var actual = nodo;

            while (actual != null)
            {
                partes.Insert(0, actual.nombre);
                actual = actual.padre;
            }

            return "/" + string.Join("/", partes);
        }

        // Recorrido Preorden
        public List<string> recorridoPreOrden()
        {
            var resultado = new List<string>();
            PreOrdenRec(raiz, resultado);
            return resultado;
            
        }

        private void PreOrdenRec(NodoArchivo nodo, List<string> lista)
        {
            lista.Add($"[{nodo.tipo}] {obtenerRuta(nodo)}");
            foreach (var hijo in nodo.hijos)
            {
                PreOrdenRec(hijo, lista);
            }
        }


        // Recorrido Postorden
        public List<string> recorridoPostOrden()
        {
            var resultado = new List<string>();
            PostOrdenRec(raiz, resultado);
            return resultado;
        }

        private void PostOrdenRec(NodoArchivo nodo, List<string> lista)
        {
            foreach (var hijo in nodo.hijos)
            {
                PostOrdenRec(hijo, lista);
            }
            lista.Add($"[{nodo.tipo}] {obtenerRuta(nodo)}");
        }


        // Variables de conteo de nodos
        public int ContarArchivos() => Contar(raiz, TipoNodo.Archivo);
        public int ContarCarpetas() => Contar(raiz, TipoNodo.Carpeta);

        private int Contar(NodoArchivo nodo, TipoNodo tipo)
        {
            int count = (nodo.tipo == tipo) ? 1 : 0;
            foreach(var hijo in nodo.hijos)
            {
                count += Contar(hijo, tipo);
            }
            return count;
        }


        // Cargar ejemplo del enunciado
        public void cargarEjemplo()
        {
            // Carpetas principales
            agregarNodo("root", "documentos", TipoNodo.Carpeta);
            agregarNodo("root", "fotos", TipoNodo.Carpeta);
            agregarNodo("root", "sistema", TipoNodo.Carpeta);

            // Documentos
            agregarNodo("documentos", "cv.pdf", TipoNodo.Archivo);
            agregarNodo("documentos", "manual.pdf", TipoNodo.Archivo);

            // Fotos
            agregarNodo("fotos", "vacaciones", TipoNodo.Carpeta);
            agregarNodo("fotos", "foto_perfil.jpg", TipoNodo.Archivo);

            // Vacaciones
            agregarNodo("vacaciones", "playa.jpg", TipoNodo.Archivo);
            agregarNodo("vacaciones", "volcan.jpg", TipoNodo.Archivo);

            // Sistema
            agregarNodo("sistema", "config.sys", TipoNodo.Archivo);
        }
    }
}
