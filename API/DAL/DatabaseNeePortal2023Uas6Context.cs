using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class DatabaseNeePortal2023Uas6Context : DbContext
{
    public DatabaseNeePortal2023Uas6Context()
    {
        Database.EnsureCreated();
    }

    public DatabaseNeePortal2023Uas6Context(DbContextOptions<DatabaseNeePortal2023Uas6Context> options) : base(options)
    {
    }

    public virtual DbSet<ElectricityProductionPlant> ElectricityProductionPlants { get; set; }

    public virtual DbSet<MainCategoryCatalogue> MainCategoryCatalogues { get; set; }

    public virtual DbSet<OrientationCatalogue> OrientationCatalogues { get; set; }

    public virtual DbSet<PlantCategoryCatalogue> PlantCategoryCatalogues { get; set; }

    public virtual DbSet<PlantDetail> PlantDetails { get; set; }

    public virtual DbSet<SubCategoryCatalogue> SubCategoryCatalogues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ElectricityProductionPlant>(entity =>
        {
            entity.HasKey(e => e.XtfId);

            entity.ToTable("ElectricityProductionPlant");

            entity.Property(e => e.XtfId)
                .ValueGeneratedNever()
                .HasColumnName("xtf_id");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.BeginningOfOperation).HasColumnType("date");
            entity.Property(e => e.Canton).HasMaxLength(50);
            entity.Property(e => e.MainCategory).HasMaxLength(50);
            entity.Property(e => e.Municipality).HasMaxLength(50);
            entity.Property(e => e.PlantCategory).HasMaxLength(50);
            entity.Property(e => e.SubCategory).HasMaxLength(50);
            entity.Property(e => e.X).HasColumnName("x");
            entity.Property(e => e.Y).HasColumnName("y");

            entity.HasOne(d => d.MainCategoryNavigation).WithMany(p => p.ElectricityProductionPlants)
                .HasForeignKey(d => d.MainCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElectricityProductionPlant_MainCategoryCatalogue");

            entity.HasOne(d => d.PlantCategoryNavigation).WithMany(p => p.ElectricityProductionPlants)
                .HasForeignKey(d => d.PlantCategory)
                .HasConstraintName("FK_ElectricityProductionPlant_PlantCategoryCatalogue");

            entity.HasOne(d => d.SubCategoryNavigation).WithMany(p => p.ElectricityProductionPlants)
                .HasForeignKey(d => d.SubCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElectricityProductionPlant_SubCategoryCatalogue");
        });

        modelBuilder.Entity<MainCategoryCatalogue>(entity =>
        {
            entity.HasKey(e => e.CatalogueId);

            entity.ToTable("MainCategoryCatalogue");

            entity.Property(e => e.CatalogueId)
                .HasMaxLength(50)
                .HasColumnName("Catalogue_id");
            entity.Property(e => e.De)
                .HasMaxLength(50)
                .HasColumnName("de");
            entity.Property(e => e.En)
                .HasMaxLength(50)
                .HasColumnName("en");
            entity.Property(e => e.Fr)
                .HasMaxLength(50)
                .HasColumnName("fr");
            entity.Property(e => e.It)
                .HasMaxLength(50)
                .HasColumnName("it");
        });

        modelBuilder.Entity<OrientationCatalogue>(entity =>
        {
            entity.HasKey(e => e.CatalogueId);

            entity.ToTable("OrientationCatalogue");

            entity.Property(e => e.CatalogueId)
                .HasMaxLength(50)
                .HasColumnName("Catalogue_id");
            entity.Property(e => e.De)
                .HasMaxLength(50)
                .HasColumnName("de");
            entity.Property(e => e.En)
                .HasMaxLength(50)
                .HasColumnName("en");
            entity.Property(e => e.Fr)
                .HasMaxLength(50)
                .HasColumnName("fr");
            entity.Property(e => e.It)
                .HasMaxLength(50)
                .HasColumnName("it");
        });

        modelBuilder.Entity<PlantCategoryCatalogue>(entity =>
        {
            entity.HasKey(e => e.CatalogueId);

            entity.ToTable("PlantCategoryCatalogue");

            entity.Property(e => e.CatalogueId)
                .HasMaxLength(50)
                .HasColumnName("Catalogue_id");
            entity.Property(e => e.De)
                .HasMaxLength(50)
                .HasColumnName("de");
            entity.Property(e => e.En)
                .HasMaxLength(50)
                .HasColumnName("en");
            entity.Property(e => e.Fr)
                .HasMaxLength(50)
                .HasColumnName("fr");
            entity.Property(e => e.It)
                .HasMaxLength(50)
                .HasColumnName("it");
        });

        modelBuilder.Entity<PlantDetail>(entity =>
        {
            entity.HasKey(e => e.XtfId);

            entity.ToTable("PlantDetail");

            entity.Property(e => e.XtfId)
                .HasMaxLength(50)
                .HasColumnName("xtf_id");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Inclination).HasMaxLength(50);
            entity.Property(e => e.Orientation).HasMaxLength(50);
            entity.Property(e => e.PlantCategory).HasMaxLength(50);

            entity.HasOne(d => d.ElectricityProductionPlantRNavigation).WithMany(p => p.PlantDetails)
                .HasForeignKey(d => d.ElectricityProductionPlantR)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlantDetail_ElectricityProductionPlant");

            entity.HasOne(d => d.OrientationNavigation).WithMany(p => p.PlantDetails)
                .HasForeignKey(d => d.Orientation)
                .HasConstraintName("FK_PlantDetail_OrientationCatalogue");

            entity.HasOne(d => d.PlantCategoryNavigation).WithMany(p => p.PlantDetails)
                .HasForeignKey(d => d.PlantCategory)
                .HasConstraintName("FK_PlantDetail_PlantCategoryCatalogue");
        });

        modelBuilder.Entity<SubCategoryCatalogue>(entity =>
        {
            entity.HasKey(e => e.CatalogueId);

            entity.ToTable("SubCategoryCatalogue");

            entity.Property(e => e.CatalogueId)
                .HasMaxLength(50)
                .HasColumnName("Catalogue_id");
            entity.Property(e => e.De)
                .HasMaxLength(50)
                .HasColumnName("de");
            entity.Property(e => e.En)
                .HasMaxLength(50)
                .HasColumnName("en");
            entity.Property(e => e.Fr)
                .HasMaxLength(50)
                .HasColumnName("fr");
            entity.Property(e => e.It)
                .HasMaxLength(50)
                .HasColumnName("it");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
