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

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Curtida> Curtidas { get; set; }

    public virtual DbSet<Midium> Midia { get; set; }

    public virtual DbSet<Postagem> Postagems { get; set; }

    public virtual DbSet<PrestadorDeServico> PrestadorDeServicos { get; set; }

    public virtual DbSet<TipoPrestador> TipoPrestadors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public object Usuario { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Lumin;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comentar__3213E83F7244D827");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PostagemId).HasColumnName("Postagem_id");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Postagem).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.PostagemId)
                .HasConstraintName("FK__Comentari__Posta__73BA3083");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Comentari__Usuar__72C60C4A");
        });

        modelBuilder.Entity<Curtida>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curtidas__3213E83FAD6B959F");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Horario).HasColumnType("datetime");
            entity.Property(e => e.PostagemId).HasColumnName("Postagem_id");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Postagem).WithMany(p => p.Curtida)
                .HasForeignKey(d => d.PostagemId)
                .HasConstraintName("FK__Curtidas__Postag__07C12930");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Curtida)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Curtidas__Usuari__06CD04F7");
        });

        modelBuilder.Entity<Midium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Midia__3213E83F8D292EF3");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Imagem)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.PostagemId).HasColumnName("Postagem_id");

            entity.HasOne(d => d.Postagem).WithMany(p => p.Midia)
                .HasForeignKey(d => d.PostagemId)
                .HasConstraintName("FK__Midia__Postagem___0D7A0286");
        });

        modelBuilder.Entity<Postagem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Postagem__3213E83FCFFD96C7");

            entity.ToTable("Postagem");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Postagems)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Postagem__Usuari__59063A47");
        });

        modelBuilder.Entity<PrestadorDeServico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__prestado__3213E83F3DD802B1");

            entity.ToTable("prestadorDeServicos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Certificados)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TipoId).HasColumnName("Tipo_id");

            entity.HasOne(d => d.Tipo).WithMany(p => p.PrestadorDeServicos)
                .HasForeignKey(d => d.TipoId)
                .HasConstraintName("FK__prestador__Tipo___5DCAEF64");
        });

        modelBuilder.Entity<TipoPrestador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tipoPres__3213E83FF024ADF6");

            entity.ToTable("tipoPrestador");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(9)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83F83AC3AE8");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__AB6E61648C33AA1F").IsUnique();

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
