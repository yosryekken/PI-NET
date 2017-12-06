using System.Collections.Generic;
using System.Linq;
using Service.Pattern;
using Domain.Entites;
using System;

public class EventService : Service<evenement>, IEventService
{
    public static IDataBaseFactory dbFactory;
    public static IUnitOfWork myUnit;


    public EventService() : base(myUnit)
    {
        dbFactory = new DataBaseFactory();
        myUnit = new UnitOfWork(dbFactory);

    }

    public void createEvent(evenement i)
    {

        myUnit.getRepository<evenement>().Add(i);
        myUnit.Commit();
    }


    public void deleteEvent(evenement i)
    {
        myUnit.getRepository<evenement>().Delete(i);
        myUnit.Commit();
    }

    public void deleteEventById(int id)
    {
        evenement i = myUnit.getRepository<evenement>().GetById(id);
        myUnit.getRepository<evenement>().Delete(i);
        myUnit.Commit();
    }

    public List<evenement> getAllEvents()
    {
        return myUnit.getRepository<evenement>().getAll().ToList();
    }

    public evenement getEventById(int id)
    {
        return myUnit.getRepository<evenement>().GetById(id);
    }



    public void updateEvenet(evenement i)
    {
        myUnit.getRepository<evenement>().Update(i);
        myUnit.Commit();
    }







    /*--------------Filtre des Mots sur l'annonce ----------------*/
    public string filterDescription(string desc)
    {
        ICollection<string> listDescription = desc.Split(' ').ToList();
        ICollection<string> listDescriptionNew = new List<string>();
        foreach (string e in listDescription)
        {
            if (e.ToLower().Contains("fuck"))
                listDescriptionNew.Add("****");
            else if (e.ToLower().Contains("bitch"))
                listDescriptionNew.Add("****");
            else if (e.ToLower().Contains("merde"))
                listDescriptionNew.Add("****");
            else if (e.ToLower().Contains("shit"))
                listDescriptionNew.Add("****");
            else
                listDescriptionNew.Add(e);
        }
        string result = "";
        foreach (string e in listDescriptionNew)
            result = result + e + " ";
        return result;
    }



}

