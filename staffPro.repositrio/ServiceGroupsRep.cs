using Microsoft.EntityFrameworkCore;
using staffpro.entity;
using staffPro.repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace staffPro.Repository
{
    public class ServiceGroupsRep
    {
        public async Task<IList<ServiceGroups>> GetAll()
        {
            staffproContext context = new staffproContext();

            string Query = @"select * from [ServiceGroups]";

            //rever os meus conceitos jaja 
            //meu deus eu sou um lixo me ajuda 
            try
            {
                var ListObj = await context.ServiceGroups.FromSql(Query).ToListAsync();
                return ListObj;
            }
            catch (Exception e)
            {
                return new List<ServiceGroups>();
            }

        }
    }
}
