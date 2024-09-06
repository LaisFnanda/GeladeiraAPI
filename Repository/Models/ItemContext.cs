using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public class ItemContext : DbContext
{
    public ItemContext()
    {
    }

    public ItemContext(DbContextOptions<ItemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ItemModels> Items { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAIS\\MSSQLSERVER01;Database=Geladeira;Uid=sa;Pwd=123456;Trusted_Connection=True;TrustServerCertificate=True;");
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemModels>(entity =>
        {
            entity.HasKey(e => e.IdItem)
                .HasName("PK_ID_ITEM")
                .IsClustered(false);

            entity.ToTable("ITEM");

            entity.Property(e => e.IdItem).HasColumnName("ID_ITEM");
            entity.Property(e => e.Andar).HasColumnName("ANDAR");
            entity.Property(e => e.Classificacao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLASSIFICACAO");
            entity.Property(e => e.Container).HasColumnName("CONTAINER");
            entity.Property(e => e.DescricaoItem)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRICAO_ITEM");
            entity.Property(e => e.Posicao).HasColumnName("POSICAO");
            entity.Property(e => e.Quantidade).HasColumnName("QUANTIDADE");
            entity.Property(e => e.Unidade)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("UNIDADE");
        });

       // OnModelCreatingPartial(modelBuilder);
    }

    //protected override void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
