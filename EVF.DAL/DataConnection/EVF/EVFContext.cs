using System;
using System.Collections.Generic;
using EVF.DAL.Entity.EVF;
using Microsoft.EntityFrameworkCore;

namespace EVF.DAL.DataConnection.EVF;

public partial class EVFContext : DbContext
{
    public EVFContext()
    {
    }

    public EVFContext(DbContextOptions<EVFContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<LibelleArticle> LibelleArticles { get; set; }

    public virtual DbSet<PatchNote> PatchNotes { get; set; }

    public virtual DbSet<Personnel> Personnel { get; set; }

    public virtual DbSet<Prevision> Previsions { get; set; }

    public virtual DbSet<Societe> Societes { get; set; }

    public virtual DbSet<SocieteClient> SocieteClients { get; set; }

    public virtual DbSet<TarifArticle> TarifArticles { get; set; }

    public virtual DbSet<TypeArticle> TypeArticles { get; set; }

    public virtual DbSet<VentePortefeuille> VentePortefeuilles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Articles).HasConstraintName("FK__Article__IdType__1F2E9E6D");

            entity.HasMany(d => d.IdDivisions).WithMany(p => p.IdArticles)
                .UsingEntity<Dictionary<string, object>>(
                    "ArticleDivision",
                    r => r.HasOne<Division>().WithMany()
                        .HasForeignKey("IdDivision")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Division"),
                    l => l.HasOne<Article>().WithMany()
                        .HasForeignKey("IdArticle")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Article"),
                    j =>
                    {
                        j.HasKey("IdArticle", "IdDivision").HasName("PK_Article_Division");
                        j.ToTable("ArticleDivision");
                    });
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PK_Client_IdClient");

            entity.Property(e => e.Isopays).IsFixedLength();
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasOne(d => d.IdSocieteNavigation).WithMany(p => p.Divisions).HasConstraintName("FK__Division__IdSoci__44FF419A");
        });

        modelBuilder.Entity<LibelleArticle>(entity =>
        {
            entity.HasKey(e => e.IdLibelleArticle).HasName("PK__LibelleA__9A3B6C9DC842A3E8");

            entity.HasOne(d => d.IdArticleNavigation).WithMany(p => p.LibelleArticles)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Article_LibelleArticle");
        });

        modelBuilder.Entity<Personnel>(entity =>
        {
            entity.HasKey(e => e.IdPersonnel).HasName("PK__Personne__B4CE51973BF1F8E2");

            entity.HasOne(d => d.IdSocieteNavigation).WithMany(p => p.Personnel).HasConstraintName("FK_Societe_Personnel");
        });

        modelBuilder.Entity<Prevision>(entity =>
        {
            entity.HasKey(e => e.IdPrevision).HasName("PK__Previsio__6FC6E35A7F49B452");

            entity.HasOne(d => d.IdArticleNavigation).WithMany(p => p.Previsions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrevisionsArticle");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Previsions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrevisionsClient");

            entity.HasOne(d => d.IdCommercialNavigation).WithMany(p => p.Previsions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prevision_IdCommercial");
        });

        modelBuilder.Entity<Societe>(entity =>
        {
            entity.HasKey(e => e.IdSociete).HasName("PK_Societe_IdSociete");

            entity.Property(e => e.CodeLangue).IsFixedLength();
        });

        modelBuilder.Entity<SocieteClient>(entity =>
        {
            entity.HasKey(e => new { e.IdSociete, e.IdClient, e.IdCommercial, e.IdAssistantCommercial }).HasName("PK_Societe_Client");

            entity.HasOne(d => d.IdAssistantCommercialNavigation).WithMany(p => p.SocieteClientIdAssistantCommercialNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssistantCommercial");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.SocieteClients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client");

            entity.HasOne(d => d.IdCommercialNavigation).WithMany(p => p.SocieteClientIdCommercialNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Commercial");

            entity.HasOne(d => d.IdSocieteNavigation).WithMany(p => p.SocieteClients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Societe");
        });

        modelBuilder.Entity<TarifArticle>(entity =>
        {
            entity.HasKey(e => e.IdTarifArticle).HasName("PK__TarifArt__3822E55E139AEB8B");

            entity.HasOne(d => d.IdArticleNavigation).WithMany(p => p.TarifArticles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Article_TA");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.TarifArticles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_TA");

            entity.HasOne(d => d.IdCommercialNavigation).WithMany(p => p.TarifArticles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personnel_TA");
        });

        modelBuilder.Entity<TypeArticle>(entity =>
        {
            entity.Property(e => e.CodeLangue).IsFixedLength();
        });

        modelBuilder.Entity<VentePortefeuille>(entity =>
        {
            entity.HasKey(e => e.IdVentePort).HasName("PK_Vente_Portefeuille");

            entity.HasOne(d => d.IdArticleNavigation).WithMany(p => p.VentePortefeuilles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Article_Vente_Portefeuille");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.VentePortefeuilles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_Vente_Portefeuille");

            entity.HasOne(d => d.IdCommercialNavigation).WithMany(p => p.VentePortefeuilles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Commercial_Vente_Portefeuille");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
