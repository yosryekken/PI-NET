using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gestionSinisterWeb.Models
{
    public class EventModels
    {
        [Key]
        public int id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? dateDebut { get; set; }

        [DataType(DataType.Date)]
        public DateTime? dateFin { get; set; }

        [DataType(DataType.MultilineText)]
        public string description { get; set; }

        public TimeSpan? heure { get; set; }

        [StringLength(255)]
        public string localisation { get; set; }

        public int? nbrmaxpart { get; set; }

        [StringLength(255)]
        public string titre { get; set; }
    }
}