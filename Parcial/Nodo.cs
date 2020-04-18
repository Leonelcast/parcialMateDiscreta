using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial
{
    public class Nodo
    {
        // el valor del nodo y el listado de los diferentes grafos que están conectados a el 
        public int Valor { get; set; }
        public List<Nodo> Conexiones { get; set; }

        public bool Buscar(Nodo nodo, Nodo desde)
        {
            // esta funcion lo que hace es buscar entre las conexiones si existe una conexion hacie el nodo que se está buscando
            // pero ignorando el nodo desde donde se está realizando la búsqueda
            if (Conexiones.Count > 0)
                foreach (var conexion in Conexiones.Where(x => x != desde))
                {
                    if (conexion != null)
                        if (conexion == nodo || conexion.Buscar(nodo, this))
                            return true;
                }

            return false;
        }

        public void IniciarNodoArbol()
        {
            // esto inicializa el nodo para tener 3 conexiones, que son el padre y los dos hijos
            Conexiones = new List<Nodo>(3);
            for (int i = 0; i <= 2; i++)
                Conexiones.Add(null);
        }

        public void SetPadre(Nodo nodoPadre)
        {
            // aqui se asgina en la primer conexion la referencia al nodo padre
            Conexiones[0] = nodoPadre;
        }

        public void AsignarNodo(Nodo nodo)
        {
            // si el valor que se quiere agregar al arbol es mayor se agrega a la derecha
            if (nodo.Valor >= this.Valor)
            {
                // si la conexion en ese lado ya está ocupada se le delega la asignacion del nuevo nodo al hijo en esa posición
                if (Conexiones[2] == null)
                {
                    Conexiones[2] = nodo;
                    Conexiones[2].SetPadre(this);
                } else
                {
                    Conexiones[2].AsignarNodo(nodo);
                }
            }
            // si es menor se agrega de lado izquierdo de las conexiones
            else
            {
                // si la conexion en ese lado ya está ocupada se le delega la asignacion del nuevo nodo al hijo en esa posición
                if (Conexiones[1] == null)
                {
                    Conexiones[1] = nodo;
                    Conexiones[1].SetPadre(this);
                } else
                {
                    Conexiones[1].AsignarNodo(nodo);
                }
            }
        }

        // esta es la función recursiva que busca un valor en el arbol binario 
        public bool BuscarValor(int valor)
        {
            // si el valor que se busac coincide con el del nodo actual se retorna directamente verdadero
            if (this.Valor == valor)
                return true;

            // si el valor es mayor se empieza a buscar exclusivamente en los nodos de la rama derecha
            if (valor >= this.Valor)
            {
                // si la conexion en los nodos es nula eso quiere decir que el valor no está en el arbol
                if (Conexiones[2] == null)
                    return false;

                return Conexiones[2].BuscarValor(valor);
            }
            // si el valor es menor se busca exclusicamente en los nodos de la rama izquierda
            else
            { 
                // si la conexion en los nodos es nula eso quiere decir que el valor no está en el arbol
                if (Conexiones[1] == null)
                    return false;
                return Conexiones[1].BuscarValor(valor);
            }
        }
    }
}
