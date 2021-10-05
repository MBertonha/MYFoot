using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using static Modelo.Infra.Contexto.MyFootContexto;

namespace Modelo.Infra.Mapeamento
{
    public class GE_JOGADOR_MAP : IEntityTypeConfiguration<GE_JOGADOR>
    {
        public void Configure(EntityTypeBuilder<GE_JOGADOR> builder)
        {
            builder.HasKey(e => new { e.SeqJogador });

            builder.Property(e => e.SeqJogador)
                .HasColumnName("seq_jogador")
                .ValueGeneratedOnAdd()
                .HasValueGenerator((x, y) => new SequenceValueGenerator("seq_gejogador"));

            builder.Property(e => e.SeqUsuario)
                .HasColumnName("seq_usuario");

            builder.Property(e => e.Gols)
                .HasColumnName("gols");

            builder.Property(e => e.Ca)
                .HasColumnName("ca");

            builder.Property(e => e.Cv)
                .HasColumnName("cv");

            builder.Property(e => e.GolsSofridos)
                .HasColumnName("golsSofridos");

            builder.Property(e => e.JogosJogados)
                .HasColumnName("jogosJogados");

            builder.Property(e => e.Status)
                .HasMaxLength(1)
                .HasColumnName("status");

            builder.Ignore(e => e.ResultadoValidacao);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("ge_jogador");
        }
    }
}
