namespace Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gestionsinistre.evenement")]
    public partial class evenement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public evenement()
        {
            participate = new HashSet<participate>();
            evenement_users = new HashSet<evenement_users>();
        }

        [Key]
        public int id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? dateDebut { get; set; }

        [DataType(DataType.Date)]
        public DateTime? dateFin { get; set; }

        [DataType(DataType.MultilineText)]
        public string description { get; set; }

        public TimeSpan? heure { get; set; }

        [StringLength(255)]
        public string localisation { get; set; }

        public int? nbrmaxpart { get; set; }

        [StringLength(255)]
        public string titre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<participate> participate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<evenement_users> evenement_users { get; set; }
    }
}
