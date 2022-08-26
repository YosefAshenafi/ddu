using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DDU.Models
{
    public partial class db_a676b9_dduContext : DbContext
    {
        public db_a676b9_dduContext()
        {
        }

        public db_a676b9_dduContext(DbContextOptions<db_a676b9_dduContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= sql5097.site4now.net;Database=db_a676b9_ddu;user id=db_a676b9_ddu_admin;password=P@ssw0rd;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentCode).HasMaxLength(50);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.DisplayDepartmentId).HasColumnName("DisplayDepartmentID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ParentDepartmentId).HasColumnName("ParentDepartmentID");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.RootDepartmentId).HasColumnName("RootDepartmentID");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.SessionIp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionIP");

                entity.Property(e => e.SessionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SessionMAC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
