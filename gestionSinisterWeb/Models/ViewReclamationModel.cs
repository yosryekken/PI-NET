using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gestionSinisterWeb.Models
{
    public class ViewReclamationModel
    {
        public int id { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string titre { get; set; }

        public int? idInsured { get; set; }

        [StringLength(255)]
        public string sujet { get; set; }

        [StringLength(255)]
        public string typeRec { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Password { get; set; }
    }
}