using System;
using System.Collections.Generic;
using System.Text;

namespace Filmes.Interface
{
    interface IRepositorio<C>
    {
        List<C> Lista();
        C GetbyId(int id);
        void Insere(C entidade);
        void Exclui(int id);
        void Atualiza(int id, C entidade);
        int ProximoId();
    }
}
