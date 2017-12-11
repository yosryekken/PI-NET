using pi.domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pi.web.Models
{
    public class EvenementModel
    {
        [Key]
        public int EvenementId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }


        [Display(Name = "Start_Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Start_Date { get; set; }



        [Display(Name = "Finish_Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Finish_Date { get; set; }
        [DataType(DataType.ImageUrl)]
        public String Image { get; set; }
        public String Description { get; set; }

        public String Localisation { get; set; }

        public int UserId { get; set; }

        public int AgenceId { get; set; } = 1;

        public virtual ICollection<Participant> Participants { get; set; }
    }
}
