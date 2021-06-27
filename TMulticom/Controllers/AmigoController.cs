using AutoMapper;
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
using TMulticom.Web.Model.Responses;

namespace TMulticom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AmigoController : ControllerBase
    {
        private readonly IAmigoRepository _amigoRepository;
        private readonly IEmprestimoService _emprestimoService;
        private readonly IMapper _mapper;

        public AmigoController(IAmigoRepository amigoRepository, IEmprestimoService emprestimoService, IMapper mapper)
        {
            _amigoRepository = amigoRepository;
            _emprestimoService = emprestimoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<AmigoResponse> Get()
        {
            var amigos = _amigoRepository.ObterTodos();
            var ret = _mapper.Map<List<AmigoResponse>>(amigos);
            return ret;

        }

        [HttpGet("{id}")]
        public AmigoResponse Get(Guid id)
        {
            var amigo = _amigoRepository.ObterPorId(id);
            var ret = _mapper.Map<AmigoResponse>(amigo);
            return ret;

        }

        [HttpPost]
        public ActionResult<AmigoResponse> Post([FromBody] AmigoRequest amigo)
        {
            var ret = _mapper.Map<Amigo>(amigo);
            _amigoRepository.Adicionar(ret);
            return Ok(ret);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var amigo = _amigoRepository.ObterPorId(id);

            if (amigo == null)
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
            var upd = _mapper.Map<Amigo>(amigo);
            _amigoRepository.Atualizar(upd);
            return Ok();
        }

        
    }
}
