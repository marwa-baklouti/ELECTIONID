using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ELECTIONID.Models
{
    public partial class ELECTIONDBContext : DbContext
    {
        public ELECTIONDBContext()
        {
        }

        public ELECTIONDBContext(DbContextOptions<ELECTIONDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrateur> Administrateurs { get; set; }

        public virtual DbSet<Vote> Votes { get; set; }
        public virtual DbSet<Candidat> Candidats { get; set; }
        public virtual DbSet<CentreElection> CentreElections { get; set; }
        public virtual DbSet<Electeur> Electeurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {


                optionsBuilder.UseSqlServer(@"Server=MARWA-PC\SQLEXPRESS1;Database=ELECTIONDB;Trusted_Connection=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrateur>(entity =>
            {
                entity.Property(e => e.CinAdmin).HasColumnName("cin_admin");

                entity.Property(e => e.MotDePasse).HasColumnName("mot_de_passe");

                entity.Property(e => e.NomAdmin).HasColumnName("nom_admin");

                entity.Property(e => e.PrenomAdmin).HasColumnName("prenom_admin");
            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.HasIndex(e => e.ElecteurId, "IX_Electeurs_ElecteurId")
                   .IsUnique();
                entity.HasOne(d => d.Electeur)
               .WithOne(p => p.Vote)
               .HasForeignKey<Vote>(d => d.ElecteurId);

            });

            modelBuilder.Entity<Candidat>(entity =>
            {
                entity.HasIndex(e => e.AdministrateurId, "IX_Candidats_AdministrateurId");

                entity.Property(e => e.CandidatId).HasColumnName("candidatId");

                entity.Property(e => e.CinCandidat).HasColumnName("cin_candidat");

                entity.Property(e => e.ImageCandidat).HasColumnName("Image_candidat");

                entity.Property(e => e.NomCandidat).HasColumnName("nom_candidat");

                entity.Property(e => e.PrenomCandidat).HasColumnName("prenom_candidat");

                entity.HasOne(d => d.Administrateur)
                    .WithMany(p => p.Candidats)
                    .HasForeignKey(d => d.AdministrateurId);
            });

            modelBuilder.Entity<CentreElection>(entity =>
            {
                entity.HasIndex(e => e.AdministrateurId, "IX_CentreElections_AdministrateurId")
                    .IsUnique();

                entity.Property(e => e.CentreElectionId).HasColumnName("centreElectionId");

                entity.Property(e => e.AdresseCentre).HasColumnName("adresse_centre");

                entity.Property(e => e.LibelleCentre).HasColumnName("libelle_centre");

                entity.HasOne(d => d.Administrateur)
                    .WithOne(p => p.CentreElection)
                    .HasForeignKey<CentreElection>(d => d.AdministrateurId);
            });

            modelBuilder.Entity<Electeur>(entity =>
            {
                entity.HasIndex(e => e.VoteId, "IX_Votes_VoteId");

                entity.HasIndex(e => e.CentreElectionId, "IX_Electeurs_centreElectionId");

                entity.Property(e => e.ElecteurId).HasColumnName("electeurId");

                entity.Property(e => e.CentreElectionId).HasColumnName("centreElectionId");

                entity.Property(e => e.CinElecteur).HasColumnName("cin_electeur");

                entity.Property(e => e.GenreElecteur).HasColumnName("genre_electeur");

                entity.Property(e => e.NomElecteur).HasColumnName("nom_electeur");

                entity.Property(e => e.PrenomElecteur).HasColumnName("prenom_electeur");

                entity.HasOne(d => d.CentreElection)
                    .WithMany(p => p.Electeurs)
                    .HasForeignKey(d => d.CentreElectionId);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
