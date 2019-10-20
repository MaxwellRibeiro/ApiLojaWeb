using LojaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace LojaWebApi.Controllers
{
    public class ProdutosController : ApiController
    {
        public List<Produto> Get()
        {
            var produtos = new List<Produto>
            {
                new Produto
                {
                    Id        = 1,
                    Nome      = "Notebook Samsung",
                    Foto      = "https://images-americanas.b2w.io/produtos/01/00/img12/134412/9/134412967_1GG.jpg",
                    Descricao = "Notebook Samsung Expert X30 Intel Core I5 Quad-core 8GB 1TB Tela LED HD 15.6” Windows 10 Home - Cinza."
                },
                new Produto
                {
                    Id        = 2,
                    Nome      = "Mcleod  Mueller",
                    Foto      = "https://images-americanas.b2w.io/produtos/01/00/item/124651/3/124651374_1GG.jpg",
                    Descricao = "Fogão Piso Consul 4 Bocas CFO4N Branco Bivolt."
                },
                new Produto
                {
                    Id        = 3,
                    Nome      = "Aguirre  Ellis",
                    Foto      = "https://www.idealmarketing.com.br/blog/wp-content/uploads/2018/02/produto.png",
                    Descricao = "I am a very simple card. I am good at containing small bits of information."
                },
                new Produto
                {
                    Id        = 4,
                    Nome      = "Cook  Tyson",
                    Foto      = "https://www.idealmarketing.com.br/blog/wp-content/uploads/2018/02/produto.png",
                    Descricao = "I am a very simple card. I am good at containing small bits of information."
                }
            };

            return produtos;
        }
    }
}