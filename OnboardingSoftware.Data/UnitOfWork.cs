﻿using OnboardingSoftware.Core;
using OnboardingSoftware.Core.Repositories;
using OnboardingSoftware.Core.Repositories.Associations;
using OnboardingSoftware.Data.Repositories;
using OnboardingSoftware.Data.Repositories.Associations;
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
        private AplikantRepository _aplikantRepository;
        private VjestinaRepository _vjestinaRepository;
        private InteresRepository _interesRepository;
        private PosaoRepository _posaoRepository;
        private TestRepository _testRepository;
        private PitanjeRepository _pitanjeRepository;
        private OdgovorRepository _odgovorRepository;
        private AplikantTestRepository _aplikantTestRepository;
        private AplikantPosaoRepository _aplikantPosaoRepository;
        private AplikantVjestinaRepository _aplikantVjestinaRepository;
        private AplikantInteresRepository _aplikantInteresRepository;

        public UnitOfWork(OnboardingSoftwareDbContext context)
        {
            this._context = context;
        }

        public IAplikantRepository Aplikanti => _aplikantRepository = _aplikantRepository ?? new AplikantRepository(_context);

        public IVjestinaRepository Vjestine => _vjestinaRepository = _vjestinaRepository ?? new VjestinaRepository(_context);

        public IInteresRepository Interesi => _interesRepository = _interesRepository ?? new InteresRepository(_context);

        public IPosaoRepository Poslovi => _posaoRepository = _posaoRepository ?? new PosaoRepository(_context);

        public ITestRepository Testovi => _testRepository = _testRepository ?? new TestRepository(_context);

        public IPitanjeRepository Pitanja => _pitanjeRepository = _pitanjeRepository ?? new PitanjeRepository(_context);

        public IOdgovorRepository Odgovori => _odgovorRepository = _odgovorRepository ?? new OdgovorRepository(_context);

        public IAplikantTestRepository AplikantTest => _aplikantTestRepository = _aplikantTestRepository ?? new AplikantTestRepository(_context);

        public IAplikantPosaoRepository AplikantPosao => _aplikantPosaoRepository = _aplikantPosaoRepository ?? new AplikantPosaoRepository(_context);

        public IAplikantVjestinaRepository AplikantVjestina => _aplikantVjestinaRepository = _aplikantVjestinaRepository ?? new AplikantVjestinaRepository(_context);

        public IAplikantInteresRepository AplikantInteres => _aplikantInteresRepository = _aplikantInteresRepository ?? new AplikantInteresRepository(_context);

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
