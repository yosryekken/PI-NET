namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gestionsinistre.typecontract")]
    public partial class typecontract
    {
        [Key]
        public int IdTypeContrat { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public float pricePerSemester { get; set; }

        public float pricePerYear { get; set; }
    }
}
