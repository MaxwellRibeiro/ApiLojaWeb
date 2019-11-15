using LojaWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace LojaWebApi.Repositorio
{
    public class CompraRep : Connection
    {
        public List<Compra> BuscaCompras()
        {
            var lista = Query<Compra>("SELECT * FROM compra").ToList();
            return lista;
        }
    }
}