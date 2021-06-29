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
    public class AmigoController : ControllerBase
    {
        private readonly IAmigoRepository _amigoRepository;
        private readonly IMapper _mapper;

        private Guid _userId => Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        public AmigoController(IAmigoRepository amigoRepository, IMapper mapper)
        {
            _amigoRepository = amigoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<AmigoResponse> Get()
        {
            var amigos = _amigoRepository.ObterTodos()
                .Where(x => x.UserId == _userId)
                .OrderBy(x => x.Nome);
            var ret = _mapper.Map<List<AmigoResponse>>(amigos);
            return ret;

        }

        [HttpGet("{id}")]
        public ActionResult<AmigoResponse> Get(Guid id)
        {
            var amigo = _amigoRepository.ObterPorId(id);

            if (amigo.UserId != _userId)
                return NotFound();

            var ret = _mapper.Map<AmigoResponse>(amigo);
            return ret;
        }

        [HttpPost]
        public ActionResult<AmigoResponse> Post([FromBody] AmigoRequest amigo)
        {
            var ret = _mapper.Map<Amigo>(amigo);
            ret.DefinirUserId(_userId);
            _amigoRepository.Adicionar(ret);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var amigo = _amigoRepository.ObterPorId(id);

            if (amigo == null || amigo.UserId != _userId)
            {
                return NotFound();
            }
            else
            {
                foreach (var item in amigo.Jogos)
                {
                    item.RemoverEmprestimo();
                }
            }

            _amigoRepository.RemoverPorId(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] AmigoRequest amigo)
        {
            var amigoRep = _amigoRepository.ObterPorId(amigo.Id);

            if (amigoRep.UserId != _userId)
                return NotFound();

            var upd = _mapper.Map(amigo, amigoRep);            
            _amigoRepository.Atualizar(upd);
            return Ok();
        }

        
    }
}
