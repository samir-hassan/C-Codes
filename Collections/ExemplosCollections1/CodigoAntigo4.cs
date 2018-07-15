using System;
using System.Collections.Generic;
using System.Threading;

namespace ExemplosCollections1
{
    internal class CodigoAntigo4
    {
        public CodigoAntigo4()
        {
        }

        internal void execute()
        {
            // SETS - CONJUNTOS
            // 1. Não Permite Duplicidade
            // 2. Os elementos nao possuem ordem Especifica
            // 3. Menor Tempo de Busca

            ISet<string> alunos = new HashSet<string>();
            alunos.Add("Samir");
            alunos.Add("Cleber");
            alunos.Add("Marquito");
            alunos.Add("Marquito"); // Nao será Adicionado

            alunos.Remove("Marquito");
            alunos.Add("Maui");

            var copiaHash = new List<string>(alunos);
            copiaHash.Sort();

            Console.WriteLine("- Ordenado: " + string.Join(",", copiaHash));
            Console.WriteLine(string.Join(",", alunos));

            var a1 = new Aluno("Samir", 152);
            var curso1 = new Curso("Portugues", "Prof");
            curso1.AdicionaAula(new Aula("linguas", 50));
            curso1.Matricula(a1);
            curso1.SubstituiAluno(new Aluno("TK", 152));


            Console.WriteLine(string.Join(",", curso1.Alunos));

            Console.WriteLine($"O aluno {a1.Nome} está Matriculado ?");
            Console.WriteLine(curso1.estaMatriculado(a1));


            // DICIONÁRIOS

            Console.Clear();

            var a = curso1.BuscaMatricula(152);
            Console.WriteLine(a);

            Thread.Sleep(5000);
        }
    }
}