namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gestionsinistre.souscategory")]
    public partial class souscategory
    {
        [Key]
        public int idSousCategory { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int? idCategory { get; set; }

        public int? idUser { get; set; }
    }
}
