using Domain.entities;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebInsurance.Models;
using System.IO;
using Rotativa;
using Rotativa.MVC;

namespace WebInsurance.Areas.Administrator.Controllers
{
    public class StatisticController : Controller
    {
        ServiceReport sr = new ServiceReport();

        public ActionResult ExportPdf()
        {

            return new ActionAsPdf("")
            {

                FileName = Server.MapPath("~/Content/List.pdf")

            };

        }


        // GET: Administrator/Statistic
        public ActionResult Index()
        {
         

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080/");
            Client.DefaultRequestHeaders.Accept.Clear();
            ViewBag.country = "";
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Accept.Clear();

            //-------- diffrent Insurance
            HttpResponseMessage reponse = Client.GetAsync("insurance-web/api/sinister").Result;
            Debug.WriteLine("DEBUG: " + reponse);
            var list = new List<sinister>();
            if (reponse.IsSuccessStatusCode == true)
            {
                list = reponse.Content.ReadAsAsync<IEnumerable<sinister>>().Result.ToList();
            }

            List<int> repartitions = new List<int>();
            var objects = list.Select(x => x.nameInsurancCompany).Distinct();

            foreach (var item in objects)
            {
                repartitions.Add(list.Count(x => x.nameInsurancCompany == item));
            }

            var rep = repartitions;
            ViewBag.OBJECTS = objects;
            ViewBag.REP = repartitions.ToList();



            //-------- diffrent Accident
            HttpResponseMessage reponseAccident = Client.GetAsync("insurance-web/api/sinister").Result;
            Debug.WriteLine("DEBUG: " + reponseAccident);
            var listAccident = new List<sinister>();
            if (reponseAccident.IsSuccessStatusCode == true)
            {
                listAccident = reponseAccident.Content.ReadAsAsync<IEnumerable<sinister>>().Result.ToList();
            }
            //----------------------Year
            List<int> repartitionsAccidentYear = new List<int>();
            var objectsAccidentYear = listAccident.Select(x => x.annee).Distinct();
            objectsAccidentYear.ToList().Add("2017");
            objectsAccidentYear.ToList().Add("2016");
            foreach (var item in objectsAccidentYear)
            {
                repartitionsAccidentYear.Add(listAccident.Count(x => x.annee == item));
            }
            repartitionsAccidentYear.Add(5);
            repartitionsAccidentYear.Add(6);
            var repAccidentYear = repartitionsAccidentYear;
            ViewBag.OBJECTSAccidentYear = objectsAccidentYear;
            ViewBag.REPAccidenYear = repartitionsAccidentYear.ToList();

            //----------------------Month2017
            List<int> repartitionsAccidentMonth2017 = new List<int>();
            var objectsAccidentMonth2017 = listAccident.Where(x => x.annee == "2017").Select(x => x.mois).Distinct();

            foreach (var item in objectsAccidentMonth2017)
            {
                repartitionsAccidentMonth2017.Add(listAccident.Count(x => x.mois == item));
            }

            var repAccidentMonth2017 = repartitionsAccidentMonth2017;
            ViewBag.OBJECTSAccidentMonth2017 = objectsAccidentMonth2017;
            ViewBag.REPAccidenMonth2017 = repartitionsAccidentMonth2017.ToList();

            //----------------------Month2016
            List<int> repartitionsAccidentMonth2016 = new List<int>();
            var objectsAccidentMonth2016 = listAccident.Where(x => x.annee == "2016").Select(x => x.mois).Distinct();

            foreach (var item in objectsAccidentMonth2016)
            {
                repartitionsAccidentMonth2016.Add(listAccident.Count(x => x.mois == item));
            }

            var repAccidentMonth2016 = repartitionsAccidentMonth2016;
            ViewBag.OBJECTSAccidentMonth2016 = objectsAccidentMonth2016;
            ViewBag.REPAccidenMonth2016 = repartitionsAccidentMonth2016.ToList();



            //--------------------------------------------------------------------------------------
            //-------- diffrent class --------------------------------------------------------------
            //--------------------------------------------------------------------------------------

            HttpResponseMessage reponseContract = Client.GetAsync("insurance-web/api/contract").Result;
            Debug.WriteLine("DEBUG: " + reponseContract);
            var listContract = new List<contract>();
            if (reponseContract.IsSuccessStatusCode == true)
            {
                listContract = reponseContract.Content.ReadAsAsync<IEnumerable<contract>>().Result.ToList();
            }

            List<int> repartitionsContract = new List<int>();
            var objectsContract = listContract.Select(x => x.classe).Distinct();

            foreach (var item in objectsContract)
            {
                repartitionsContract.Add(listContract.Count(x => x.classe == item));
            }

            var repContract = repartitionsContract;
            ViewBag.OBJECTSContract = objectsContract;
            ViewBag.REPContract = repartitionsContract.ToList();

            //----------------------Type Contract
            HttpResponseMessage reponseTypeContract = Client.GetAsync("insurance-web/api/contract").Result;
            Debug.WriteLine("DEBUG: " + reponseTypeContract);
            var listTypeContract = new List<contract>();
            if (reponseTypeContract.IsSuccessStatusCode == true)
            {
                listTypeContract = reponseTypeContract.Content.ReadAsAsync<IEnumerable<contract>>().Result.ToList();
            }
            List<int> repartitionsTypeContract = new List<int>();
            var objectsTypeContract = listTypeContract.Select(x => x.typeContrat).Distinct();

            foreach (var item in objectsTypeContract)
            {
                repartitionsTypeContract.Add(listTypeContract.Count(x => x.typeContrat == item));
            }

            var repTypeContract = repartitionsTypeContract;
            ViewBag.OBJECTSTypeContract = objectsTypeContract;
            ViewBag.REPTypeContract = repartitionsTypeContract.ToList();

            return View();
        }

