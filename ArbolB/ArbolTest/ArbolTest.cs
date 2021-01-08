using ArbolB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ArbolTest
{
    [TestClass]
    public class ArbolTest
    {
        [TestMethod]
        public void TestArbolSuma()
        {
            var arbolOperaciones = new Nodo("+",
                new Nodo("5"),
                new Nodo("+",
                    new Nodo("6"),
                    new Nodo("+",
                        new Nodo("-2"),
                            new Nodo("-1"))));
            var admin = new Administrador();
            var resultadoEsperado = 8;

            var resultado = admin.SumarArbol(arbolOperaciones);

            Assert.AreEqual(resultadoEsperado, resultado);
        }
        [TestMethod]
        public void TestContarNodos()
        {
            NodoExt nodo = new NodoExt();
            int resultadoEsperado = 1;
            int resultado = NodoExt.ContarNodos(nodo);

            Assert.AreEqual(resultadoEsperado, resultado);
        }
        [TestMethod]
        public void TestContarNodosSiNuloRetorno0()
        {
            NodoExt nodo=null;

            int resultadoEsperado = 0;
            int resultado = NodoExt.ContarNodos(nodo);

            Assert.AreEqual(resultadoEsperado, resultado);
        }
        [TestMethod]
        public void TestContarNodosConHijos()
        {
            NodoExt nodo = new NodoExt();

            nodo.Hijos = new List<NodoExt>();
            nodo.Hijos.Add(new NodoExt());

            int resultadoEsperado = 2;
            int resultado = NodoExt.ContarNodos(nodo);

            Assert.AreEqual(resultadoEsperado, resultado);
        }
        [TestMethod]
        public void TestContarHojas()
        {
            NodoExt nodo1 = new NodoExt("1");
            NodoExt nodo2 = new NodoExt("2");
            NodoExt nodo3 = new NodoExt("3");
            NodoExt nodo4 = new NodoExt("4");
            NodoExt nodo5 = new NodoExt("5");
            NodoExt nodo6 = new NodoExt("6");
            NodoExt nodo7 = new NodoExt("7");

            //Raiz
            nodo1.Hijos.Add(nodo2);
            nodo1.Hijos.Add(nodo3);

            //
            nodo2.Hijos.Add(nodo4);
            nodo2.Hijos.Add(nodo5);
            //
            nodo3.Hijos.Add(nodo6);
            nodo3.Hijos.Add(nodo7);
            //
            nodo4.Hijos.Add(new NodoExt("8"));
            nodo4.Hijos.Add(new NodoExt("9"));
            nodo5.Hijos.Add(new NodoExt("10"));
            nodo5.Hijos.Add(new NodoExt("11"));

            nodo6.Hijos.Add(new NodoExt("12"));
            nodo6.Hijos.Add(new NodoExt("13"));
            nodo7.Hijos.Add(new NodoExt("14"));
            nodo7.Hijos.Add(new NodoExt("15"));

            int resultadoEsperado = 8;
            int resultado = NodoExt.ContarHojas(nodo1);

            Assert.AreEqual(resultadoEsperado, resultado);
        }
        [TestMethod]
        public void TestContarNiveles()
        {
            NodoExt nodo1 = new NodoExt("1");
            NodoExt nodo2 = new NodoExt("2");
            NodoExt nodo3 = new NodoExt("3");
            NodoExt nodo4 = new NodoExt("4");
            NodoExt nodo5 = new NodoExt("5");
            NodoExt nodo6 = new NodoExt("6");
            NodoExt nodo7 = new NodoExt("7");

            NodoExt nodo10 = new NodoExt("10");
            NodoExt nodo11 = new NodoExt("11");

            //Raiz
            nodo1.Hijos.Add(nodo2);
            nodo1.Hijos.Add(nodo3);

            //
            nodo2.Hijos.Add(nodo4);
            nodo2.Hijos.Add(nodo5);
            //
            nodo3.Hijos.Add(nodo6);
            nodo3.Hijos.Add(nodo7);
            //
            nodo4.Hijos.Add(new NodoExt("12"));
            nodo4.Hijos.Add(new NodoExt("13"));
            //
            nodo5.Hijos.Add(new NodoExt("14"));
            nodo5.Hijos.Add(new NodoExt("15"));
            //
            nodo6.Hijos.Add(new NodoExt("16"));
            nodo6.Hijos.Add(new NodoExt("17"));
            //
            nodo7.Hijos.Add(nodo10);
            nodo7.Hijos.Add(new NodoExt("18"));
            //
            nodo10.Hijos.Add(nodo11);

            int resultadoEsperado = 5;
            int resultado = NodoExt.ContarNiveles(nodo1);

            Assert.AreEqual(resultadoEsperado, resultado);
        }
    }
}
