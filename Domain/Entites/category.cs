namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gestionsinistre.category")]
    public partial class category
    {
        [Key]
        public int idCategory { get; set; }

        [StringLength(255)]
        public string NameCategory { get; set; }
    }
}
