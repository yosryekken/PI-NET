namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gestionsinistre.reclamation")]
    public partial class reclamation
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

        public virtual users users { get; set; }
    }
}
