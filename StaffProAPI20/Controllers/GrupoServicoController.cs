using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using staffpro.Domain;
using staffpro.entity;

namespace StaffProAPI20.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowAll")]
    public class GrupoServicoController : Controller
    {
        [HttpGet]
        public async Task<IList<ServiceGroups>> GetAllAsync()
        {
            ServiceGroupsBO servicesgroup = new ServiceGroupsBO();
            return await servicesgroup.GetAllActivate();
        }
    }
}
