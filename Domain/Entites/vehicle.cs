namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gestionsinistre.vehicle")]
    public partial class vehicle
    {
        [Key]
        [StringLength(255)]
        public string Matriculation { get; set; }

        [StringLength(255)]
        public string Color { get; set; }

        [StringLength(255)]
        public string HorsePower { get; set; }

        [StringLength(255)]
        public string Mark { get; set; }

        [StringLength(255)]
        public string Model { get; set; }

        public int? NumChassis { get; set; }

        public int? idInsured { get; set; }
    }
}
