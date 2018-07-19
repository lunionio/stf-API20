using staffpro.entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using staffPro.Repository;
using System.Linq;

namespace staffpro.Domain
{
    public class ServicesBO
    {
        public async Task<IList<Services>> GetAllActivateByGroup(int idGroup)
        {
            ServicesRep services = new ServicesRep();
            var retorno = await services.GetAllByGroup(idGroup);
            return retorno.Where(x => x.IsActive == true).ToList();
        }
    }
}
