namespace Insurance.Domaine.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("insurance.filtrage")]
    public partial class filtrage
    {
        public int id { get; set; }

        [StringLength(255)]
        public string text { get; set; }
    }
}
