using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaArbolArchivos
{
    // Define los dos únicos tipos válidos que puede tener un nodo en el sistema
    public enum TipoNodo
    {
        Carpeta,
        Archivo
    }

    public class NodoArchivo
    {
        // Propiedades principales del nodo
        public string nombre { get; set; }           // Nombre del nodo (ej: "documentos", "cv.pdf")
        public TipoNodo tipo { get; set; }           // Indica si es Carpeta o Archivo
        public List<NodoArchivo> hijos { get; set; } // Nodos contenidos dentro de este nodo (solo aplica a carpetas)
        public NodoArchivo padre { get; set; }       // Referencia al nodo que contiene a este, null si es la raíz

        // Inicializa el nodo con nombre y tipo. La lista de hijos se crea vacía
        // y el padre se deja en null hasta que el nodo sea insertado en el árbol
        public NodoArchivo(string pnombre, TipoNodo ptipo)
        {
            nombre = pnombre;
            tipo = ptipo;
            hijos = new List<NodoArchivo>();
            padre = null;
        }

        // Propiedades de solo lectura que evalúan el tipo del nodo
        public bool esCarpeta => tipo == TipoNodo.Carpeta;
        public bool esArchivo => tipo == TipoNodo.Archivo;

        // Agrega un nodo hijo a este nodo. Solo se permite si el nodo actual es una carpeta.
        // También establece la referencia padre-hijo en ambas direcciones
        public void agregarHijo(NodoArchivo hijo)
        {
            if (!esCarpeta)
                throw new InvalidOperationException("Solo carpetas pueden tener nodos hijos.");

            hijo.padre = this; // El hijo ahora conoce quién es su padre
            hijos.Add(hijo);   // El padre registra al hijo en su lista
        }

        // Devuelve el nombre del nodo cuando se convierte a string (útil para depuración)
        public override string ToString() => nombre;
    }
}