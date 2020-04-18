using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciamos la lista de nodos
            List<Nodo> nodos = new List<Nodo>();
            for (int i = 0; i < 5; i++)
            {
                nodos.Add(new Nodo
                {
                    Valor = i,
                    Conexiones = new List<Nodo>()
                });
            }

            // En este bloque del código se agregan las conexiones que existen entre los nodos
            nodos[0].Conexiones.AddRange(new List<Nodo> { nodos[1], nodos[4] });
            nodos[1].Conexiones.AddRange(new List<Nodo> { nodos[0], nodos[2], nodos[3], nodos[4] });
            nodos[2].Conexiones.AddRange(new List<Nodo> { nodos[1], nodos[3] });
            nodos[3].Conexiones.AddRange(new List<Nodo> { nodos[1], nodos[2], nodos[4] });
            nodos[4].Conexiones.AddRange(new List<Nodo> { nodos[0], nodos[1], nodos[3] });

            // Aqui se instancia el grafo asignando los nodos con sus conexiones
            Grafo grafo = new Grafo
            {
                Nodos = nodos
            };

            Console.WriteLine(grafo.ContarNodos()); // tiene que imprimir el número 5
            Console.WriteLine(grafo.Buscar(3)); // tiene que imprimir verdadero porque el 3 si es un valor de un nodo
            Console.WriteLine(grafo.Buscar(40)); // tiene que imprimir falso porque el número 40 no corresponde a ningun valor de ningun nodo
            Console.WriteLine(grafo.EsArbol()); // tiene que imprimir falso ya que si se puede llegar a varios nodos por diferentes caminos

            //Inicializando los nodos para el arbol binario
            nodos = new List<Nodo>
            {
                new Nodo
                {
                    Valor = 30
                },
                new Nodo
                {
                    Valor = 10
                },
                new Nodo
                {
                    Valor = 5
                },
                new Nodo
                {
                    Valor = 15
                },
                new Nodo
                {
                    Valor = 50
                },
                new Nodo
                {
                    Valor = 45
                }
            };

            //creando el arbol 
            grafo.CrearArbolBinario(nodos);
            Console.WriteLine(grafo.BinarySearch(3)); // tiene que imprimir falso porque el 3 no se encuentra en el arbol
            Console.WriteLine(grafo.BinarySearch(45)); // tiene que imprimir verdadero porque el número 40 si se encuentra en el arbol
            Console.WriteLine(grafo.EsArbol()); // tiene que imprimir verdadero

            Console.ReadLine();
        }
    }
}
