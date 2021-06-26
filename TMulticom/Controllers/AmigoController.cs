using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMulticom.Data.Repositories;
using TMulticom.Domain.Data;
using TMulticom.Domain.Models;
using TMulticom.Domain.Services;
using TMulticom.Web.Model.Requests;

namespace TMulticom.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AmigoController : ControllerBase
    {
        private readonly IAmigoRepository _amigoRepository;
        private readonly IEmprestimoService _emprestimoService;

        public AmigoController(IAmigoRepository amigoRepository, IEmprestimoService emprestimoService)
        {
            _amigoRepository = amigoRepository;
            _emprestimoService = emprestimoService;
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

        [HttpPost]
        [Route("emprestarjogo")]
        public IActionResult Post([FromBody] EmprestarJogoRequest request)
        {
            _emprestimoService.EmprestarJogo(request.JogoId, request.AmigoId);

            return Ok();
        }

        [HttpPost]
        [Route("devolverjogo/{id}")]
        public IActionResult Post(Guid id)
        {
            _emprestimoService.DevolverJogo(id);
            return Ok();
        }
    }
}
