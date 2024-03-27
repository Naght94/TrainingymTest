using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Trainingym.Models;

namespace Trainingym.Context;

public partial class TrainingymContext : DbContext
{
    public TrainingymContext()
    {
    }

    public TrainingymContext(DbContextOptions<TrainingymContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("Member");

            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.MemberName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("member_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.FkMemberid).HasColumnName("fk_memberid");
            entity.Property(e => e.FkProductid).HasColumnName("fk_productid");
            entity.Property(e => e.OrderDateorder).HasColumnName("order_dateorder");

            entity.HasOne(d => d.FkMember).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FkMemberid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Member");

            entity.HasOne(d => d.FkProduct).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FkProductid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("product_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
