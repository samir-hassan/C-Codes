using System;
using System.Collections.Generic;
using System.Threading;

namespace ExemplosCollections1
{
    internal class CodigoAntigo2
    {
        internal void execute()
        {
            var aula1 = new Aula("aula1", 10);
            var aula2 = new Aula("aula2", 10);
            var aula3 = new Aula("aula3", 10);
            var aula4 = new Aula("aula4", 10);

            List<Aula> aulas = new List<Aula>();
            aulas.Add(aula1);
            aulas.Add(aula2);
            aulas.Add(aula3);
            aulas.Add(aula4);

            imprimir(aulas);

            aulas.Reverse();
            aulas.Sort();
            imprimir(aulas);

            Thread.Sleep(3000);
        }

        private static void imprimir(List<Aula> aulas)
        {
            aulas.ForEach(aula => Console.WriteLine(aula.Titulo));
        }

    }
}