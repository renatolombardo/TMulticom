using Microsoft.AspNetCore.Authorization;
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
    public class AmigoController : ControllerBase
    {
        private readonly IAmigoRepository _amigoRepository;

        public AmigoController(IAmigoRepository amigoRepository)
        {
            _amigoRepository = amigoRepository;
        }

        [HttpGet]
        public IEnumerable<Amigo> Get()
        {
            return _amigoRepository.ObterTodos();
        }

        [HttpGet("{id}")]
        public Amigo Get(Guid id)
        {
            return _amigoRepository.ObterPorId(id);
        }

        [HttpPost]
        public ActionResult<Amigo> Post([FromBody]Amigo amigo)
        {
            _amigoRepository.Adicionar(amigo);

            return Ok(amigo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _amigoRepository.RemoverPorId(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody]Amigo amigo)
        {
            _amigoRepository.Atualizar(amigo);
            return Ok();
        }
    }
}
