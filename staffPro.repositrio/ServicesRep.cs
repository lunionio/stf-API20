using Microsoft.EntityFrameworkCore;
using staffpro.entity;
using staffPro.repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace staffPro.Repository
{
    public class ServicesRep
    {
        public async Task<IList<Services>> GetAll()
        {
            staffproContext context = new staffproContext();

            string Query = @"select * from [Services]";

            //rever os meus conceitos jaja 
            //meu deus eu sou um lixo me ajuda 
            try
            {
                var ListObj = await context.Services.FromSql(Query).ToListAsync();
                return ListObj;
            }
            catch (Exception e)
            {
                return new List<Services>();
            }

        }
        public async Task<IList<Services>> GetAllByGroup(int idGroup)
        {
            staffproContext context = new staffproContext();

            string Query = @"select * from [Services] where ServiceGroupId =" + idGroup;

            //rever os meus conceitos jaja 
            //meu deus eu sou um lixo me ajuda 
            try
            {
                var ListObj = await context.Services.FromSql(Query).ToListAsync();
                return ListObj;
            }
            catch (Exception e)
            {
                return new List<Services>();
            }

        }

    }
}
