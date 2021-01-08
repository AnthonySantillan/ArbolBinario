using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbolB
{
    public class Administrador
    {
        public void CrearArbol(Nodo nodo, string expresionMatematica)
        {
            if (expresionMatematica.Length == 1)
            {
                nodo.Nombre = expresionMatematica.Substring(0, 1);
            }
            else
            {
                int indiceOperador = BuscarOperador(expresionMatematica);
                Console.WriteLine("indice operador" + indiceOperador);
                var operandoIzquierdo = expresionMatematica.Substring(0, indiceOperador);
                Console.WriteLine("operando izquierdo" + operandoIzquierdo);
                nodo.Nombre = expresionMatematica.Substring(indiceOperador,0);
                nodo.Izquierdo = new Nodo(operandoIzquierdo);

                nodo.Derecho = new Nodo();
                Console.WriteLine("indice operador mas " + expresionMatematica.Substring(indiceOperador + 1));

                CrearArbol(nodo.Derecho, expresionMatematica.Substring(indiceOperador + 1));
            }

        }
        private int BuscarOperador(string expresionMatematica)
        {

            char[] expresionMatematicaCh = expresionMatematica.ToCharArray();
            int iterador;
            int posicion=0;
            for(iterador=0; iterador < expresionMatematicaCh.Length; iterador++)
            {
                if (expresionMatematica[iterador] == '+' || expresionMatematica[iterador] == '-')
                {
                    posicion = iterador;
                    return posicion;
                }
            }
            return posicion;
        }
        public void RecorrerArbol(Nodo nodo)
        {
            if(nodo == null)
                return;

            Console.WriteLine(nodo.Nombre);
            RecorrerArbol(nodo.Izquierdo);
            RecorrerArbol(nodo.Derecho);
        }
        public bool EsNumero(string nombre)
        {
            if (nombre != "+") 
                return true;
            else
                return false;
        }
        public int ConvertirEnNumero(string numero)
        {
            return int.Parse(numero);
        }
        
        public int SumarArbol(Nodo nodo)
        {
            if(!EsNumero(nodo.Nombre) || nodo==null){
                int izquierdo = SumarArbol(nodo.Derecho);
                int derecho = SumarArbol(nodo.Izquierdo);
                return (izquierdo + derecho);
            }
            else
            {
                return (ConvertirEnNumero(nodo.Nombre));
            }
        }
        public void NavegarHorizontal(Nodo nodo)
        {
            if(nodo == null)
            {
                return; 
            }
            NavegarHorizontal(nodo.Derecho);
            NavegarHorizontal(nodo.Izquierdo);
            Console.WriteLine(nodo.Nombre);
        }
    }
}
