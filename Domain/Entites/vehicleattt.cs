namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gestionsinistre.vehicleattt")]
    public partial class vehicleattt
    {
        [Key]
        [StringLength(255)]
        public string Matriculation { get; set; }

        public int ChassisNumber { get; set; }

        [StringLength(255)]
        public string Mark { get; set; }
    }
}
