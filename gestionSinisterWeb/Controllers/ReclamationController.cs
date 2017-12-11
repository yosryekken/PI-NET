using gestionSinisterWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entites;
using Service;

namespace gestionSinisterWeb.Controllers
{
    public class ReclamationController : Controller
    {
        ServiceUser SU = null;
        ServiceReclamation rs = null;

        [HttpPost]
        public ActionResult Reclamation(ViewReclamationModel rvm)
        {
            SU = new ServiceUser();
            rs = new ServiceReclamation();
            reclamation r = new reclamation();
            r.description = rvm.description;
            r.sujet = rvm.sujet;
            
            rs.Add(r);
            rs.Commit();

            SU.email(rvm.Email, rvm.Password, rvm.sujet, rvm.description);
            ViewBag.Message = "Your Profile page.";

            return View();
        }


        public ActionResult Reclamation()
        {
           
            return View();
        }
    }
}