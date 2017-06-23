using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unip.SuperSisAmigo.Entities
{
    ////[Table("tbl_Amigo")]
    public class Amigo : Base.Entidade
    {
        //No DDD sempre usar a linguagem UBIQUOTOUS LANGUAGE (Linguagem Ubiqua)
        //Ubiqua - Não podemos usar termos técnicos ex: ID usar Código)
       
        //[DisplayColumn("NomeAmigo")]
        //[MaxLength(1000)]
        //[Required]
        //[Key]
        //[ForeignKey]
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public Int32 CodigoSexo { get; set; }
        public Int32 CodigoEstadoCivil { get; set; }

        //Montamos um relacionamento entre as classes, fizemos uma composição trazendo dados de outra classe
        //Da mesma forma que as tabelas se realcionam as classes tem que se relacionar
        //No DDD se chama Raiz de Agregação (Aggregate ROOT)
        //Uma classe principal que possui classes secundarias que dependem da classe principal.
        public virtual Sexo Sexo { get; set; }
        //Quando colocamos o virtual para fazer o inner join automaticamente
        public virtual EstadoCivil EstadoCivil { get; set; }
        public String Endereco { get; set; }
        public String Numero { get; set; }
    }
}
