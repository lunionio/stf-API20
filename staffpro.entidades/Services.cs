using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace staffpro.entity
{
    /// <summary>
    /// Esta classe é uma injection da regra de negocio criada pela Asteria 
    /// Qualquer duvida entra em contato com o leder tecnico do projeto :)
    /// </summary>
    public class Services
    {
        [Key]
        public short ServiceId { get; set; }

        [ForeignKey("ServiceGroups")]
        public byte ServiceGroupId { get; set; }

        public string Name { get; set; }
        public bool IsActive { get; set; }
        
        public Decimal? DefaultBudgetByHour { get; set; }
        public Decimal? DefaultBudgetByDay { get; set; }
        public Decimal? DefaultBudgetByEvent { get; set; }

    }
}
