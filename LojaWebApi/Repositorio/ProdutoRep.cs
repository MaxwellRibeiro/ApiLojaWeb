using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaWebApi.Models;

namespace LojaWebApi.Repositorio
{
    public class ProdutoRep : Connection
    {
        public List<Produto> BuscaProdutos()
        {
            var lista = Query<Produto>("SELECT * FROM produto").ToList();
            return lista;
        }

        public Produto BuscaProdutoPorId(int idProduto)
        {
            var produto = Query<Produto>($"SELECT * FROM produto where Id = {idProduto}").FirstOrDefault();
            return produto;
        }

        public List<Produto> BuscaProdutosPorLogin(int idLogin)
        {
            var lista = Query<Produto>($"SELECT * FROM produto where IdLogin = {idLogin}").ToList();
            return lista;
        }
    }
}