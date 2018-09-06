using RestSharp;
using System;
using System.Threading.Tasks;
using WpOportunidades.Entities;
using WpOportunidades.Infrastructure.Exceptions;

namespace WpOportunidades.Services
{
    public class EnderecoService
    {
        private const string BASE_URL = "http://localhost:5330/";
        private const string URL = "/api/endereco/save/";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endereco"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public async Task SaveEnderecoAsync(Endereco endereco, string token)
        {
            try
            {
                RestClient client = new RestClient(BASE_URL);
                var url = $"{ URL }{ token }";
                RestRequest request = null;
                request = new RestRequest(url, Method.POST);

                request.AddBody(endereco);
                request.RequestFormat = DataFormat.Json;

                var response = await client.ExecuteTaskAsync(request);

                if (!response.IsSuccessful)
                {
                    throw response.ErrorException;
                }
            }
            catch(Exception e)
            {
                throw new ServiceException("Não foi possível salvar o endereço informado.", e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endereco"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public async Task RemoveEnderecoAsync(Endereco endereco, string token)
        {
            try
            {
                RestClient client = new RestClient(BASE_URL);
                var url = $"{ URL }{ token }";
                RestRequest request = null;
                request = new RestRequest(url, Method.POST);

                request.AddBody(endereco);
                request.RequestFormat = DataFormat.Json;

                var response = await client.ExecuteTaskAsync(request);
            }
            catch(Exception e)
            {
                throw new ServiceException("Não foi possível remover o endereço informado.", e);
            }
        }
    }
}
