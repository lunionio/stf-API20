using staffpro.entity;
using staffPro.repository;
using System;
using System.Collections.Generic;

namespace staffpro.Domain
{
    public class OportunidadeBO
    {
        public bool Save(Oportunidade evento)
        {
            if(evento.ID == null)
            {
                EventoRep rep = new EventoRep();
                evento.DataCriacao = DateTime.Now;
                evento.DataEdicao = DateTime.Now;
                evento.Ativo = true;
                try
                {
                    rep.Add(evento);
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
                EventoRep rep = new EventoRep();
                evento.DataEdicao = DateTime.Now;
                try
                {
                    rep.Update(evento);
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
            EventoRep rep = new EventoRep();
            return rep.GetAll();
        }
    }
}