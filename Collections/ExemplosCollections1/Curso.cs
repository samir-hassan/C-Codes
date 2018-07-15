using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosCollections1
{
    class Curso
    {

        private IDictionary<int, Aluno> dicAlunos = new Dictionary<int, Aluno>();

        private List<Aula> aulas;

        public IList<Aula> Aulas
        {
            get { return new ReadOnlyCollection<Aula>(aulas); }
        }

        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public Curso(string nome, string instrutor)
        {
            this.nome = nome;
            this.instrutor = instrutor;
            this.aulas = new List<Aula>();
        }

        internal void AdicionaAula(Aula aula)
        {
            this.aulas.Add(aula);
        }

        private string instrutor;

        public string Instrutor
        {
            get { return instrutor; }
            set { instrutor = value; }
        }

        private ISet<Aluno> alunos = new HashSet<Aluno>();

        public ISet<Aluno> Alunos
        {
            get { return alunos; }
            set { alunos = value; }
        }


        public int tempoTotal
        {
            get
            {
                return aulas.Sum(aula => aula.Tempo);
            }
        }

        internal IDictionary<int, Aluno> DicAlunos { get => dicAlunos; set => dicAlunos = value; }

        internal void SubstituiAluno(Aluno a1)
        {
            this.dicAlunos[a1.NumMatricula] = a1;
        }

        internal IDictionary<int, Aluno> DicAlunos1 { get => dicAlunos; set => dicAlunos = value; }

        internal void Matricula(Aluno aluno)
        {
            this.alunos.Add(aluno);
            this.dicAlunos.Add(aluno.NumMatricula, aluno);
        }

        internal string estaMatriculado(Aluno a1)
        {
            if (alunos.Contains(a1))
                return "Sim";

            return "Não";
        }

        internal Aluno BuscaMatricula(int v)
        {
            Aluno aluno = null;
            this.dicAlunos.TryGetValue(v, out aluno);

            return aluno;
        }
    }
}
