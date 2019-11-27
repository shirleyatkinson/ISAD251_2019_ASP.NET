using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ISAD251_2019_ASP.Models
{
    public partial class ISAD251_SAtkinsonContext : DbContext
    {
        public ISAD251_SAtkinsonContext()
        {
        }

        public ISAD251_SAtkinsonContext(DbContextOptions<ISAD251_SAtkinsonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ShLecturer> ShLecturer { get; set; }
        public virtual DbSet<ShModule> ShModule { get; set; }
        public virtual DbSet<ShRequest> ShRequest { get; set; }
        public virtual DbSet<ShStatus> ShStatus { get; set; }

        //public virtual DbSet<request> Requests { get; set; }
             
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=ISAD251_SAtkinson; User Id=SAtkinson; Password=ISAD251_123");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShLecturer>(entity =>
            {
                entity.HasKey(e => e.LecturerId)
                    .HasName("pk_Lecturer");

                entity.ToTable("sh-Lecturer");

                entity.Property(e => e.LecturerId).HasColumnName("LecturerID");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShModule>(entity =>
            {
                entity.HasKey(e => e.ModuleId)
                    .HasName("pk_Module");

                entity.ToTable("sh-Module");

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            //modelBuilder.Entity<request>(entity =>
            //{
            //    entity.HasKey(e => e.RequestId)
            //        .HasName("pk_Request");

            //    entity.ToTable("sh-Request");

            //    entity.Property(e => e.RequestId).HasColumnName("RequestID");

            //    entity.Property(e => e.DateTime)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");

            //    entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            //    entity.Property(e => e.Problem)
            //       .IsRequired()
            //       .HasMaxLength(255)
            //       .IsUnicode(false);

            //    entity.Property(e => e.Room)
            //        .IsRequired()
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StatusId).HasColumnName("StatusID");

            //    entity.HasOne(d => d.Module)
            //        .WithMany(p => p.ShRequest)
            //        .HasForeignKey(d => d.ModuleId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("fk_Module_Request");

            //    entity.HasOne(d => d.Status)
            //        .WithMany(p => p.ShRequest)
            //        .HasForeignKey(d => d.StatusId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("fk_Request_Status");
            //});

            modelBuilder.Entity<ShRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("pk_Request");

                entity.ToTable("sh-Request");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Problem)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Room)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.ShRequest)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Module_Request");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ShRequest)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Request_Status");
            });

            modelBuilder.Entity<ShStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("pk_Status");

                entity.ToTable("sh-Status");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

           
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
