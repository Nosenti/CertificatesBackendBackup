using CertificatesBackendBackup.Entities;
using Microsoft.EntityFrameworkCore;

namespace CertificatesBackendBackup.Data;

public partial class CertificatesDbContext : DbContext
{
    public CertificatesDbContext()
    {
    }

    public CertificatesDbContext(DbContextOptions<CertificatesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<CertificateParticipant> CertificateParticipants { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.HasKey(e => e.CertificateId).HasName("PK__Certific__BBF8A7E144A32B79");

            entity.Property(e => e.CertificateId).HasColumnName("CertificateID");
            entity.Property(e => e.CertificateType).HasMaxLength(255);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Certificates)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__Certifica__Suppl__398D8EEE");
        });

        modelBuilder.Entity<CertificateParticipant>(entity =>
        {
            entity.HasKey(e => e.ParticipantId).HasName("PK__Certific__7227997E8F72E309");

            entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");
            entity.Property(e => e.CertificateId).HasColumnName("CertificateID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Certificate).WithMany(p => p.CertificateParticipants)
                .HasForeignKey(d => d.CertificateId)
                .HasConstraintName("FK__Certifica__Certi__3E52440B");

            entity.HasOne(d => d.User).WithMany(p => p.CertificateParticipants)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Certifica__UserI__3F466844");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comments__C3B4DFAA0F8F3A7E");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.CertificateId).HasColumnName("CertificateID");
            entity.Property(e => e.CommentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Certificate).WithMany(p => p.Comments)
                .HasForeignKey(d => d.CertificateId)
                .HasConstraintName("FK__Comments__Certif__4222D4EF");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Comments__UserID__4316F928");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE66694E31B9DDC");

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.SupplierIndex).HasMaxLength(50);
            entity.Property(e => e.SupplierName).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC512E2F58");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
