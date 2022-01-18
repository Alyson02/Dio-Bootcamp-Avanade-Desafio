using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroGames.Interfaces;

namespace CadastroGames.Classes
{
    public class GamesRepositorio : IRepositorio<Games>
    {
        List<Games> lista = new List<Games>();
        public void Atualizar(int id, Games objeto)
        {
            lista[id] = objeto;
        }

        public void Exclui(int id)
        {
            lista[id].Excluir();
        }

        public void Insere(Games objeto)
        {
            lista.Add(objeto);
        }

        public List<Games> Lista()
        {
            return lista;
        }

        public int ProximoId()
        {
            return lista.Count;
        }

        public Games RetornaPorId(int id)
        {
            return lista[id];
        }
    }
}