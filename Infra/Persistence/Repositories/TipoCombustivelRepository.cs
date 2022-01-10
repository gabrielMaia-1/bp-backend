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
    internal class CombustivelRepository : Repository<Combustivel>, ICombustivelRepository
    {
        private EntityContext _context { get { return (Context as EntityContext); } }
        public CombustivelRepository(EntityContext context) : base(context)
        {
        }
    }
}
