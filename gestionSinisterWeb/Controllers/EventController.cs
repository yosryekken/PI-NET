using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using pi.data.Infrastructure;
using pi.domain.Entities;
using pi.service.Repositories;
using pi.web.Models;
using Rotativa.MVC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;




namespace pi.web.Controllers
{
    public class EvenementController : Controller
    {

        public static int UserId = 1;
        EvenementService ise = null;
        IUnitOfWork iuw = null;

        public EvenementController()
        {
            ise = new EvenementService();
        }

        // GET: Evenement********************************************************
        public ActionResult List()
        {
            var Exhibition = ise.getAllEvenement();
            List<EvenementModel> fVM = new List<EvenementModel>();
            foreach (var item in Exhibition)
            {
                fVM.Add(
                    new EvenementModel
                    {
                        EvenementId = item.EvenementId,
                        Description = item.Description,
                        Title = item.Title,
                        Image = item.Image,
                        Start_Date = item.Start_Date,
                        Finish_Date = item.Finish_Date,
                        AgenceId = item.AgenceId
                    });
            }
            return View(fVM);
        }

        // GET: Evenement/Details/5
        public ActionResult Details(int id)
        {
            Evenement c = ise.getEvenementById(id);

            return View(c);
        }

        // GET: Evenement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evenement/Create****************************************************
        [HttpPost]
        public ActionResult Create( Evenement e, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid || image == null || image.ContentLength == 0)
            {
                RedirectToAction("List");
            }
        
                e.AgenceId = 1;
               e.Image = image.FileName;
                ise.createEvenement(e);
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), image.FileName);
                image.SaveAs(path);
                return RedirectToAction("List", "Evenement");

            return View();
        }
        //********************************************************************************

        // GET: Evenement/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evenement c = ise.getEvenementById(id);
            if (c == null)
            {
                return HttpNotFound();
            }

            return View(c);
        }

        // POST: Evenement/Edit/5
        [HttpPost]
        public ActionResult Edit(Evenement e)
        {
            if (ModelState.IsValid)
            {
                ise.updateEvenement(e);
                TempData.Clear();
                TempData["updated"] = e.Title;
                return RedirectToAction("List");
            }
            return View(e);
        }

        // GET: Evenement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // DELETE: Evenement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ise.deleteEvenementById(id);
            var hs = ise.getAllEvenement();
            TempData.Clear();
            TempData["deleted"] = "1";
            return RedirectToAction("List", hs);
        }


    
        public ActionResult ExportPdf()
        {

            return new ActionAsPdf("List")
            {

                FileName = Server.MapPath("~/Content/List.pdf")

            };

        }









    }


}
