using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gestionSinisterWeb.Models
{
    public class ViewUserModel
    {


        public int id { get; set; }

        public DateTime? BirthdayDate { get; set; }

        [StringLength(255)]
        public string adress { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string login { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string phone { get; set; }

        [StringLength(255)]
        public string role { get; set; }
    }
}