namespace Domain.Entites
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelDev : DbContext
    {
        public ModelDev()
            : base("name=ModelDev")
        {
        }

        public virtual DbSet<address> address { get; set; }
        public virtual DbSet<agent> agent { get; set; }
        public virtual DbSet<attt> attt { get; set; }
        public virtual DbSet<category> category { get; set; }
        public virtual DbSet<demande> demande { get; set; }
        public virtual DbSet<evenement> evenement { get; set; }
        public virtual DbSet<insurance> insurance { get; set; }
        public virtual DbSet<insuranceproduct> insuranceproduct { get; set; }
        public virtual DbSet<insured> insured { get; set; }
        public virtual DbSet<messages> messages { get; set; }
        public virtual DbSet<participate> participate { get; set; }
        public virtual DbSet<police> police { get; set; }
        public virtual DbSet<reclamation> reclamation { get; set; }
        public virtual DbSet<reponse> reponse { get; set; }
        public virtual DbSet<souscategory> souscategory { get; set; }
        public virtual DbSet<t_todo> t_todo { get; set; }
        public virtual DbSet<topic> topic { get; set; }
        public virtual DbSet<typecontract> typecontract { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<vehicle> vehicle { get; set; }
        public virtual DbSet<vehicleattt> vehicleattt { get; set; }
        public virtual DbSet<vehicleswreck> vehicleswreck { get; set; }
        public virtual DbSet<evenement_users> evenement_users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<address>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<agent>()
                .Property(e => e.adress)
                .IsUnicode(false);

            modelBuilder.Entity<agent>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<agent>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<agent>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<agent>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<agent>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<attt>()
                .Property(e => e.matriculation)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .Property(e => e.NameCategory)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.horsePower)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.newMark)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.newMatriculation)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.oldMark)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.oldMatriculation)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.vehicle_Matriculation)
                .IsUnicode(false);

            modelBuilder.Entity<evenement>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<evenement>()
                .Property(e => e.localisation)
                .IsUnicode(false);

            modelBuilder.Entity<evenement>()
                .Property(e => e.titre)
                .IsUnicode(false);

            modelBuilder.Entity<evenement>()
                .HasMany(e => e.participate)
                .WithRequired(e => e.evenement)
                .HasForeignKey(e => e.idevent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<evenement>()
                .HasMany(e => e.evenement_users)
                .WithRequired(e => e.evenement)
                .HasForeignKey(e => e.events_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<insurance>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<insurance>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<insurance>()
                .Property(e => e.nameInsurance)
                .IsUnicode(false);

            modelBuilder.Entity<insurance>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<insuranceproduct>()
                .Property(e => e.deal)
                .IsUnicode(false);

            modelBuilder.Entity<insuranceproduct>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<insuranceproduct>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<insured>()
                .Property(e => e.adress)
                .IsUnicode(false);

            modelBuilder.Entity<insured>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<insured>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<insured>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<insured>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<insured>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<messages>()
                .Property(e => e.contenu)
                .IsUnicode(false);

            modelBuilder.Entity<police>()
                .Property(e => e.vehicle_Matriculation)
                .IsUnicode(false);

            modelBuilder.Entity<reclamation>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<reclamation>()
                .Property(e => e.titre)
                .IsUnicode(false);

            modelBuilder.Entity<reponse>()
                .Property(e => e.contenu)
                .IsUnicode(false);

            modelBuilder.Entity<souscategory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<t_todo>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .Property(e => e.contenu)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .Property(e => e.sujet)
                .IsUnicode(false);

            modelBuilder.Entity<typecontract>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.adress)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<vehicle>()
                .Property(e => e.Matriculation)
                .IsUnicode(false);

            modelBuilder.Entity<vehicle>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<vehicle>()
                .Property(e => e.HorsePower)
                .IsUnicode(false);

            modelBuilder.Entity<vehicle>()
                .Property(e => e.Mark)
                .IsUnicode(false);

            modelBuilder.Entity<vehicle>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<vehicleattt>()
                .Property(e => e.Matriculation)
                .IsUnicode(false);

            modelBuilder.Entity<vehicleattt>()
                .Property(e => e.Mark)
                .IsUnicode(false);

            modelBuilder.Entity<vehicleswreck>()
                .Property(e => e.Matriculation)
                .IsUnicode(false);

            modelBuilder.Entity<vehicleswreck>()
                .Property(e => e.Mark)
                .IsUnicode(false);
        }
    }
}
