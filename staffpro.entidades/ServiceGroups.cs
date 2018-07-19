using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace staffpro.entity
{
    public class ServiceGroups
    {
        [Key]
        public byte ServiceGroupId { get; set; }

        public string Description { get; set; }
        public byte Sequel { get; set; }
        public bool IsActive { get; set; }
        public bool IsManagementGroup { get; set; }

    }
}
