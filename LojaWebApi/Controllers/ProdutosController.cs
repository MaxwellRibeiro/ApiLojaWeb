using LojaWebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

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
                    UrlFoto      = "https://images-americanas.b2w.io/produtos/01/00/img12/134412/9/134412967_1GG.jpg",
                    Descricao = "Notebook Samsung Expert X30 Intel Core I5 Quad-core 8GB 1TB Tela LED HD 15.6” Windows 10 Home - Cinza."
                },
                new Produto
                {
                    Id        = 2,
                    Nome      = "Mcleod  Mueller",
                    UrlFoto      = "https://images-americanas.b2w.io/produtos/01/00/item/124651/3/124651374_1GG.jpg",
                    Descricao = "Fogão Piso Consul 4 Bocas CFO4N Branco Bivolt."
                },
                new Produto
                {
                    Id        = 3,
                    Nome      = "Aguirre  Ellis",
                    UrlFoto      = "https://www.idealmarketing.com.br/blog/wp-content/uploads/2018/02/produto.png",
                    Descricao = "I am a very simple card. I am good at containing small bits of information."
                },
                new Produto
                {
                    Id        = 4,
                    Nome      = "Cook  Tyson",
                    UrlFoto      = "https://www.idealmarketing.com.br/blog/wp-content/uploads/2018/02/produto.png",
                    Descricao = "I am a very simple card. I am good at containing small bits of information."
                }
            };

            return produtos;
        }

        [HttpPost]
        [Route("api/produtos/UploadFiles")]
        public string UploadFiles()
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(
                    HttpContext.Current.Server.MapPath("~/uploads"),
                    fileName
                );

                file.SaveAs(path);
            }

            return file != null ? "/uploads/" + file.FileName : null;

        }

        [HttpPost]
        [Route("api/produtos/Insert")]
        public Produto Insert(Produto produto)
        {
            produto.Id = 1;
            return produto;
        }
    }
}