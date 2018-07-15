using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosCollections1
{
    class Aula : IComparable
    {

        private string titulo;
        private int tempo;

        public Aula(string titulo, int tempo)
        {
            this.Titulo = titulo;
            this.Tempo = tempo;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public int Tempo { get => tempo; set => tempo = value; }

        public int CompareTo(object obj)
        {
            var objCasted = obj as Aula;
            return this.titulo.CompareTo(objCasted.titulo);
        }
    }
}
