using System;
using System.Collections.Generic;
using Lumin.Models;
using Microsoft.EntityFrameworkCore;

namespace Lumin.Contexts;

public partial class LuminContext : DbContext
{
    public LuminContext()
    {
    }

    public LuminContext(DbContextOptions<LuminContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curtida> Curtidas { get; set; }

    public virtual DbSet<Postagem> Postagems { get; set; }

    public virtual DbSet<PrestadorDeServico> PrestadorDeServicos { get; set; }

    public virtual DbSet<TipoPrestador> TipoPrestadors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Lumin;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curtida>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curtidas__3213E83F2E3EEDC6");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Horario).HasColumnType("datetime");
            entity.Property(e => e.TipoId).HasColumnName("Tipo_id");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Tipo).WithMany(p => p.Curtida)
                .HasForeignKey(d => d.TipoId)
                .HasConstraintName("FK__Curtidas__Tipo_i__59063A47");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Curtida)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Curtidas__Usuari__5812160E");
        });

        modelBuilder.Entity<Postagem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Postagem__3213E83FE5E75CF6");

            entity.ToTable("Postagem");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Likes).HasDefaultValue(0);
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Postagems)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Postagem__Usuari__4CA06362");
        });

        modelBuilder.Entity<PrestadorDeServico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__prestado__3213E83F0FFEAF2F");

            entity.ToTable("prestadorDeServicos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Certificados)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TipoId).HasColumnName("Tipo_id");

            entity.HasOne(d => d.Tipo).WithMany(p => p.PrestadorDeServicos)
                .HasForeignKey(d => d.TipoId)
                .HasConstraintName("FK__prestador__Tipo___5535A963");
        });

        modelBuilder.Entity<TipoPrestador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tipoPres__3213E83FAD3EADB7");

            entity.ToTable("tipoPrestador");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(9)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83FCBB4EC71");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__AB6E616491977D3B").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("senha");
            entity.Property(e => e.Telefone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
