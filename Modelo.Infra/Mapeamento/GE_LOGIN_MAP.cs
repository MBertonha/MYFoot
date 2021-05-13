using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using static Modelo.Infra.Contexto.MyFootContexto;

namespace Modelo.Infra.Mapeamento
{
    public class GE_LOGIN_MAP : IEntityTypeConfiguration<GE_LOGIN>
    {
        public void Configure(EntityTypeBuilder<GE_LOGIN> builder)
        {
            builder.HasKey(e => new { e.SeqLogin });

            builder.Property(e => e.SeqLogin)
                .HasColumnName("seq_login")
                .ValueGeneratedOnAdd()
                .HasValueGenerator((x, y) => new SequenceValueGenerator("seq_gelogin"));

            builder.Property(e => e.EmailLogin)
                .HasMaxLength(30)
                .HasColumnName("emaillogin");

            builder.Property(e => e.Senha)
                .HasMaxLength(100)
                .HasColumnName("senha");

            builder.Property(e => e.TipoUsuario)
                .HasColumnName("tipousuario");

            builder.Property(e => e.Ativo)
                .HasMaxLength(1)
                .HasColumnName("ativo");

            builder.Ignore(e => e.ResultadoValidacao);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("ge_login");
        }
    }
}
