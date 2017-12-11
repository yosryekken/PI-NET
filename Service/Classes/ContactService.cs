using Domain.Entitty;
using Service.Interfaces;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Data;

namespace Service.Classes
{
   public class ContactService : Services<contact>, IContactService
    {
        public static IDatabaseFactory dbFactory;
        public static IUnitOfWork myUnit;

        public ContactService() : base(myUnit)
        {
            dbFactory = new DatabaseFactory();
            myUnit = new UnitOfWork(dbFactory);
        }

        public void CreateContact(contact e)
        {
            myUnit.getRepository<contact>().Add(e);
            myUnit.Commit();
        }

        public void DeleteContact(contact e)
        {
            myUnit.getRepository<contact>().Delete(e);
            myUnit.Commit();
        }

        public List<contact> GetAllContacts()
        {
            return myUnit.getRepository<contact>().GetAll().ToList();
        }

        public contact GetContactByID(int EventID)
        {
            return myUnit.getRepository<contact>().GetById(EventID);
        }

        public void UpdateContact(contact e)
        {
            myUnit.getRepository<contact>().Update(e);
            myUnit.Commit();
        }
    }
}

