using Harboard_Back.Domain.Entities;
using Harboard_Back.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Harboard_Back.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConteinerController : ControllerBase
    {
        
        private readonly ILogger<ConteinerController> _logger;
        private IConteinerRepository conteinerRepository;

        public ConteinerController(ILogger<ConteinerController> logger, IConteinerRepository conteinerRepository)
        {
            _logger = logger;
            this.conteinerRepository = conteinerRepository;
        }

        [HttpGet("/Conteineres")]
        public ActionResult ListarConteineres()
        {
            List<Conteiner> listaConteineres = this.conteinerRepository.ListarConteineres().Result;
            if(listaConteineres == null)
            {
                return NotFound();
            }
            return Ok(listaConteineres);
        }

        [HttpGet("{idConteiner}")]
        public ActionResult PesquisarConteinerPorId([FromRoute] int idConteiner)
        {
            Conteiner conteiner = this.conteinerRepository.PesquisarConteinerPorId(idConteiner).Result;
            if (conteiner == null)
            {
                return NotFound();
            }
            return Ok(conteiner);
        }

        [HttpPost]
        public ActionResult CadastrarConteiner([FromBody] Conteiner conteiner)
        {
            Conteiner conteinerCadastrado = this.conteinerRepository.CadastrarConteiner(conteiner).Result;
            if (conteinerCadastrado == null)
            {
                return NotFound();
            }
            return Ok(conteinerCadastrado);
        }

        [HttpPut("{idConteiner}")]
        public ActionResult AtualizarConteiner([FromRoute] int idConteiner, [FromBody] Conteiner conteiner)
        {
            Conteiner conteinerAtualizado = this.conteinerRepository.AtualizarConteiner(idConteiner, conteiner);
            if (conteinerAtualizado == null)
            {
                return NotFound();
            }
            return Ok(conteinerAtualizado);
        }

        [HttpDelete("{idConteiner}")]
        public ActionResult ExcluirConteinerPorId([FromRoute] int idConteiner)
        {
            Conteiner conteinerDeletado = this.conteinerRepository.ExcluirConteinerPorId(idConteiner);
            if (conteinerDeletado == null)
            {
                return NotFound();
            }
            return Ok(conteinerDeletado);
        }

    }
}