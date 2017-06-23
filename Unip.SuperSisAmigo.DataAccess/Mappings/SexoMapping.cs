using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Subimos pra memoria a DLL do EF pra fazer os mapeamentos
using System.Data.Entity.ModelConfiguration;

//Subimos pra memoria a DLL de armazenamento de dados, é la que ficam as classes que vao ser tranformadas em tabela
using Unip.SuperSisAmigo.Entities;

//Além de gerar o banco temos que gerar também as tabelas e campos
//Cada entidade de Dominio vai virar uma tabela
//Amigo -> TB_AMIGO
//Sexo -> TB_SEXO
//Todas as configurações de mapeamento de tabelas ficam no arquivo de mapeamento
namespace Unip.SuperSisAmigo.DataAccess.Mappings
{
    //A classe EntityTypeConfiguration nos ajuda, nos oferece comandos pra fazer a transformação da classe em tabela
    //Vamos transformar a classe de sexo em uma tabela de sexo
    public sealed class SexoMapping : EntityTypeConfiguration<Sexo>
    {
        //Via fluente API (Linguagem Continua) vamos fazer o mapeamento da tabela
        public SexoMapping()
        {
            ToTable("TB_SEXO");

            //HasKey é só pra chave primaria (PK)
            //Se for mais de uma chave (Composta) x => new {x.campo1, x.campo2}
            HasKey(x => x.Codigo);

            Property(x => x.Codigo).HasColumnName("ID_SEXO")
                .HasColumnType("int");

            Property(x => x.Descricao).HasColumnName("DS_SEXO")
                .HasColumnType("varchar")
                .HasMaxLength(9).IsRequired();
        }
    }
}
