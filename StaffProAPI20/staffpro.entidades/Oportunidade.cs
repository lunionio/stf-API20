using System;
namespace staffpro.entity
{
    public class Oportunidade : Base
    {
        public int TipoProfissional { get; set; }
        public int TipoServico { get; set; }
        public string DescProfissional { get; set; }
        public string DescServico { get; set; }
        public DateTime DataOportunidade { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; } 
        public Endereco Endereco { get; set; }
    }
}