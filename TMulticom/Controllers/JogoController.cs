using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMulticom.Data.Repositories;
using TMulticom.Domain.Models;

namespace TMulticom.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class JogoController : ControllerBase
    {
        private readonly IBaseRepository<Jogo> _JogoRepository;

        public JogoController(IBaseRepository<Jogo> JogoRepository)
        {
            _JogoRepository = JogoRepository;
        }

        [HttpGet]
        public IEnumerable<Jogo> Get()
        {
            return _JogoRepository.ObterTodos();
        }

        [HttpGet("{id}")]
        public Jogo Get(Guid id)
        {
            return _JogoRepository.ObterPorId(id);
        }

        [HttpPost]
        public ActionResult<Jogo> Post([FromBody] Jogo Jogo)
        {
            _JogoRepository.Adicionar(Jogo);

            return Ok(Jogo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _JogoRepository.RemoverPorId(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Jogo Jogo)
        {
            _JogoRepository.Atualizar(Jogo);
            return Ok();
        }
    }
}
