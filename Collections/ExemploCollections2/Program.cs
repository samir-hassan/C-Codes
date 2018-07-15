using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExemploCollections2
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Dictionary Normal

            // SORTED LIST
            //1. Utiliza Dicionário

            IDictionary<string, Aluno> alunos = new Dictionary<string, Aluno>();
            alunos.Add("A1", new Aluno("Samir", 15200492));
            alunos.Add("A2", new Aluno("Vanessa", 15200493));
            alunos.Add("A3", new Aluno("Ana", 15200494));

            Imprimir(alunos, "");

            //Removendo
            alunos.Remove("A1");

            //Adicionando
            alunos.Add("A4", new Aluno("Marcelo", 15200495));

            Imprimir(alunos, "Após Removido e Adicionado");

            #endregion

            #region SORTED LIST

            //2. Não temos a certeza da ordem dos item adicionados, nao dependendo da ordem de inserção
            //3. Para que consigamos ordenar, é necessário usar o SORTED LIST
            //4. SORTED LIST implementa um IDictionary
            //5. Para cada inserção no SORTED LIST ele vai se ordenando automaticamente
            //6. ELE NÃO É UMA LISTA
            //7. IDEAL PARA QUANDO JA TEMOS ELEMENTOS PRÉ-DETERMINADOS E NÃO SOFRERÁ MUITAS ALTERAÇÕES

            IDictionary<string, Aluno> sortedList = new SortedList<string, Aluno>();
            sortedList.Add("A1", new Aluno("Samir", 15200492));
            sortedList.Add("A3", new Aluno("Vanessa", 15200493));
            sortedList.Add("A2", new Aluno("Ana", 15200494));

            Imprimir(sortedList, "Imprimindo Sorted List");
            #endregion

            #region SORTED DICTIONARY

            //1. Tambem implementa o IDictionary
            //2. IDEAL PARA QUANDO NÃO TEMOS ELEMENTOS PRÉ-DETERMINADOS E SOFRERÁ MUITAS ALTERAÇÕES

            IDictionary<string, Aluno> sortedDic = new SortedDictionary<string, Aluno>();
            sortedDic.Add("A1", new Aluno("Samir", 15200492));
            sortedDic.Add("A3", new Aluno("Vanessa", 15200493));
            sortedDic.Add("A2", new Aluno("Ana", 15200494));

            Imprimir(sortedDic, "Imprimindo Sorted Dictionary");
            #endregion

            #region SORTED SET

            //HASHSET, que nao aceita valores duplicados, que ordena automaticamente na inserção

            ISet<string> alunosHash = new SortedSet<string>(new KeyInsensitive());
            alunosHash.Add("Samir");
            alunosHash.Add("Joao");
            alunosHash.Add("Samir"); //Não será inserido
            alunosHash.Add("SAMIR"); // Com o comparer passado no parametro do Sorted ele ignora maiusculos e minusculos

            ImprimirHash(alunosHash, "Imprimindo Hash");

            #endregion

            #region ARRAY Multidimensional

            string[,] biArray = new string[3,3];

            biArray[0, 0] = "Alemanha";
            biArray[1, 0] = "Brasil";
            biArray[2, 0] = "Argentina";

            biArray[0, 1] = "Alemanha";
            biArray[1, 1] = "Brasil";
            biArray[2, 1] = "Argentina";

            biArray[0, 2] = "Alemanha";
            biArray[1, 2] = "Brasil";
            biArray[2, 2] = "Argentina";

            foreach (var copa in biArray)
            {
                Console.WriteLine(copa);
            }


            #endregion

            Thread.Sleep(3000);

        }

        private static void ImprimirHash(ISet<string> alunosHash, string linha)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(linha);
            foreach (var aluno in alunosHash)
            {
                Console.WriteLine(aluno);
            }
        }

        private static void Imprimir(IDictionary<string, Aluno> alunos, string linha)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(linha);
            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }
        }
    }

    internal class KeyInsensitive : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
