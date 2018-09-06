using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WpOportunidades.Entities;
using WpOportunidades.Infrastructure;
using WpOportunidades.Infrastructure.Exceptions;
using WpOportunidades.Services;

namespace WpOportunidades.Domains
{
    public class OportunidadeDomain
    {
        private readonly SegurancaService _segService;
        private readonly OportunidadeRepository _opRepository;
        private readonly EnderecoService _endService;

        public OportunidadeDomain(SegurancaService service, 
            OportunidadeRepository repository, EnderecoService endService)
        {
            _segService = service;
            _opRepository = repository;
            _endService = endService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oportunidade"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="OportunidadeException"></exception>
        public async Task SaveAsync(Oportunidade oportunidade, string token)
        {
            try
            {
                if (oportunidade.ID == 0)
                {
                    await _segService.ValidateTokenAsync(token);

                    oportunidade.DataCriacao = DateTime.UtcNow;
                    oportunidade.DataEdicao = DateTime.UtcNow;
                    oportunidade.Ativo = true;

                    var result = _opRepository.Add(oportunidade);

                    await _endService.SaveEnderecoAsync(oportunidade.Endereco, token);
                }
                else
                {
                    await UpdateAsync(oportunidade, token);
                }
            }
            catch(Exception e)
            {
                throw new OportunidadeException("Não foi possível salvar a oportunidade.", e);
            }
        }

        private async Task UpdateAsync(Oportunidade oportunidade, string token)
        {
            try
            {
                oportunidade.DataEdicao = DateTime.UtcNow;
                _opRepository.Update(oportunidade);

                await _endService.RemoveEnderecoAsync(oportunidade.Endereco, token);
                await _endService.SaveEnderecoAsync(oportunidade.Endereco, token);
            }
            catch(Exception e)
            {
                throw new OportunidadeException("Não foi possível atualizar a oportunidade.", e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="OportunidadeException"></exception>
        public async Task<IEnumerable<Oportunidade>> GetOportunidadesAsync(int idCliente, string token)
        {
            try
            {
                await _segService.ValidateTokenAsync(token);

                var result = _opRepository.GetAll().Where(o => o.Status != 9 && o.IdCliente.Equals(idCliente)).ToList();

                return result;
            }
            catch(Exception e)
            {
                throw new OportunidadeException("Não foi possível recuperar a lista de oportunidades.", e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="OportunidadeException"></exception>
        public Task<Oportunidade> GetOportunidadeAsync(int id)
        {
            try
            {
                var op = _opRepository.GetList(o => o.ID.Equals(id)).SingleOrDefault();
                return new Task<Oportunidade>(() => op);
            }
            catch(Exception e)
            {
                throw new OportunidadeException("Não foi possível recuperar a oportunidade solicitada.", e);
            }
        }

        public void DeleteAsync(Oportunidade oportunidade, string token)
        {
            try
            {
                _opRepository.Remove(oportunidade);
            }
            catch(Exception e)
            {
                throw new OportunidadeException("Não foi possível remover a oportunidade.", e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuarioCriacao"></param>
        /// <param name="idCliente"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="OportunidadeException"></exception>
        public async Task<IEnumerable<Oportunidade>> GetOportunidadesAsync(int idUsuarioCriacao, int idCliente, string token)
        {
            try
            {
                await _segService.ValidateTokenAsync(token);

                var result = _opRepository.GetAll()
                    .Where(o => o.UsuarioCriacao.Equals(idUsuarioCriacao) 
                    && o.IdCliente.Equals(idCliente)).ToList().OrderBy(o => o.DataOportunidade);

                return result;
            }
            catch(Exception e)
            {
                throw new OportunidadeException("Não foi possível recuperar a lista de oportunidades do usuário.", e);
            }
        }
    }
}
