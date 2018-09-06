﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WpOportunidades.Domains;
using WpOportunidades.Entities;
using WpOportunidades.Infrastructure.Exceptions;

namespace WpOportunidades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class OportunidadesController : ControllerBase
    {
        private readonly OportunidadeDomain _opDomain;

        public OportunidadesController(OportunidadeDomain domain)
        {
            _opDomain = domain;
        }

        [HttpPost("{token}")]
        public async Task<IActionResult> SaveAsync([FromRoute]string token, [FromBody]Oportunidade oportunidade)
        {
            try
            {
                await _opDomain.SaveAsync(oportunidade, token);
                return Ok("Oportunidade salva com sucesso.");
            }
            catch (OportunidadeException e)
            {
                return StatusCode(502, $"{ e.Message } { e.InnerException.Message }");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar salvar a oportunidade recebida. Entre em contato com o suporte.");
            }
        }

        [HttpGet("{idCliente:int}/{token}")]
        public async Task<IActionResult> GetAllAsync([FromRoute]string token, [FromRoute]int idCliente)
        {
            try
            {
                var response = await _opDomain.GetOportunidadesAsync(idCliente, token);
                return Ok(response);
            }
            catch (OportunidadeException e)
            {
                return StatusCode(502, $"{ e.Message } { e.InnerException.Message }");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocoreu um erro ao tentar listar as oportunidades disponíveis. Entre em contato com o suporte.");
            }
        }

        [HttpGet("{idUsuarioCriacao:int}/{idCliente:int}/{token}")]
        public async Task<IActionResult> GetAllByClienteAsync([FromRoute]int idUsuarioCriacao, [FromRoute]int idCliente, [FromRoute]string token)
        {
            try
            {
                var response = await _opDomain.GetOportunidadesAsync(idUsuarioCriacao, idCliente, token);
                return Ok(response);
            }
            catch (OportunidadeException e)
            {
                return StatusCode(502, $"{ e.Message } { e.InnerException.Message }");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocoreu um erro ao tentar listar as oportunidades disponíveis. Entre em contato com o suporte.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            try
            {
                var response = await _opDomain.GetOportunidadeAsync(id);
                return Ok(response);
            }
            catch (OportunidadeException e)
            {
                return StatusCode(502, $"{ e.Message } { e.InnerException.Message }");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocoreu um erro ao tentar recuperar a oportunidade solicitada. Entre em contato com o suporte.");
            }
        }

        [HttpDelete("{token}")]
        public IActionResult RemoveAsync([FromRoute]string token, [FromBody]Oportunidade oportunidade)
        {
            try
            {
                _opDomain.DeleteAsync(oportunidade, token);
                return Ok("Oportunidade removida com sucesso.");
            }
            catch(OportunidadeException e)
            {
                return StatusCode(502, $"{ e.Message } { e.InnerException.Message }");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocoreu um erro ao tentar remover a oportunidade. Entre em contato com o suporte.");
            }
        }
    }
}