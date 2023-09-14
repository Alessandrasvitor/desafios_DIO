using catalogojogos.DTO.InputModel;
using catalogojogos.Exceptions;
using catalogojogos.Model;
using catalogojogos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace catalogojogos.Controllers
{
    [Route("api/jogos")]
    [ApiController]
    public class JogosController : ControllerBase
    {

        private readonly IJogoService _jogoService;

        public JogosController (IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Jogo>>> Obter([FromQuery, Range(1, int.MaxValue)] int pag = 1, [FromQuery, Range(1, 50)] int qtd = 5)
        {
            var jogos = await _jogoService.Obter(pag, qtd);

            if(jogos.Count == 0)
            {
                return NoContent();
            }

            return Ok(jogos);

        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<Jogo>> Obter([FromRoute] long id)
        {
            try
            {
                return Ok(await _jogoService.Obter(id));
            } 
            catch (NaoEncontradoException)
            {
                return BadRequest("O jogo não foi encontrado na base de dados");
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }


        }

        [HttpPost]
        public async Task<ActionResult<Jogo>> Inserir([FromBody] JogoInputDTO jogo)
        {
            try
            {
                return Ok(await _jogoService.Inserir(jogo));
            }
            catch (DuplicacaoException)
            {
                return BadRequest("O jogo já existe na base de dados");
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }

        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> Alterar([FromRoute] long id, [FromBody] JogoInputDTO jogo)
        {
            try
            {
                await _jogoService.Atualizar(id, jogo);
                return Ok();
            }
            catch (DuplicacaoException)
            {
                return BadRequest("O jogo já existe na base de dados");
            }
            catch (NaoEncontradoException)
            {
                return BadRequest("O jogo não foi encontrado na base de dados");
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }

        }

        [HttpPatch("{id:long}/preco/{preco:double}")]
        public async Task<ActionResult> Alterar([FromRoute] long id, [FromBody] double preco)
        {
            try
            {
                await _jogoService.Atualizar(id, preco);
                return Ok();
            }
            catch (NaoEncontradoException)
            {
                return BadRequest("O jogo não foi encontrado na base de dados");
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }

        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> Excluir([FromRoute] long id)
        {
            try
            {
                await _jogoService.Excluir(id);
                return Ok();
            }
            catch (NaoEncontradoException)
            {
                return BadRequest("O jogo não foi encontrado na base de dados");
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }

        }



    }
}
