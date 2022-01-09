using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistence.Context
{
    internal class EntityContext : DbContext, IEntityContext
    {
        public DbSet<Posto> Postos { get; set; }

        public EntityContext(DbContextOptions options) : base(options)
        {
        }
    }
}
