using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Unip.SuperSisAmigo.Entities;

namespace Unip.SuperSisAmigo.DataAccess.Mappings
{
    public sealed class EstadoCivilMapping : EntityTypeConfiguration<EstadoCivil>
    {
        public EstadoCivilMapping()
        {
            ToTable("TB_ESTADO_CIVIL");
            HasKey(x => x.Codigo);

            Property(x => x.Codigo).HasColumnName("ID_ESTADO_CIVIL")
                .HasColumnType("int");

            Property(x => x.Descricao).HasColumnName("DS_ESTADO_CIVIL")
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
