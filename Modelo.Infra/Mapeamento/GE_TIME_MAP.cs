using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using static Modelo.Infra.Contexto.MyFootContexto;

namespace Modelo.Infra.Mapeamento
{
    public class GE_TIME_MAP : IEntityTypeConfiguration<GE_TIME>
    {
        public void Configure(EntityTypeBuilder<GE_TIME> builder)
        {
            builder.HasKey(e => new { e.SeqTime });

            builder.Property(e => e.SeqTime)
                .HasColumnName("seq_time")
                .ValueGeneratedOnAdd()
                .HasValueGenerator((x, y) => new SequenceValueGenerator("seq_getime"));

            builder.Property(e => e.NomeTime)
                .HasMaxLength(50)
                .HasColumnName("nometime");

            builder.Property(e => e.CEP)
                .HasMaxLength(20)
                .HasColumnName("cep");
           
            builder.Property(e => e.UF)
                .HasMaxLength(2)
                .HasColumnName("uf");

            builder.Property(e => e.TipoPlano)
                .HasColumnName("tipoplano");

            builder.Property(e => e.Ativo)
                .HasMaxLength(1)
                .HasColumnName("ativo");

            builder.Property(e => e.DataInclusao)
                .HasColumnName("dataInclusao");

            builder.Ignore(e => e.ResultadoValidacao);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("ge_time");
        }
    }
}
