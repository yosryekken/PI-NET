
using Domain.Entitty;
using Service.Classes;
using Service.Interfaces;
using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using iTextSharp.text.html.simpleparser;
using System.Web.Mvc;
using iTextSharp.tool.xml;

namespace PIMVC.Controllers
{
    public class ContactController : Controller
    {  
        IContactService es = null;
        String exttension;

        public ContactController()
        {
            es = new ContactService();
            exttension = null;
        }

        // GET: Contact
        public ActionResult Index()
        {
            var r = es.GetAllContacts();
            return View(r);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            contact e = es.GetContactByID(id);
            return View(e);
         
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(contact con)
        {
            contact e = new contact //itialiseur d'objet
            {
                name = con.name,
                email=con.email,
                adresse= con.adresse,
                website=con.website,
                telephone= con.telephone
            };
            es.CreateContact(e);
            return RedirectToAction("Index", "Contact");
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
           contact e = es.GetContactByID(id);
            return View(e);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, contact con)
        {
            try
            {
                // TODO: Add update logic here

              
                    contact e = es.GetContactByID(id);



                    e.name = con.name;
                    e.email = con.email;
                    e.adresse = con.adresse;
                    e.website = con.website;
                    e.telephone = con.telephone;

                    es.UpdateContact(e);


                    return RedirectToAction("Index", "Contact");
                }
                catch
                {
                    return View();
                }
            }
            

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            var e = es.GetContactByID(id);
            es.DeleteContact(e);
            return RedirectToAction("Index", "Contact");
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string GridHtml)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(GridHtml);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Grid.pdf");
            }
        }
    }


}
