using System;
using System.Collections.Generic;
using System.Linq;
using LojaWebApi.Models;

namespace LojaWebApi.Repositorio
{
    public class LoginRep : Connection
    {
        public List<Login> BuscaLogins()
        {
            var lista = Query<Login>("SELECT * FROM login").ToList();
            return lista;
        }

        public Login BuscaLoginPorId(int id)
        {
            var lista = Query<Login>($@"SELECT * FROM login where Id = {id}").FirstOrDefault();
            return lista;
        }

    }
}