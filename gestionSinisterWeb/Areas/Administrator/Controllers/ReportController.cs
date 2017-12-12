
using Domain.entities;
using Rotativa.MVC;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using WebInsurance.Models;

namespace WebInsurance.Areas.Administrator.Controllers
{
    public class ReportController : Controller
    {
        ServiceReport sr = new ServiceReport();


        public ActionResult ExportPdf()
        {

            return new ActionAsPdf("")
            {

                FileName = Server.MapPath("~/Content/List.pdf")

            };

        }



        // GET: Administrator/Report
        public ActionResult Index()
        {
            var reports = sr.GetAll(); ;
            return View(reports);
        }
        // GET: Report/Create
        [HttpPost]
        public ActionResult Index(String SearchString)
        {
            var reports = sr.GetAll();
            reports = reports.Where(p => p.objet.Contains(SearchString));
            return View(reports);
        }
        public ActionResult Create()
        {

            ReportModel rm = new ReportModel();
            return View(rm);
        }
        [HttpPost]
        public ActionResult Create(ReportModel rm)
        {
            var fileNameS = "";
            var rmfileName = "";
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase fileS = Request.Files[0];
                if (fileS.ContentLength > 0)
                {
                     fileNameS = Path.GetFileName(fileS.FileName);
                    rmfileName = Path.Combine(
                        Server.MapPath("~/Content/Upload"), fileNameS);
                    fileS.SaveAs(rmfileName);
                }
            }
            report report = new report()
            {
                objet = rm.objet,
                description = rm.description,
                fileName = rmfileName,
                dateCreation = DateTime.Now,
            };   
            sr.Add(report);
            sr.Commit();


          



            return RedirectToAction("Index");
        }

        // GET: Report/Details/5
        public ActionResult Details(int id)
        {
            report r = new report();
            r = sr.GetReportById(id);
            return View(r);
        }
      
        // GET: Report/Delete/5       
        public ActionResult Delete(int id)
        {
            
            report r = sr.GetReportById(id);
            ReportModel rm = new ReportModel()
            {
                id = r.id,
                objet = r.objet,
                description = r.description,
                fileName = r.fileName,

            };

            return View(rm);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            report r = sr.GetReportById(id);
            
            if (ModelState.IsValid)
            {
                sr.Delete(r);
                sr.Commit();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            
            report r = sr.GetReportById(id);
            ReportModel rm = new ReportModel(){
                id = r.id,
                objet = r.objet,
                description = r.description,
                fileName = r.fileName,
                
            };
            
            return View(rm);
        }
        // GET: Report/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,ReportModel rm)
        {
            var fileNameS = "";
            var rmfileName = "";
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase fileS = Request.Files[0];
                if (fileS.ContentLength > 0)
                {
                    fileNameS = Path.GetFileName(fileS.FileName);
                    rmfileName = Path.Combine(
                        Server.MapPath("~/Content/Upload"), fileNameS);
                    fileS.SaveAs(rmfileName);
                }
            }


            report r = sr.GetReportById(id);
            r.id = rm.id;
            r.objet = rm.objet;
            r.description = rm.description;
            r.fileName = rmfileName;
            if (ModelState.IsValid)
            {
                sr.Update(r);
                sr.Commit();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult sendMail(report rm)
        {
            var fileNameS = "";
            var rmfileName = "";
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase fileS = Request.Files[0];
                if (fileS.ContentLength > 0)
                {
                    fileNameS = Path.GetFileName(fileS.FileName);
                    rmfileName = Path.Combine(
                        Server.MapPath("~/Content/Upload"), fileNameS);
                    fileS.SaveAs(rmfileName);
                }
            }


            for (int i = 0; i < Request.Files.Count; i++)
            {
                var myFile = Request.Files[i];

                if (myFile != null && myFile.ContentLength != 0)
                {
                     rmfileName = Server.MapPath("~/Content/Upload");
                }

            }


            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("aboudimariem93@gmail.com");
                mail.To.Add("meriem.aboudi@esprit.tn");
                mail.Subject = "Report";
                mail.Body = "<h1>You will find attached the report.</h1>";
                mail.IsBodyHtml = true;
                mail.Attachments.Add(new Attachment("C:/Users/aboud/AppData/Local/Packages/Microsoft.MicrosoftEdge_8wekyb3d8bbwe/TempState/Downloads/D_PIDEV_NET_Insurance_WebInsurance_Content_List.pdf"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("aboudimariem93@gmail.com", "58323183A");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
            return View();

        }


    }
}