using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DDU.Models;

public partial class dba676b9dduContext : DbContext
{
    public dba676b9dduContext()
    {
    }

    public dba676b9dduContext(DbContextOptions<dba676b9dduContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= sql5097.site4now.net;Database=db_a676b9_ddu;user id=db_a676b9_ddu_admin;password=P@ssw0rd;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
