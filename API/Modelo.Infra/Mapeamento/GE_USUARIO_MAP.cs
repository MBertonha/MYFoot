using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using static Modelo.Infra.Contexto.MyFootContexto;

namespace Modelo.Infra.Mapeamento
{
    public class GE_USUARIO_MAP : IEntityTypeConfiguration<GE_USUARIO>
    {
        public void Configure(EntityTypeBuilder<GE_USUARIO> builder)
        {
            builder.HasKey(e => new { e.SeqUsuario });

            builder.Property(e => e.SeqUsuario)
                .HasColumnName("seq_usuario")
                .ValueGeneratedOnAdd()
                .HasValueGenerator((x, y) => new SequenceValueGenerator("seq_geusuario"));

            builder.Property(e => e.NomeUsuario)
                .HasMaxLength(50)
                .HasColumnName("nomeusuario");

            builder.Property(e => e.DtaNascimento)
                .HasColumnName("dataNascimento");

            builder.Property(e => e.Endereco)
                .HasMaxLength(20)
                .HasColumnName("endereco");

            builder.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("cep");

            builder.Property(e => e.Uf)
                .HasMaxLength(2)
                .HasColumnName("uf");

            builder.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasColumnName("telefone");

            builder.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");

            builder.Property(e => e.Ativo)
                .HasMaxLength(1)
                .HasColumnName("ativo");

            builder.Property(e => e.DtaInclusao)
                .HasColumnName("dataInclusao");

            builder.Property(e => e.SeqTime)
                .HasColumnName("seq_time");

            builder.Property(e => e.SeqLogin)
                .HasColumnName("seq_login");

            builder.Property(e => e.Dm)
                .HasMaxLength(2)
                .HasColumnName("Dm");

            builder.Property(e => e.Cpf)
                .HasMaxLength(15)
                .HasColumnName("cpf");

            builder.Property(e => e.Rg)
                .HasMaxLength(15)
                .HasColumnName("rg");

            builder.Property(e => e.Inadimplente)
                .HasMaxLength(1)
                .HasColumnName("inadimplente");

            builder.Property(e => e.PosicaoPreferencial)
                .HasMaxLength(20)
                .HasColumnName("posicao_preferencial");

            builder.Ignore(e => e.ResultadoValidacao);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("ge_usuario");
        }
    }
}
