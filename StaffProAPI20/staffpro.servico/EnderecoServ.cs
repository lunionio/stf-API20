using RestSharp;
using staffpro.entity;
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

        public static async Task<bool> SaveEnderecoAsync(Endereco endereco, string token)
        {
            RestClient client = new RestClient("http://localhost:5330/");
            var url = "/api/endereco/save/" + token;
            RestRequest request = null;
            request = new RestRequest(url, Method.POST);

            request.AddBody(endereco);
            request.RequestFormat = DataFormat.Json;

            var response = await client.ExecuteTaskAsync(request);
            //return response.Content;

            return true;
        }

        public static async Task<bool> RemoveEnderecoAsync(Endereco endereco, string token)
        {
            RestClient client = new RestClient("http://localhost:5330/");
            var url = "/api/endereco/remove/" + token;
            RestRequest request = null;
            request = new RestRequest(url, Method.POST);

            request.AddBody(endereco);
            request.RequestFormat = DataFormat.Json;

            var response = await client.ExecuteTaskAsync(request);
            //return response.Content;

            return true;
        }
    }
}
