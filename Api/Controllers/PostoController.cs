using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly IUnitOfWork _uof;

        public PostoController(IUnitOfWork uow)
        {
            _uof = uow;
        }

        [HttpGet("posto/proximo")]
        public IActionResult GetPostosInRange([FromQuery]double lat, [FromQuery] double lng, double range)
        {
            return Ok(_uof.Posto.GetPostosInRange(lat, lng, range));
        }

        [HttpGet]
        public IActionResult GetAllPostos()
        {
            return Ok(_uof.Posto.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetPosto(int id)
        {
            return Ok(_uof.Posto.Get(id));
        }

        [HttpPost]
        public IActionResult PostPosto([FromBody] PostoDto posto)
        {
            var p = _uof.Posto.Add(new Posto()
            {
                Latitude = posto.Latitude,
                Longitude = posto.Longitude,
                Nome = posto.Nome
            });

            _uof.Complete();

            return Ok(p);
        }

        [HttpPut("{id}")]
        public IActionResult PutPosto([FromRoute] int id, [FromBody] PostoDto posto)
        {
            var p = _uof.Posto.Get(id);

            if (p is null) throw new Exception("A Entidade que voce esta tentando atualizar não existe.");

            p.Latitude = posto.Latitude;
            p.Longitude = posto.Longitude;
            p.Nome = posto.Nome;

            _uof.Complete();

            return Ok(posto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePosto([FromRoute] int id)
        {
            var p = _uof.Posto.Get(id);

            if (p is null) throw new Exception("A Entidade que voce esta tentando excluir não existe.");

            _uof.Posto.Remove(p);

            _uof.Complete();

            return Ok(new PostoDto { Id = p.Id, Nome = p.Nome, Latitude = p.Latitude, Longitude = p.Longitude});
        }
    }
}
