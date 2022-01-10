using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Exceptions;
using Api.Models;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombustivelController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public CombustivelController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_uow.Combustivel.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_uow.Combustivel.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CombustivelDto dto)
        {
            if (!dto.Posto.Id.HasValue || !dto.Tipo.Id.HasValue) throw new ApiException("postoId e tipoId são obrigatórios");

            var posto = _uow.Posto.Get(dto.Posto.Id.Value);
            var tipo = _uow.TipoCombustivel.Get(dto.Tipo.Id.Value);

            var combustivel = _uow.Combustivel.Add(new Combustivel()
            {
                PrecoLitro = dto.Preco,
                Posto = posto,
                TipoCombustivel = tipo

            });

            _uow.Complete();

            return Ok(combustivel);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] CombustivelDto dto)
        {
            if (!dto.Posto.Id.HasValue || !dto.Tipo.Id.HasValue) throw new ApiException("postoId e tipoId são obrigatórios");

            var combustivel = _uow.Combustivel.Get(id);

            if (combustivel is null) throw new ApiException("A Entidade que voce esta tentando atualizar não existe.");

            combustivel.Posto.Id = dto.Posto.Id.Value;
            combustivel.TipoCombustivel.Id = dto.Tipo.Id.Value;
            combustivel.PrecoLitro = dto.Preco;

            _uow.Complete();

            return Ok(_uow.Combustivel.Get(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var combustivel = _uow.Combustivel.Get(id);

            if (combustivel is null) throw new ApiException("A Entidade que voce esta tentando excluir não existe.");

            combustivel = _uow.Combustivel.Remove(combustivel);

            _uow.Complete();

            return Ok(combustivel);
        }
    }
}
