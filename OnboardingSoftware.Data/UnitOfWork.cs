using OnboardingSoftware.Core;
using OnboardingSoftware.Core.Repositories;
using OnboardingSoftware.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnboardingSoftwareDbContext _context;
        private VjestinaRepository _vjestinaRepository;
        private AplikantRepository _aplikantRepository;
        private PosaoRepository _posaoRepository;
        private TestRepository _testRepository;

        public UnitOfWork(OnboardingSoftwareDbContext context)
        {
            this._context = context;
        }

        public IVjestinaRepository Vjestine => _vjestinaRepository = _vjestinaRepository ?? new VjestinaRepository(_context);

        public IAplikantRepository Aplikanti => _aplikantRepository = _aplikantRepository ?? new AplikantRepository(_context);

        public IPosaoRepository Poslovi => _posaoRepository = _posaoRepository ?? new PosaoRepository(_context);

        public ITestRepository Testovi => _testRepository = _testRepository ?? new TestRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
