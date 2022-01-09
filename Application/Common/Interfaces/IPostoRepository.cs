using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IPostoRepository : IRepository<Posto>
    {
        IEnumerable<Posto> GetPostosInRange(double lat, double lng, double range);
    }
}
