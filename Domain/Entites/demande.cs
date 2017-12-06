namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gestionsinistre.demande")]
    public partial class demande
    {
        public int id { get; set; }

        [StringLength(255)]
        public string Model { get; set; }

        [StringLength(255)]
        public string color { get; set; }

        public DateTime? date { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        [StringLength(255)]
        public string horsePower { get; set; }

        [StringLength(255)]
        public string newMark { get; set; }

        [StringLength(255)]
        public string newMatriculation { get; set; }

        public int? numChassis { get; set; }

        [StringLength(255)]
        public string oldMark { get; set; }

        [StringLength(255)]
        public string oldMatriculation { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int? users_id { get; set; }

        [StringLength(255)]
        public string vehicle_Matriculation { get; set; }

        public int user_id { get; set; }
    }
}
