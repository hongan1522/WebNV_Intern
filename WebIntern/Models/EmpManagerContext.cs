using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebIntern.Models;

public partial class EmpManagerContext : DbContext
{
    //public EmpManagerContext()
    //{
    //}

    public EmpManagerContext(DbContextOptions<EmpManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-CMSGFMS\\HONGAN;Database=EmpManager;Trusted_Connection=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(20);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Position).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
