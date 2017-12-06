using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SinistreContext : DbContext
    {
        public SinistreContext() : base("gestionsinistre")
        {
            //Database.SetInitializer<PiEasyMissionContext>(new PiEasyMissionContextInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Add(new DateTime2Convention());
           
        }
    }
}
