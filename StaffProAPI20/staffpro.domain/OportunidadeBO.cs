using staffpro.entity;
using staffpro.servico;
using staffPro.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace staffpro.Domain
{
    public class OportunidadeBO
    {
        public static async Task<bool> SaveAsync(Oportunidade oportunidade, int idCliente, string token)
        {
            if (await SeguracaServ.validaTokenAsync(token))
            {
                if (oportunidade.ID == 0)
                {
                    OportunidadeRep rep = new OportunidadeRep();
            
        oportunidade.DataCriacao = DateTime.Now;
                    oportunidade.DataEdicao = DateTime.Now;
                    oportunidade.Ativo = true;
                    try
                    {
                        rep.Add(oportunidade);
                        if(await EnderecoServ.SaveEnderecoAsync(oportunidade.Endereco, token))
                        {
                            return false;
                        }

                        return false;
                    }
                    catch (Exception e)
                    {
                        ///:)
                        return false;
                    }
                }
                else
                {
                    OportunidadeRep rep = new OportunidadeRep();
                    oportunidade.DataEdicao = DateTime.Now;
                    try
                    {
                        rep.Update(oportunidade);
                        if(await EnderecoServ.RemoveEnderecoAsync(oportunidade.Endereco, token))
                        {
                            await EnderecoServ.SaveEnderecoAsync(oportunidade.Endereco, token);
                            return true;
                        }

                        return false;
                    }
                    catch (Exception e)
                    {
                        ///:)
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

        }

        public static async Task<IList<Oportunidade>> GetListAsync(int idCliente, string token)
        {

            if (await SeguracaServ.validaTokenAsync(token))
            {
                OportunidadeRep rep = new OportunidadeRep();
                //9 é deletado
                return rep.GetAll().Where(x => x.Status != 9 && x.IdCliente == idCliente).ToList();
            }
            else
            {
                return null;
            }

        }

        public static async Task<bool> RemoveAsync(Oportunidade oportunidade, string token)
        {
            if (await SeguracaServ.validaTokenAsync(token))
            {
                try
                {
                    oportunidade.Status = 9;
                    OportunidadeRep rep = new OportunidadeRep();
                    rep.Update(oportunidade);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public static async Task<List<Oportunidade>> GetListByClienteAsync(int idUsuarioCriacao, int idCliente, string token)
        {
            if (await SeguracaServ.validaTokenAsync(token))
            {
                OportunidadeRep oportunidade = new OportunidadeRep();
                IList<Oportunidade> list = oportunidade.GetAll().Where(x =>
                x.UsuarioCriacao == idUsuarioCriacao &&
                x.IdCliente == idCliente).ToList();

                return list.OrderBy(x => x.DataOportunidade).ToList();
            }
            else
            {
                return null;
            }
           

        }
    }
}