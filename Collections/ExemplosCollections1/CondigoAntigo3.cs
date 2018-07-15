using System;
using System.Threading;

namespace ExemplosCollections1
{
    internal class CondigoAntigo3
    {

        internal void execute()
        {
            throw new NotImplementedException();
            var curso1 = new Curso("Samir", "Pedro");
            curso1.AdicionaAula(new Aula("Geografia", 50));
            curso1.AdicionaAula(new Aula("Matematica", 60));

            Imprimir(curso1);

            Console.WriteLine(curso1.tempoTotal);

            Thread.Sleep(3000);

            var codigoAntigo3 = new CondigoAntigo3();
            codigoAntigo3.execute();

        }

        private static void Imprimir(Curso curso1)
        {
            Console.WriteLine($"Aluno: {curso1.Nome} Professor: {curso1.Instrutor}");
        }
    }
}