using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DDU.Models;

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

        public virtual DbSet<InvCostCenter> InvCostCenters { get; set; } = null!;

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
            modelBuilder.Entity<InvCostCenter>(entity =>
            {
                entity.HasKey(e => e.CostID);

                entity.ToTable("InvCostCenter");

                entity.HasIndex(e => new { e.DivID, e.CostCode }, "IX_InvCostCenter")
                    .IsUnique();

                entity.Property(e => e.CostCode).HasMaxLength(4);

                entity.Property(e => e.CostName).HasMaxLength(256);

                entity.Property(e => e.SessionID)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SessionIP)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SessionMAC)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<DDU.Models.AllowanceType> AllowanceType { get; set; }

        public DbSet<DDU.Models.InvInventoryItem> InvInventoryItem { get; set; }

        public DbSet<DDU.Models.InvEquipment> InvEquipment { get; set; }

        public DbSet<DDU.Models.InvSupplier> InvSupplier { get; set; }

        public DbSet<DDU.Models.InvBudget> InvBudget { get; set; }
    }
}
