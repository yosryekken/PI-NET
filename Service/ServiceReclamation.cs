
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entites;
using Service.Patern;

namespace Service
{
    public class ServiceReclamation : Service<reclamation>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

    

        public ServiceReclamation() : base(utwk)
        {
        }
    }
}
