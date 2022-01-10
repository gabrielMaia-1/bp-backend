using Application.Common.Interfaces;
using Infra.Persistence.Context;
using Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistence
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly EntityContext _context;
        public IPostoRepository Posto { get; private set; }
        public ICombustivelRepository Combustivel { get; private set; }
        public ITipoCombustivelRepository TipoCombustivel { get; private set; }

        public UnitOfWork(EntityContext context)
        {
            _context = context;
            Posto = new PostoRepository(_context);
            Combustivel = new CombustivelRepository(_context);
            TipoCombustivel = new TipoCombustivelRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
