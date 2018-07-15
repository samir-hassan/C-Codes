using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosCollections1
{
    class Aluno
    {
        private string nome;

        public Aluno(string nome, int numMatricula)
        {
            this.nome = nome;
            this.numMatricula = numMatricula;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private int numMatricula;

        public int NumMatricula
        {
            get { return numMatricula; }
            set { numMatricula = value; }
        }

        public override string ToString()
        {
            return $"Aluno: {this.nome} Matricula: {this.NumMatricula}";
        }
    }
}
