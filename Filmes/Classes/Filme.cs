using Filmes.Enum;
using System;

namespace Filmes.Classes
{
    public class Filme : Item
    {
        //Atributos
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        //Construtor
       public Filme(int id, Genero genero, String titulo, int ano, bool excluido)
        {
            Genero = genero;
            Id = id;
            Titulo = titulo;
            Ano = ano;
            Excluido = excluido;
        }

        public Filme(int id, Genero genero, string titulo, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Ano = ano;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + Genero + Environment.NewLine;
            retorno += "Titulo: " + Titulo + Environment.NewLine;
            retorno += "Descrição: " + Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + Ano + Environment.NewLine;
            retorno += "Excluido: " + (Excluido ? "*Excluído*" : "*Disponivél*");
            return retorno;
        }

        //Retorna o titulo do filme
        public string GetTitulo()
        {
            return Titulo;
        }

        //Retorna o Id
        public int GetId()
        {
            return Id;
        }

        //Retorna se o filme foi excluido
        public bool GetExcluido()
        {
            return Excluido;
        }

        public void Excluir()
        {
            Excluido = true;
        }

        public void setGenero()
        {
            Genero = Genero;
        }
        
      
    }

}
