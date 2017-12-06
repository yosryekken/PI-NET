namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gestionsinistre.insuranceproduct")]
    public partial class insuranceproduct
    {
        [Key]
        public int id_Pro { get; set; }

        [StringLength(255)]
        public string deal { get; set; }

        public byte[] img { get; set; }

        public int moyRate { get; set; }

        public int nb_rate { get; set; }

        public int note { get; set; }

        public int rate { get; set; }

        [StringLength(255)]
        public string text { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        public int? id_In { get; set; }
    }
}