       public ActionResult Insurance()
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080/");
            Client.DefaultRequestHeaders.Accept.Clear();
            ViewBag.country = "";
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Accept.Clear();

            //-------- diffrent Insurance
            HttpResponseMessage reponse = Client.GetAsync("insurance-web/api/sinister").Result;
            Debug.WriteLine("DEBUG: " + reponse);
            var list = new List<sinister>();
            if (reponse.IsSuccessStatusCode == true)
            {
                list = reponse.Content.ReadAsAsync<IEnumerable<sinister>>().Result.ToList();
            }

            List<int> repartitions = new List<int>();
            var objects = list.Select(x => x.nameInsurancCompany).Distinct();

            foreach (var item in objects)
            {
                repartitions.Add(list.Count(x => x.nameInsurancCompany == item));
            }

            var rep = repartitions;
            ViewBag.OBJECTS = objects;
            ViewBag.REP = repartitions.ToList();

            return View();
        }
   

    public ActionResult Accident()
    {

        HttpClient Client = new HttpClient();
        Client.BaseAddress = new Uri("http://127.0.0.1:18080/");
        Client.DefaultRequestHeaders.Accept.Clear();
        ViewBag.country = "";
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        Client.DefaultRequestHeaders.Accept.Clear();
        //-------- diffrent Accident
        HttpResponseMessage reponseAccident = Client.GetAsync("insurance-web/api/sinister").Result;
        Debug.WriteLine("DEBUG: " + reponseAccident);
        var listAccident = new List<sinister>();
        if (reponseAccident.IsSuccessStatusCode == true)
        {
            listAccident = reponseAccident.Content.ReadAsAsync<IEnumerable<sinister>>().Result.ToList();
        }
        //----------------------Year
        List<int> repartitionsAccidentYear = new List<int>();
        var objectsAccidentYear = listAccident.Select(x => x.annee).Distinct();

        foreach (var item in objectsAccidentYear)
        {
            repartitionsAccidentYear.Add(listAccident.Count(x => x.annee == item));
        }

        var repAccidentYear = repartitionsAccidentYear;
        ViewBag.OBJECTSAccidentYear = objectsAccidentYear;
        ViewBag.REPAccidenYear = repartitionsAccidentYear.ToList();

        //----------------------Month2017
        List<int> repartitionsAccidentMonth2017 = new List<int>();
        var objectsAccidentMonth2017 = listAccident.Where(x => x.annee == "2017").Select(x => x.mois).Distinct();

        foreach (var item in objectsAccidentMonth2017)
        {
            repartitionsAccidentMonth2017.Add(listAccident.Count(x => x.mois == item));
        }

        var repAccidentMonth2017 = repartitionsAccidentMonth2017;
        ViewBag.OBJECTSAccidentMonth2017 = objectsAccidentMonth2017;
        ViewBag.REPAccidenMonth2017 = repartitionsAccidentMonth2017.ToList();

        //----------------------Month2016
        List<int> repartitionsAccidentMonth2016 = new List<int>();
        var objectsAccidentMonth2016 = listAccident.Where(x => x.annee == "2016").Select(x => x.mois).Distinct();

        foreach (var item in objectsAccidentMonth2016)
        {
            repartitionsAccidentMonth2016.Add(listAccident.Count(x => x.mois == item));
        }

        var repAccidentMonth2016 = repartitionsAccidentMonth2016;
        ViewBag.OBJECTSAccidentMonth2016 = objectsAccidentMonth2016;
        ViewBag.REPAccidenMonth2016 = repartitionsAccidentMonth2016.ToList();

        return View();


    }

