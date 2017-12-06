namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gestionsinistre.insurance")]
    public partial class insurance
    {
        [Key]
        public int id_Ins { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string mail { get; set; }

        [StringLength(255)]
        public string nameInsurance { get; set; }

        [StringLength(255)]
        public string phone { get; set; }

        public int? addresse_id { get; set; }
    }
}
