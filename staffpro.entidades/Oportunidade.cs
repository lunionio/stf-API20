using System;
namespace staffpro.entity
{
    public class Oportunidade : Base
    {
        public int TipoProfissional { get; set; }
        public DateTime DataOportunidade { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Endereco { get; set; }
        public string NumeroLocal { get; set; }
        public string Complemento { get; set; }
    }
}