    public ActionResult Classe()
    {

        HttpClient Client = new HttpClient();
        Client.BaseAddress = new Uri("http://127.0.0.1:18080/");
        Client.DefaultRequestHeaders.Accept.Clear();
        ViewBag.country = "";
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        Client.DefaultRequestHeaders.Accept.Clear();
        //--------------------------------------------------------------------------------------
        //-------- diffrent class --------------------------------------------------------------
        //--------------------------------------------------------------------------------------

        HttpResponseMessage reponseContract = Client.GetAsync("insurance-web/api/contract").Result;
        Debug.WriteLine("DEBUG: " + reponseContract);
        var listContract = new List<contract>();
        if (reponseContract.IsSuccessStatusCode == true)
        {
            listContract = reponseContract.Content.ReadAsAsync<IEnumerable<contract>>().Result.ToList();
        }

        List<int> repartitionsContract = new List<int>();
        var objectsContract = listContract.Select(x => x.classe).Distinct();

        foreach (var item in objectsContract)
        {
            repartitionsContract.Add(listContract.Count(x => x.classe == item));
        }

        var repContract = repartitionsContract;
        ViewBag.OBJECTSContract = objectsContract;
        ViewBag.REPContract = repartitionsContract.ToList();
        return View();
    }

    public ActionResult TypeContract()
    {

        HttpClient Client = new HttpClient();
        Client.BaseAddress = new Uri("http://127.0.0.1:18080/");
        Client.DefaultRequestHeaders.Accept.Clear();
        ViewBag.country = "";
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        Client.DefaultRequestHeaders.Accept.Clear();
        //----------------------Type Contract
        HttpResponseMessage reponseTypeContract = Client.GetAsync("insurance-web/api/contract").Result;
        Debug.WriteLine("DEBUG: " + reponseTypeContract);
        var listTypeContract = new List<contract>();
        if (reponseTypeContract.IsSuccessStatusCode == true)
        {
            listTypeContract = reponseTypeContract.Content.ReadAsAsync<IEnumerable<contract>>().Result.ToList();
        }
        List<int> repartitionsTypeContract = new List<int>();
        var objectsTypeContract = listTypeContract.Select(x => x.typeContrat).Distinct();

        foreach (var item in objectsTypeContract)
        {
            repartitionsTypeContract.Add(listTypeContract.Count(x => x.typeContrat == item));
        }

        var repTypeContract = repartitionsTypeContract;
        ViewBag.OBJECTSTypeContract = objectsTypeContract;
        ViewBag.REPTypeContract = repartitionsTypeContract.ToList();

        return View();
    }
    }
}