using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMulticom.Data.Repositories;
using TMulticom.Domain.Data;
using TMulticom.Domain.Models;
using TMulticom.Web.Model.Requests;
using TMulticom.Web.Model.Responses;

namespace TMulticom.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class JogoController : ControllerBase
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly IMapper _mapper;

        public JogoController(IJogoRepository jogoRepository, IMapper mapper)
        {
            _jogoRepository = jogoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<JogoResponse> Get()
        {
            var jogos = _jogoRepository.ObterTodos();
            var ret = _mapper.Map<List<JogoResponse>>(jogos);
            return ret;
        }

        [HttpGet("{id}")]
        public JogoResponse Get(Guid id)
        {
            var jogo = _jogoRepository.ObterPorId(id);
            var ret = _mapper.Map<JogoResponse>(jogo);
            return ret;
        }

        [HttpPost]
        public ActionResult<JogoResponse> Post([FromBody] JogoRequest jogo)
        {
            var add = _mapper.Map<Jogo>(jogo);
            _jogoRepository.Adicionar(add);
            return Ok(add);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _jogoRepository.RemoverPorId(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] JogoRequest jogo)
        {
            var upd = _mapper.Map<Jogo>(jogo);
            _jogoRepository.Atualizar(upd);
            return Ok();
        }

        [HttpGet]
        [Route("disponiveis")]
        public IEnumerable<JogoResponse> JogosDisponiveis()
        {
            var jogos = _jogoRepository.ObterJogosDisponiveis();
            var result = _mapper.Map<List<JogoResponse>>(jogos);
            return result;
        }

        [HttpGet]
        [Route("emprestados")]
        public IEnumerable<JogoResponse> JogosEmprestados()
        {
            var jogos = _jogoRepository.ObterJogosEmprestados();
            var result = _mapper.Map<List<JogoResponse>>(jogos);
            return result;
        }


    }
}
