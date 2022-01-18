using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroGames.Enum;

namespace CadastroGames.Classes
{
    public class Games : EntidadeBase
    {
        private  Genero Genero { get; set; }
        private string Titulo { get; set; }
        
        private string Descricao { get; set; }
        
        private int Ano { get; set; }
        
        private bool Excluido { get; set; }

        public Games(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido + Environment.NewLine;
            return retorno;
        }
        
        public string GetTitulo()
        {
            return this.Titulo;
        }

        public int GetId()
        {
            return this.Id;
        }
        public bool GetExcluido()
        {
            return this.Excluido;
        }
        
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}