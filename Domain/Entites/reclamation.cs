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
        [Key]
        public int id_rec { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string titre { get; set; }

        public int? insurance_id { get; set; }
    }
}
