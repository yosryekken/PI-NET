using Domain.Entites;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public interface IEventService : IService<evenement>
    {
        void createEvent(evenement i);
        List<evenement> getAllEvents();
        void updateEvenet(evenement i);
        evenement getEventById(int id);
        void deleteEvent(evenement i);
        void deleteEventById(int id);
      
    }

