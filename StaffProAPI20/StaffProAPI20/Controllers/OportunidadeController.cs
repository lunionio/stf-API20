using System.Collections.Generic;
using staffpro.Domain;
using Microsoft.AspNetCore.Mvc;
using staffpro.entity;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Cors;
using staffpro.servico;

namespace StaffProAPI20.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowAll")]
    public class OportunidadeController : Controller
    {

        [HttpGet("{idCliente}/{token}")]
        public async Task<IList<Oportunidade>> GetAllAsync(string token, int idCliente)
        {
            return await OportunidadeBO.GetListAsync(idCliente, token);
        }

        [HttpGet("{idUsuarioCriacao}/{idCliente}/{token}", Name = "GetAllByCliente")]
        public async Task<List<Oportunidade>> GetAllByClienteAsync(int idUsuarioCriacao, int idCliente, string token)
        {
            return await OportunidadeBO.GetListByClienteAsync(idUsuarioCriacao, idCliente, token);
        }

        [HttpGet("{id}", Name = "GetAllByID")]
        public Oportunidade GetAllByID(int id)
        {
            //OportunidadeBO oportunidade = new OportunidadeBO();
            //return OportunidadeBO.GetList().Where(x => x.ID == id).FirstOrDefault();
            throw new NotImplementedException();
        }

        [HttpPost("{idCliente}/{token}")]
        public async Task<string> SaveAsync([FromBody]Oportunidade obj, int idCliente, string token)
        {


            OportunidadeBO oportunidade = new OportunidadeBO();
            try
            {
                await OportunidadeBO.SaveAsync(obj, idCliente, token);
                return "Oportunidade cadastrada com sucesso";
            }
            catch (Exception e)
            {
                return "Houve uma falha ao salvar, aguarde uns instante ou entre em contato com o suporte";
            }
        }

        [HttpGet("{cep}", Name = "GetEnderecoByCEP")]
        public async Task<object> GetEnderecoByCEPAsync(string cep)
        {
            // Correios
            return await EnderecoServ.GetEnderecoByCep(cep);
        }

        [HttpPost("{idCliente}/{token}")]
        public async Task<string> RemoveAsync([FromBody]Oportunidade obj, int idCliente, string token)
        {
            OportunidadeBO oportunidade = new OportunidadeBO();
            try
            {
                //Status de remoção
                obj.Status = 9;
                await OportunidadeBO.SaveAsync(obj, idCliente, token);
                return "Oportunidade removida com sucesso";
            }
            catch (Exception e)
            {
                return "Houve uma falha ao salvar, aguarde uns instante ou entre em contato com o suporte";
            }
        }
    }

}
