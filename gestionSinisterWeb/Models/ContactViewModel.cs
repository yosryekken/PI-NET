using System;
using System.ComponentModel.DataAnnotations;

namespace PIMVC.Models
{
    public class ContactViewModel 
    {


        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(255)]
        public string adresse { get; set; }

        [Required]
        [StringLength(255)]
        public string website { get; set; }

        [Required]
        [StringLength(255)]
        public string telephone { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }
    }
}
