using series.Constantes;
using System;

namespace series.Model
{
    public class Serie : Entidade
    {
        private string Titulo;
        private int Ano;
        private string Descricao;
        private Genero Genero;

        public Serie(string titulo, Genero genero, int ano, string descricao)
        {
            this.Titulo = titulo;
            this.Genero = genero;
            this.Ano = ano;
            this.Descricao = descricao;
        }

        public override string ToString()
        {
            return $"#{this.Id}   Título: {this.Titulo} | Genero: {this.Genero} | Ano: {this.Ano} " + Environment.NewLine + $"Descricao: {this.Descricao}" + Environment.NewLine;
        }
    }
}
