using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploCollections2
{
    class Aluno
    {
        private string nome;
        
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private int matricula;

        public int Matricula
        {
            get { return matricula; }
        }

        public Aluno(string nome, int matricula)
        {
            this.nome = nome;
            this.matricula = matricula;
        }

        public override string ToString()
        {
            return $"Nome: {this.nome}, Matrícula: {this.matricula}";
        }


    }
}
