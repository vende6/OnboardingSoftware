using OnboardingSoftware.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAplikantRepository Aplikanti { get; }
        IVjestinaRepository Vjestine { get; }
        Task<int> CommitAsync();
    }
}
