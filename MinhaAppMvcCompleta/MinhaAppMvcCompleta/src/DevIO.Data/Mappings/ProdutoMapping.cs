﻿using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            builder.Property(x => x.Descricao)
                   .IsRequired()
                   .HasColumnType("varchar(1000)");

            builder.Property(x => x.Imagem)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.ToTable("Produtos");
            //builder.ToTable("Produtos", "nome_do_schema");
        }
    }
}
