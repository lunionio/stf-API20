using System.Collections.Generic;
using staffpro.Domain;
using Microsoft.AspNetCore.Mvc;
using staffpro.entity;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Cors;

namespace StaffProAPI20.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowAll")]
    public class OportunidadeController : Controller
    {
      
        [HttpGet]
        public IList<Oportunidade> GetAll()
        {
            return new OportunidadeBO().GetList();
        }
       
        [HttpGet("{idCliente}", Name = "GetAllByCliente")]
        public async Task<IList<Oportunidade>> GetAllByClienteAsync(int idCliente)
        {
            OportunidadeBO oportunidade = new OportunidadeBO();
            return await oportunidade.GetListByClienteAsync(idCliente);
        }
      
        [HttpGet("{id}", Name = "GetAllByID")]
        public Oportunidade GetAllByID(int id)
        {
            OportunidadeBO oportunidade = new OportunidadeBO();
            return oportunidade.GetList().Where(x => x.ID == id).FirstOrDefault();
        }

        [HttpPost("{idCliente}")]
        public string Save([FromBody]Oportunidade obj,int idCliente)
        {
            OportunidadeBO oportunidade = new OportunidadeBO();
            try
            {
                oportunidade.Save(obj,idCliente);
                return "Oportunidade cadastrada com sucesso";
            }
            catch (Exception e)
            {
                return "Houve uma falha ao salvar, aguarde uns instante ou entre em contato com o suporte";
            }
        }

        [HttpPost]
        public string Remove([FromBody]Oportunidade obj)
        {
            OportunidadeBO oportunidade = new OportunidadeBO();
            try
            {
                //Status de remoção
                obj.Status = 9;
                oportunidade.Save(obj,0);
                return "Oportunidade removida com sucesso";
            }
            catch (Exception e)
            {
                return "Houve uma falha ao salvar, aguarde uns instante ou entre em contato com o suporte";
            }
        }
    }

}
