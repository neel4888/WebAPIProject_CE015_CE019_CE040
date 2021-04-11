using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineAdmissionSystem.Models;

namespace OnlineAdmissionSystem.Controllers
{
    public class WebApiController : ApiController
    {
        StuDBEntities sde = new StuDBEntities();
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetData()
        {

            sde.Configuration.ProxyCreationEnabled = false;
            var lst = sde.Students.OrderByDescending(x=>x.merit);
            return Ok(lst);
        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult Insert(Student s)
        {
            sde.Configuration.ProxyCreationEnabled = false;
            sde.Students.Add(s);
            sde.SaveChanges();
            return Ok();
        }
    }
}