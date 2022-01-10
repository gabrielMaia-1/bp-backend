using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IEntityContext
    {
        DbSet<Posto> Postos { get; }
        DbSet<Combustivel> Combustivel { get; set; }
        DbSet<TipoCombustivel> TipoCombustivel { get; set; }
    }
}
