using Api.Exceptions;
using Api.Models;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCombustivelController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public TipoCombustivelController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_uow.TipoCombustivel.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {
            return Ok(_uow.TipoCombustivel.Get(id));
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromBody] TipoCombustivel dto)
        {
            var tipo = _uow.TipoCombustivel.Get(id);

            if (dto is null) throw new ApiException("A Entidade que voce esta tentando atualizar não existe.");

            tipo.Nome = dto.Nome;
            tipo.Aditivado = dto.Aditivado;

            _uow.Complete();

            return Ok(tipo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TipoCombustivelDto dto)
        {
            var tipo = _uow.TipoCombustivel.Add(new TipoCombustivel()
            {
                Nome = dto.Nome,
                Aditivado = dto.Aditivado
            });

            _uow.Complete();

            return Ok(tipo);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var tipo = _uow.TipoCombustivel.Get(id);

            if (tipo is null) throw new ApiException("A Entidade que voce esta tentando excluir não existe.");

            tipo = _uow.TipoCombustivel.Remove(tipo);

            _uow.Complete();

            return Ok(tipo);
        }
    }
}
