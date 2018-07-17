using System.Collections.Generic;
using staffpro.Domain;
using Microsoft.AspNetCore.Mvc;
using staffpro.entity;
using System.Linq;
using System;

namespace StaffProAPI20.Controllers
{
    [Produces("application/json")]
    [Route("api/Oportunidade/[Action]")]
    public class OportunidadeController : Controller
    {
        // GET: api/Oportunidade
        [HttpGet]
        public IList<Oportunidade> GetAll()
        {
            return new OportunidadeBO().GetList();
        }

        // GET: api/Oportunidade/5
        [HttpGet("{id}", Name = "Get")]
        public IList<Oportunidade> GetAllByCliente(int idCliente)
        {
            return new OportunidadeBO().GetListByCliente(idCliente);
        }
        // GET: api/Oportunidade/5
        [HttpGet("{id}", Name = "Get")]
        public Oportunidade GetAllByID(int id)
        {
            OportunidadeBO oportunidade = new OportunidadeBO();
            return oportunidade.GetList().Where(x => x.ID == id).FirstOrDefault();
        }

        // POST: api/Oportunidade
        [HttpPost]
        public string Save([FromBody]Oportunidade obj)
        {
            OportunidadeBO oportunidade = new OportunidadeBO();
            try
            {
                oportunidade.Save(obj);
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
                oportunidade.Save(obj);
                return "Oportunidade removida com sucesso";
            }
            catch (Exception e)
            {
                return "Houve uma falha ao salvar, aguarde uns instante ou entre em contato com o suporte";
            }
        }
    }
}
