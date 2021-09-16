using Filmes.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filmes.Classes
{
    //A classe implementa a interface IRepositorio que recebe a classe de um objeto com uma lista
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        private List<Filme> ListaFilme = new List<Filme>();
        public void Atualiza(int id, Filme filme)
        {
            ListaFilme[id] = filme;
        }

        public void Exclui(int id)
        {
            ListaFilme[id].Excluir();
        }

        public Filme GetbyId(int id)
        {
            return ListaFilme[id-1];
        }

        public void Insere(Filme movie)
        {
            ListaFilme.Add(movie);
        }

        public List<Filme> Lista()
        {
            return ListaFilme;
        }

        public int ProximoId()
        {
            return ListaFilme.Count + 1;
        }
    }
}
