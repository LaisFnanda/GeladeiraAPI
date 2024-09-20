using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context;

public class ItemContext : DbContext
{
    public virtual DbSet<Item> Items { get; set; }

    public ItemContext(DbContextOptions<ItemContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
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
            entity.Property(e => e.UnidadeQtd)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("UNIDADE");
        });

        // OnModelCreatingPartial(modelBuilder);
    }

    //protected override void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
