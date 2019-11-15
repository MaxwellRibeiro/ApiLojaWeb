using Dapper.Contrib.Extensions;
using LojaWebApi.Models;
using LojaWebApi.Repositorio;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LojaWebApi.Controllers
{
    public class CompraController : ApiController
    {
        public HttpResponseMessage Get()
        {
            try
            {
                CompraRep rep = new CompraRep();
                var lista = rep.BuscaCompras();

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }

        [HttpPost]
        [Route("api/Compra/Insert")]
        public HttpResponseMessage Insert(Compra compra)
        {

            try
            {
                IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
                db.Open();
                db.Insert(compra);
                db.Close();

                return Request.CreateResponse(HttpStatusCode.OK, compra.Id > 0);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }

        }
    }
}
