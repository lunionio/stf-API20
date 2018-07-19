using staffpro.entity;
using staffPro.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace staffpro.Domain
{
    public class ServiceGroupsBO
    {
        public async Task<IList<ServiceGroups>> GetAllActivate()
        {
            var servicegroup = new ServiceGroupsRep();
            var retorno = await servicegroup.GetAll();
            return retorno;
        }
    }
}
