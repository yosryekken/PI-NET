namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gestionsinistre.address")]
    public partial class address
    {
        public int Id { get; set; }

        public float laltitude { get; set; }

        public float longitude { get; set; }

        [StringLength(255)]
        public string name { get; set; }
    }
}
