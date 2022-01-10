using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infra.Persistence.Context;

namespace Infra.Persistence.Repositories
{
    internal class PostoRepository : Repository<Posto>, IPostoRepository
    {
        private EntityContext _context { get { return (Context as EntityContext); } }
        public PostoRepository(EntityContext context) : base(context)
        {
        }

        public IEnumerable<Posto> GetPostosInRange(double lat, double lng, double range)
        {
            //Aproxima consulta com area quadrada (Otimização)
            var aproxdist = (from p in _context.Postos
                             join c in _context.Combustivel on p.Id equals c.Posto.Id
                             where Math.Abs(p.Latitude - lat) < range && Math.Abs(p.Longitude - lng) < range
                             select p).AsEnumerable()
                            ;


            //Filtra resultado usando area redonda ordenando por preco
            return aproxdist.ToList().Where(p => DistancePow2(p.Latitude - lat, p.Longitude - lng) < (range * range));
        }

        /**
         * 
         */
        private double DistancePow2(double x, double y)
        {
            return (x * x) + (y * y);
        }
    }
}
