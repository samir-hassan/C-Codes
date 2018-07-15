using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExemplosCollections1
{
    class CodigoAntigo
    {
        internal void execute()
        {
            List<string> listaString = new List<string>();

            listaString.Add("1 Adicionado");
            listaString.Add("2 Adicionado");
            listaString.Add("3 Adicionado");

            Imprimir(listaString);

            Console.WriteLine(listaString.First());

            Console.WriteLine(listaString.Last());

            Console.WriteLine("Contains: " + listaString.FirstOrDefault(pos => pos.Contains("3")));

            listaString.RemoveAt(listaString.Count - 1);
            Imprimir(listaString);

            listaString.Sort();
            Imprimir(listaString);

            var listaCopiada = listaString.GetRange(0, listaString.Count);

            Console.WriteLine("Copiada");
            Imprimir(listaCopiada);

            var clone = new List<string>(listaString);
            Console.WriteLine("clone");
            Imprimir(clone);

            Thread.Sleep(5000);
        }

        private static void Imprimir(List<string> listaString)
        {
            listaString.ForEach(pos =>
            {
                Console.WriteLine(pos);
            });
        }
    }
}
