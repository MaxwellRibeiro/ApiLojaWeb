using LojaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LojaWebApi.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("api/Login/Verificar")]
        public bool Verificar(Login login) 
        {
            if (login == null) return false;
            if (login.Email == "Max" && login.Senha == "123") return true;
            return false;
        }
    }
}
