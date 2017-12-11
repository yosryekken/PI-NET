using Domain.Entitty;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
  public  interface IContactService : IServices<contact>
    {
        void CreateContact(contact e);
        List<contact> GetAllContacts();
        void UpdateContact(contact e);
        contact GetContactByID(int EventID);
        void DeleteContact(contact e);
    }
}
