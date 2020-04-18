using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial
{
    public class Grafo
    {

        public List<Nodo> Nodos { get; set; }

        public int ContarNodos()
        {
            // Obtenemos el número de nodos que tiene el grafo 
            return Nodos.Count;
        } 

        public bool Buscar(int valor)
        {
            // verificamos que en el listado de nodos exista el valor recorriendolo
            foreach (var nodo in Nodos)
            {
                // si el valor se encuentra en algun nodo, retornamos verdadero
                if (nodo.Valor == valor)
                    return true;
            }

            //en caso de no encontrar el valor retornamos falso
            return false;
        }

        public bool EsArbol()
        {
            //Validar que para ningun nodo haya un loop en el grafo 
            foreach (var nodo in Nodos)
            {
                // se revisa en cada conexion del nodo
                foreach (var conexion in nodo.Conexiones)
                {
                    if (conexion != null && conexion.Buscar(nodo, nodo))
                        return false;
                }
            }
            return true;
        }

        public void CrearArbolBinario(List<Nodo> nodos)
        {
            Nodos = new List<Nodo>();
            foreach (var nodo in nodos)
            {
                // aqui se agrega el nodo al grafo y se le inicializa las 3 posibles conexiones que son el padre y los dos hijos
                Nodos.Add(nodo);
                nodo.IniciarNodoArbol();

                // solo se le asigna hijos despues del primer nodo
                if (Nodos.Count > 1)
                    Nodos.First().AsignarNodo(nodo);
            }
        }

        public bool BinarySearch(int busqueda)
        { 
            if (Nodos.Count > 0)
                // aqui se llama a la funcion recursiva que revisa la existencia del valor solicitado
                return Nodos.First().BuscarValor(busqueda);
            else
                return false;
        } 
    }
}
