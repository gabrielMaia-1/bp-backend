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
    internal class TipoCombustivelRepository : Repository<TipoCombustivel>, ITipoCombustivelRepository
    {
        private EntityContext _context { get { return (Context as EntityContext); } }
        public TipoCombustivelRepository(EntityContext context) : base(context)
        {
        }

    }
}
