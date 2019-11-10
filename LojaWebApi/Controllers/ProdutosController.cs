using LojaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Dapper.Contrib.Extensions;
using LojaWebApi.Repositorio;
using MySql.Data.MySqlClient;

namespace LojaWebApi.Controllers
{
    public class ProdutosController : ApiController
    {
        public HttpResponseMessage Get()
        {
            try
            {
                ProdutoRep rep = new ProdutoRep();
                var lista = rep.BuscaProdutos();

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }

        [HttpGet]
        [Route("api/produtos/BuscaProdutoPorId")]
        public HttpResponseMessage BuscaProdutoPorId(int idProduto)
        {
            try
            {
                ProdutoRep rep = new ProdutoRep();
                var produto = rep.BuscaProdutoPorId(idProduto);

                return Request.CreateResponse(HttpStatusCode.OK, produto);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }

        [HttpGet]
        [Route("api/produtos/BuscaProdutosPorLogin")]
        public HttpResponseMessage BuscaProdutosPorLogin(int idLogin)
        {
            try
            {
                ProdutoRep rep = new ProdutoRep();
                var lista = rep.BuscaProdutosPorLogin(idLogin);

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
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
        [Route("api/produtos/Update")]
        public HttpResponseMessage Update(Produto produto)
        {
            try
            {
                IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
                db.Open();
                bool ok = db.Update(produto);
                db.Close();

                return Request.CreateResponse(HttpStatusCode.OK, ok);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }
    }
}