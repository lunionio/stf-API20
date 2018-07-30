using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace staffpro.servico
{
    public class EnderecoServ
    {
        public static async Task<Object> GetEnderecoByCep(string cep)
        {

            //WebPix Geo
            throw new NotImplementedException();

            //RestClient client = new RestClient("http://localhost:5300/");
            //var url = "/api/token/ValidaToken/" + token;
            //RestRequest request = null;
            //request = new RestRequest(url, Method.GET);
            //var response = await client.ExecuteTaskAsync(request);
            //return Convert.ToBoolean(response.Content);
        }
    }
}
