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
    public class PostoController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public PostoController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("posto/proximo")]
        public IActionResult GetPostosInRange([FromQuery]double lat, [FromQuery] double lng, double range)
        {
            return Ok(_uow.Posto.GetPostosInRange(lat, lng, range));
        }

        [HttpGet]
        public IActionResult GetAllPostos()
        {
            return Ok(_uow.Posto.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetPosto(int id)
        {
            return Ok(_uow.Posto.Get(id));
        }

        [HttpPost]
        public IActionResult PostPosto([FromBody] PostoDto dto)
        {
            var p = _uow.Posto.Add(new Posto()
            {
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                Nome = dto.Nome
            });

            _uow.Complete();

            return Ok(p);
        }

        [HttpPut("{id}")]
        public IActionResult PutPosto([FromRoute] int id, [FromBody] PostoDto dto)
        {
            var p = _uow.Posto.Get(id);

            if (p is null) throw new ApiException("A Entidade que voce esta tentando atualizar não existe.");

            p.Latitude = dto.Latitude;
            p.Longitude = dto.Longitude;
            p.Nome = dto.Nome;

            _uow.Complete();

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePosto([FromRoute] int id)
        {
            var p = _uow.Posto.Get(id);

            if (p is null) throw new ApiException("A Entidade que voce esta tentando excluir não existe.");

            _uow.Posto.Remove(p);

            _uow.Complete();

            return Ok(new PostoDto { Id = p.Id, Nome = p.Nome, Latitude = p.Latitude, Longitude = p.Longitude});
        }
    }
}
