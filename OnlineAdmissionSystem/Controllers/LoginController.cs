using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineAdmissionSystem.Models;

namespace OnlineAdmissionSystem.Controllers
{
    public class LoginController : ApiController
    {
        StuDBEntities sde = new StuDBEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult UserLogin(string email, string password)
        {

            sde.Configuration.ProxyCreationEnabled = false;
            Student data = sde.Students.Where(x => x.email.Equals(email) && x.mobile.Equals(password)).SingleOrDefault();
            return Ok(data);
        }
    }
}