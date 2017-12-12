namespace Insurance.Domaine.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("insurance.insurancecompany")]
    public partial class insurancecompany
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string adresse { get; set; }

        public int codeEmail { get; set; }

        public int codepostal { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [StringLength(255)]
        public string login { get; set; }

        [StringLength(255)]
        public string mail { get; set; }

        [StringLength(255)]
        public string motDepasse { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        public int numero { get; set; }

        [StringLength(255)]
        public string pays { get; set; }

        public int reference { get; set; }

        [StringLength(255)]
        public string slogan { get; set; }

        [StringLength(255)]
        public string ville { get; set; }
    }
}
