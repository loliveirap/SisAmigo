using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Unip.SuperSisAmigo.Entities;

namespace Unip.SuperSisAmigo.DataAccess.Mappings
{
    public sealed class AmigoMapping : EntityTypeConfiguration<Amigo>
    {
        public AmigoMapping()
        {
            ToTable("TB_AMIGO");
            HasKey(x => x.Codigo);

            Property(x => x.Codigo).HasColumnName("ID_AMIGO")
                .HasColumnType("int");

            Property(x => x.Nome).HasColumnName("NM_AMIGO")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();

            Property(x => x.Email).HasColumnName("DS_EMAIL")
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            Property(x => x.Telefone).HasColumnName("NR_TELEFONE")
                .HasColumnType("varchar")
                .HasMaxLength(15)
                .IsRequired();

            Property(x => x.DataNascimento).HasColumnName("DT_NASCIMENTO")
                .HasColumnType("date")                
                .IsRequired();

            Property(x => x.CodigoSexo).HasColumnName("ID_SEXO")
                .HasColumnType("int")                
                .IsRequired();

            Property(x => x.CodigoEstadoCivil).HasColumnName("ID_ESTADO_CIVIL")
                .HasColumnType("int")
                .IsRequired();

            //Configuramos os relacionamentos(Chaves estrangeiras) FK
            //HasRequired - Relacionamente obrigatorio
            //WithMany - Cardinalidade, muitos pra muitos
            //HasForeignKey - E o campo que vamos relacionar
            HasRequired(x => x.Sexo)
                .WithMany()
                .HasForeignKey(x => x.CodigoSexo);

            HasRequired(x => x.EstadoCivil)
                .WithMany()
                .HasForeignKey(x => x.CodigoEstadoCivil);

            Property(x => x.Endereco).HasColumnName("DS_ENDERECO")
                .HasColumnType("varchar")
                .HasMaxLength(200);

            Property(x => x.Numero).HasColumnName("NR_RESIDENCIA")
                .HasColumnType("varchar")
                .HasMaxLength(5);
        }
    }
}
