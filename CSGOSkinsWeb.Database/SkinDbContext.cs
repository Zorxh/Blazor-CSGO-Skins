using System;
using CSGOSkinsWeb.Database.Models;
using CSGOSkinsWeb.Database.Models.Profiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSGOSkinsWeb.Database
{
    public partial class SkinDbContext : IdentityDbContext<AppUser>
    {
        public SkinDbContext()
        {
        }

        public SkinDbContext(DbContextOptions<SkinDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Rarity> Rarity { get; set; }
        public virtual DbSet<Skin> Skin { get; set; }
        public virtual DbSet<Weapon> Weapon { get; set; }
        public virtual DbSet<WeaponCase> WeaponCase { get; set; }
        public virtual DbSet<WeaponCollection> WeaponCollection { get; set; }
        public override DbSet<AppUser> Users { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                Console.WriteLine("Error. Database not initialized");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "USER", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Category1).IsUnicode(false);
            });

            modelBuilder.Entity<Rarity>(entity =>
            {
                entity.Property(e => e.Rarityname).IsUnicode(false);
            });

            modelBuilder.Entity<Skin>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Idstring).IsUnicode(false);

                entity.Property(e => e.Imgsrc).IsUnicode(false);

                entity.Property(e => e.Skindescription).IsUnicode(false);

                entity.Property(e => e.Skinname).IsUnicode(false);

                entity.HasOne(d => d.RarityNavigation)
                    .WithMany(p => p.Skin)
                    .HasForeignKey(d => d.Rarity)
                    .HasConstraintName("FK__Skin__rarity__5812160E");

                entity.HasOne(d => d.WeapcaseNavigation)
                    .WithMany(p => p.Skin)
                    .HasForeignKey(d => d.Weapcase)
                    .HasConstraintName("FK__Skin__weapcase__59063A47");

                entity.HasOne(d => d.WeapcollNavigation)
                    .WithMany(p => p.Skin)
                    .HasForeignKey(d => d.Weapcoll)
                    .HasConstraintName("FK__Skin__weapcoll__59FA5E80");

                entity.HasOne(d => d.WeaponNavigation)
                    .WithMany(p => p.Skin)
                    .HasForeignKey(d => d.Weapon)
                    .HasConstraintName("FK__Skin__weapon__571DF1D5");
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.Property(e => e.Imgsrc).IsUnicode(false);

                entity.Property(e => e.Weapname).IsUnicode(false);

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Weapon)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK__Weapon__category__2C3393D0");
            });

            modelBuilder.Entity<WeaponCase>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Casecollection).IsUnicode(false);

                entity.Property(e => e.Casename).IsUnicode(false);

                entity.Property(e => e.Idstring).IsUnicode(false);

                entity.Property(e => e.Imgsrc).IsUnicode(false);
            });

            modelBuilder.Entity<WeaponCollection>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Collectionname).IsUnicode(false);

                entity.Property(e => e.Idstring).IsUnicode(false);

                entity.Property(e => e.Imgsrc).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
