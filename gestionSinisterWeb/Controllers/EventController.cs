using Domain.Entites;
using gestionSinisterWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gestionSinisterWeb.Controllers
{
    public class EventController : Controller
    {
        EventService bs = null;


        public EventController()
        {
            bs = new EventService();
            
        }

        // GET: Event
        public ActionResult Index()
        {
            List<EventModels> list = new List<EventModels>();

            if (ModelState.IsValid)
            {
                foreach (var item in bs.getAllEvents())
                {
                    EventModels evm = new EventModels();

                    evm.id = item.id;
                    evm.dateDebut = item.dateDebut;
                    evm.dateFin = item.dateFin;
                    evm.description = item.description;
                    evm.heure = item.heure;
                    evm.localisation = item.localisation;
                    evm.nbrmaxpart = item.nbrmaxpart;
                    evm.titre = item.titre;

                    list.Add(evm);
                }

                return View(list);
            }
            return View(list);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            evenement p = bs.GetById(id);
            EventModels pm = new EventModels

            {
                dateDebut = p.dateDebut,
                dateFin = p.dateFin,
                description = p.description,
                localisation = p.localisation,
                nbrmaxpart = p.nbrmaxpart,
                titre = p.titre,

            };


            return View(pm);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventModels b)
        {
            evenement p = new evenement
            {
                dateDebut = b.dateDebut,
                dateFin = b.dateFin,
                description = b.description,
                localisation = b.localisation,
                nbrmaxpart = b.nbrmaxpart,
                titre = b.titre,
          
            };
            bs.createEvent(p);
            bs.Commit();
            return RedirectToAction("Index");
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
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
    }
}
