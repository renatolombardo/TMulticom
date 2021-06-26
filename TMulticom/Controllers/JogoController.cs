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

namespace TMulticom.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class JogoController : ControllerBase
    {
        private readonly IBaseRepository<Jogo> _jogoRepository;

        public JogoController(IBaseRepository<Jogo> JogoRepository)
        {
            _jogoRepository = JogoRepository;
        }

        [HttpGet]
        public IEnumerable<Jogo> Get()
        {
            return _jogoRepository.ObterTodos();
        }

        [HttpGet("{id}")]
        public Jogo Get(Guid id)
        {
            return _jogoRepository.ObterPorId(id);
        }

        [HttpPost]
        public ActionResult<Jogo> Post([FromBody] Jogo jogo)
        {
            _jogoRepository.Adicionar(jogo);

            return Ok(jogo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _jogoRepository.RemoverPorId(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Jogo jogo)
        {
            _jogoRepository.Atualizar(jogo);
            return Ok();
        }

        
    }
}
