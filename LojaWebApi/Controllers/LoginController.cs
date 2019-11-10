using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using LojaWebApi.Models;
using System.Web.Http;
using Dapper.Contrib.Extensions;
using LojaWebApi.Repositorio;
using MySql.Data.MySqlClient;

namespace LojaWebApi.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("api/Login/BuscaLoginPorId")]
        public HttpResponseMessage BuscaLoginPorId(int idlogin)
        {
            try
            {
                LoginRep rep = new LoginRep();
                var login = rep.BuscaLoginPorId(idlogin);

                return Request.CreateResponse(HttpStatusCode.OK, login);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }

        [HttpPost]
        [Route("api/Login/Verificar")]
        public HttpResponseMessage Verificar(Login login) 
        {
            try
            {
                LoginRep rep = new LoginRep();
                var lista = rep.BuscaLogins();


                var acesso =  lista.FirstOrDefault(l => l.Email == login.Email && l.Senha == login.Senha);

                return Request.CreateResponse(HttpStatusCode.OK, acesso?.Id ?? 0);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
           
        }

        [HttpPost]
        [Route("api/Login/Insert")]
        public HttpResponseMessage Insert(Login login)
        {

            try
            {
                IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
                db.Open();
                db.Insert(login);
                db.Close();

                return Request.CreateResponse(HttpStatusCode.OK, login.Id > 0);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
            
        }
    }
}
