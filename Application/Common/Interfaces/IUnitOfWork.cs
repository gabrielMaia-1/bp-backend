using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IPostoRepository Posto { get; }
        int Complete();
    }
}
