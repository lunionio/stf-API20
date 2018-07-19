using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using staffpro.entity;
using System.Threading.Tasks;
namespace staffPro.repository
{
    public class OportunidadeRep : Base<Oportunidade>
    {
        //TODO : Area de criação logica baseada na logica de excecoes
        public async Task<IList<Oportunidade>> GetAllByClientAsync(int idClient)
        {
            staffproContext context = new staffproContext();

            const string V = @"
            select B.idEmpresa,A.* from Oportunidade a
            inner JOIN OportunidadeByEmpresa B on b.idOportunidade = a.ID
            where B.idEmpresa =";

            //rever os meus conceitos jaja 
            //meu deus eu sou um lixo me ajuda 
            try
            {
                var ListObj = await context.Oportunidade.FromSql(V + idClient).ToListAsync();
                return ListObj;
            }
            catch (Exception e)
            {
                return new List<Oportunidade>();
            }

        }
        public bool AddClient(Oportunidade oportunidade,int idCliente)
        {
            staffproContext context = new staffproContext();


            string query = string.Format(@"
            insert into OportunidadeByEmpresa 
            values ({0},{1},{2},{3},{4},{5},{6})", 
            oportunidade.ID, 
            idCliente,
            "GETDATE()",
            "GETDATE()",
            oportunidade.UsuarioCriacao,
            oportunidade.UsuarioEdicao,
            oportunidade.Status
            );

            query = query.Replace("\r", "").Replace("\n", "").Trim();

            //rever os meus conceitos jaja 
            //meu deus eu sou um lixo me ajuda 
            try
            {
                var ListObj = context.Database.ExecuteSqlCommand(query);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
    }
}
