using staffpro.entity;
using staffPro.repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace staffpro.Domain
{
    public class OportunidadeBO
    {
        public bool Save(Oportunidade oportunidade)
        {
            if(oportunidade.ID == 0)
            {
                OportunidadeRep rep = new OportunidadeRep();
                oportunidade.DataCriacao = DateTime.Now;
                oportunidade.DataEdicao = DateTime.Now;
                oportunidade.Ativo = true;
                try
                {
                    rep.Add(oportunidade);
                    return true;
                }
                catch(Exception e)
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
                    return true;
                }
                catch (Exception e)
                {
                    ///:)
                    return false;
                }
            }
        }
        public IList<Oportunidade> GetList()
        {
            OportunidadeRep rep = new OportunidadeRep();
            //9 é deletado
            return rep.GetAll().Where(x => x.Status == 9).ToList();
        }
        public bool Remove(Oportunidade oportunidade)
        {
            oportunidade.Status = 9;
            Save(oportunidade);
            throw new NotImplementedException();
        }
        public IList<Oportunidade> GetListByCliente(int idCliente)
        {

            OportunidadeRep oportunidade = new OportunidadeRep();
            return oportunidade.GetAll().Where(x => x.UsuarioCriacao == idCliente).ToList();

        }

    }
}