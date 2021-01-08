using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbolB
{
    public class NodoExt
    {
        public string Nombre { get; set; }
        public NodoExt(string nombre)
        {
            Nombre = nombre;
            Hijos = new List<NodoExt>();
        }
        public NodoExt()
        {

        }
        public object Contenido { get; set; }
        public List<NodoExt> Hijos { get; set; }

        public static int ContarNodos(NodoExt nodo)
        {
            if (nodo == null)
                return 0;
            
            if (nodo.Hijos == null) 
                return 1;

            int nietos = 0;
            for (int i=0; i < nodo.Hijos.Count(); i++)
            {
                nietos += ContarNodos(nodo.Hijos[i]);
            }
            return nietos+1;
        }
        public void PonerValor(object obj)
        {
            this.Contenido = obj;
        }
        public static int ContarHojas(NodoExt nodo)
        {
            if (nodo.Hijos.Count()==0)
                return 1;
            int numeroHojas = 0;
            for(int iterador = 0; iterador < nodo.Hijos.Count(); iterador++)
            {
                numeroHojas += ContarHojas(nodo.Hijos[iterador]);
            }
            return numeroHojas;
        }
        public static int ContarNiveles(NodoExt nodo)
        {
            if (nodo.Hijos.Count() == 0)
                return 0;

            int niveles = 0;
            for (int iterador = 0; iterador < nodo.Hijos.Count(); iterador++)
            {
                if (nodo.Hijos.Count()>0)
                {
                    niveles = ContarHojas(nodo.Hijos[iterador]);
                    niveles++;
                }
            }
            return niveles;
        }
        public static void ImprmirArbolMultiplesHijos(NodoExt nodo)
        {
            Console.WriteLine(nodo.Nombre);
            if (nodo == null)
                Console.WriteLine("El arbol que deseas imprimir no ha sido creado correctamente");
            if (nodo.Hijos == null)
                Console.WriteLine(nodo.Nombre);
            for (int i = 0; i < nodo.Hijos.Count(); i++)
            {
                ImprmirArbolMultiplesHijos(nodo.Hijos[i]);
            }
        }

    }
}
