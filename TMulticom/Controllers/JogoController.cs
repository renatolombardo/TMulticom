using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TMulticom.Data.Repositories;
using TMulticom.Domain.Data;
using TMulticom.Domain.Models;
using TMulticom.Domain.Services;
using TMulticom.Web.Model.Requests;
using TMulticom.Web.Model.Responses;

namespace TMulticom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class JogoController : ControllerBase
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly IEmprestimoService _emprestimoService;
        private readonly IMapper _mapper;

        private Guid _userId => Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        public JogoController(IJogoRepository jogoRepository, IMapper mapper, IEmprestimoService emprestimoService)
        {
            _jogoRepository = jogoRepository;
            _mapper = mapper;
            _emprestimoService = emprestimoService;
            
        }

        [HttpGet]
        public IEnumerable<JogoResponse> Get()
        {
            var jogos = _jogoRepository.ObterTodosPorUserId(_userId)
                .OrderBy(x => x.Nome);
            var ret = _mapper.Map<List<JogoResponse>>(jogos);
            return ret;
        }

        [HttpGet("{id}")]
        public ActionResult<JogoResponse> Get(Guid id)
        {
            var jogo = _jogoRepository.ObterPorId(id);

            if (jogo.UserId != _userId)
                return NotFound();

            var ret = _mapper.Map<JogoResponse>(jogo);
            return ret;
        }

        [HttpPost]
        public ActionResult<JogoResponse> Post([FromBody] JogoRequest jogo)
        {
            var add = _mapper.Map<Jogo>(jogo);
            add.DefinirUserId(_userId);
            _jogoRepository.Adicionar(add);
            return Ok(add);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var jogo = _jogoRepository.ObterPorId(id);

            if (jogo == null || jogo.UserId != _userId)
                return NotFound();

            _jogoRepository.RemoverPorId(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] JogoRequest jogo)
        {
            var jogoRep = _jogoRepository.ObterPorId(jogo.Id);

            if (jogoRep == null || jogoRep.UserId != _userId)
                return NotFound();

            var upd = _mapper.Map(jogo, jogoRep);

            _jogoRepository.Atualizar(upd);
            return Ok();
        }

        [HttpGet]
        [Route("disponiveis")]
        public IEnumerable<JogoResponse> JogosDisponiveis()
        {
            var jogos = _jogoRepository.ObterJogosDisponiveis(_userId)
                .OrderBy(x => x.Nome);
            var result = _mapper.Map<List<JogoResponse>>(jogos);
            return result;
        }

        [HttpGet]
        [Route("emprestados")]
        public IEnumerable<JogoResponse> JogosEmprestados()
        {
            var jogos = _jogoRepository.ObterJogosEmprestados(_userId)
                .OrderBy(x => x.Nome);
            var result = _mapper.Map<List<JogoResponse>>(jogos);
            return result;
        }

        [HttpPost]
        [Route("emprestar")]
        public IActionResult Post([FromBody] EmprestarJogoRequest request)
        {
            try
            {                               
                _emprestimoService.EmprestarJogo(request.JogoId, request.AmigoId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("devolver/{id}")]
        public IActionResult Post(Guid id)
        {
            try
            {
                _emprestimoService.DevolverJogo(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
