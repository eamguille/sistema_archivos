using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaArbolArchivos
{

    // Creamos los tipos de nodos que pueden haber (Carpetas o archivos)
    public enum TipoNodo
    {
        Carpeta, 
        Archivo
    }

    public class NodoArchivo
    {

        // Definimos variables iniciales
        public string nombre { get; set; }  
        public TipoNodo tipo { get; set; }
        public List<NodoArchivo> hijos { get; set; }
        public NodoArchivo padre { get; set; }

        
        // Constructor
        public NodoArchivo(string pnombre, TipoNodo ptipo)
        {
            nombre = pnombre;
            tipo = ptipo;
            hijos = new List<NodoArchivo>();
            padre = null;
        }


        // Definimos variables de estado
        public bool esCarpeta => tipo == TipoNodo.Carpeta;
        public bool esArchivo => tipo == TipoNodo.Archivo;

        // Metodo para crear un nodo hijo
        public void agregarHijo(NodoArchivo hijo)
        {
            if(!esCarpeta)
            {
                throw new InvalidOperationException("Solo carpetas pueden tener nodos hijos.");
            }

            hijo.padre = this;
            hijos.Add(hijo);
        }

        public override string ToString() => nombre;
    }
}
