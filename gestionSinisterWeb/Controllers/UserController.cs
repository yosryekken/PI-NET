using gestionSinisterWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace gestionSinisterWeb.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(ViewUserModel uvm)
        {


            HttpClient Client = new HttpClient();

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response;
            String cnx = "http://localhost:18080/JEEPI-web/rest/users/" + uvm.login + "/" + uvm.password;
            if (uvm.login != null && uvm.password != null)

            {
                response = Client.GetAsync(cnx).Result;
            }
            else
            {
                response = null;
            }

            if (response.Content.Headers.ContentLength != 0)
            {
                try { 
                uvm = response.Content.ReadAsAsync<ViewUserModel>().Result;

                ViewBag.result = response.Content.ReadAsAsync<ViewUserModel>().Result;
                }catch (Exception e)
                {
                    
                }
                // IEnumerable<Users> u = response.Content.ReadAsAsync<IEnumerable<Users>>().Result;

                return
                    RedirectToAction("Home","Home", uvm);
            }
            else
            {
                //n3adi fl view lerreur
                return View();
            }

        }


    }
}