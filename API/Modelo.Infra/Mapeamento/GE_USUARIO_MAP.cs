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

            builder.Property(e => e.DataNascimento)
                .HasColumnName("dataNascimento");

            builder.Property(e => e.Endereco)
                .HasMaxLength(20)
                .HasColumnName("endereco");

            builder.Property(e => e.CEP)
                .HasMaxLength(8)
                .HasColumnName("cep");

            builder.Property(e => e.UF)
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

            builder.Property(e => e.DataInclusao)
                .HasColumnName("dataInclusao");

            builder.Property(e => e.SeqTime)
                .HasColumnName("seq_time");
            
            builder.Property(e => e.SeqLogin)
                .HasColumnName("seq_login");


            builder.Ignore(e => e.ResultadoValidacao);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("ge_usuario");
        }
    }
}
