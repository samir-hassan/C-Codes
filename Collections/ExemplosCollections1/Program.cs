using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExemplosCollections1
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Arrays 

            //var codAntigo = new CodigoAntigo();
            //codAntigo.execute();

            #endregion

            #region Listas

            //var codigoAntigo2 = new CodigoAntigo2();
            //codigoAntigo2.execute();

            #endregion

            #region Listas com Classes

            //var codigoAntigo3 = new CondigoAntigo3();
            //codigoAntigo3.execute();

            #endregion

            #region HashSets e Dictionary

            //var codigoAntigo4 = new CodigoAntigo4();
            //codigoAntigo4.execute();

            #endregion

            #region Lista Ligada
            // Lista Ligada
            //1. Cada elemento é um nó que contem um valor, esse nó tem a informação do nó anterior e próximo

            LinkedList<string> frutas = new LinkedList<string>();
            var f1 = frutas.AddFirst("Banana");
            var f2 = frutas.AddBefore(f1, "Maçã");
            var f3 = frutas.AddAfter(f2, "Amora");

            //Console.WriteLine(frutas.Contains("Amora"));

            //Console.WriteLine(f1.Value);

            frutas.Remove(f3.Previous);

            foreach (var f in frutas)
                Console.WriteLine(f);
            #endregion

            #region PILHA 
            Console.Clear();

            var navegador = new Navegador();
            navegador.navegarTo("google");
            navegador.navegarTo("Alura");

            navegador.Anterior();

            navegador.proximo();

            navegador.proximo();

            navegador.navegarTo("Globo");
            navegador.navegarTo("facebook");

            navegador.Anterior();

            navegador.Anterior();

            navegador.Anterior();

            navegador.Anterior();

            navegador.Anterior();

            #endregion

            #region Fila
            Console.Clear();

            Queue<string> pedagio = new Queue<string>();

            Console.WriteLine("Entrou na Fila "+ "Carro");
            pedagio.Enqueue("Carro");

            Console.WriteLine("Entrou na Fila " + "Carro1");
            pedagio.Enqueue("Carro1");

            Console.WriteLine("Entrou na Fila " + "Carro2");
            pedagio.Enqueue("Carro2");

            pedagio.Dequeue(); // Retirar o primeiro da fila

            pedagio.Any(); // Verificar se tem alguem na fila

            Console.WriteLine(pedagio.Peek()); // Verificar o Primeiro da fila
            

            #endregion

            Thread.Sleep(3000);


        }
    }

    internal class Navegador
    {
        private readonly Stack<string> historicoAnterior = new Stack<string>();
        private readonly Stack<string> historicoProx = new Stack<string>();

        public Navegador()
        {
            historicoAnterior.Push("Vazia");
            Console.WriteLine("Pagina Atual: " + historicoAnterior.First());
        }

        internal void Anterior()
        {

            if (historicoAnterior.Count() > 1)
            {
                historicoProx.Push(historicoAnterior.First());

                historicoAnterior.Pop();

                Console.WriteLine("Pagina Atual: " + historicoAnterior.First());

            }
            else
            {
                Console.WriteLine("Não Possui Anterior");
            }

        }

        internal void navegarTo(string v)
        {
            historicoAnterior.Push(v);
            Console.WriteLine("Pagina Atual " + historicoAnterior.First());
        }

        internal void proximo()
        {
            if (historicoProx.Any())
            {
                historicoAnterior.Push(historicoProx.First());
                Console.WriteLine("Pagina Atual: " + historicoProx.First());
                historicoProx.Pop();
            }
            else
            {
                Console.WriteLine("Não Possui Prox");
            }
        }
    }
}
