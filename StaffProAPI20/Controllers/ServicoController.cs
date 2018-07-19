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
    public class ServicoController : Controller
    {
        [HttpGet("{idGroup}", Name = "GetAllByGroup")]
        public async Task<IList<Services>> GetAllByGroupAsync(int idGroup)
        {
            ServicesBO services = new ServicesBO();
            return await services.GetAllActivateByGroup(idGroup);
        }

    }
}
