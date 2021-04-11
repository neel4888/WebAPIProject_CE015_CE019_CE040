using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using OnlineAdmissionSystem.Models;
using OnlineAdmissionSystem.ViewModels;
namespace OnlineAdmissionSystem.Controllers
{
    public class ConsumeController : Controller
    {
        HttpClient hc = new HttpClient();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Display()
        {
            List<Student> list = new List<Student>();
            hc.BaseAddress = new Uri("https://localhost:44302/api/webapi/Getdata");
            var consume = hc.GetAsync("GetData");
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Student>>();
                list = display.Result;
            }
            return View(list);
        }
        [System.Web.Http.HttpGet]

        public ActionResult Login()
        {
            return View();
        }

        [System.Web.Http.HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return View("Login");
        }

        [System.Web.Http.HttpPost]
        public ActionResult Login(string email, string password)
        {

            email = email.TrimStart(' ').TrimEnd(' ');
            password = password.TrimStart(' ').TrimEnd(' ');
            string uri = "https://localhost:44302/api/webapi";
            IEnumerable<StudentViewModel> list = null;
            hc.BaseAddress = new Uri(uri);

            var cunsume_income = hc.GetAsync("GetData");

            try { cunsume_income.Wait(); }
            catch (Exception e) { }


            var test = cunsume_income.Result;

            if (test.IsSuccessStatusCode)
            {
                Console.WriteLine("OK !!");
                var display = test.Content.ReadAsAsync<IList<StudentViewModel>>();
                list = display.Result;


                string x_email = "";
                string x_pass = "";
                foreach (var x in list)
                {
                    x_email = x.email.TrimStart(' ').TrimEnd(' ');
                    x_pass = x.mobile.TrimStart(' ').TrimEnd(' ');

                    if (x_email.Equals(email) && x_pass.Equals(password))
                    {
                        Session["curruser"] = email;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return RedirectToAction("Login", "Consume");
        }

        [System.Web.Http.HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [System.Web.Http.HttpPost]
        public ActionResult Register1(Student s)
        {
            hc.BaseAddress = new Uri("https://localhost:44302/Api/WebApi/Insert");
            var consume = hc.PostAsJsonAsync("Insert", s);
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Display");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}