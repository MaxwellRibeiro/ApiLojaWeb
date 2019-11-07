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
    }
}