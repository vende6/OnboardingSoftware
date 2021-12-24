﻿using OnboardingSoftware.Core.Repositories;
using OnboardingSoftware.Core.Repositories.Associations;
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
        IPosaoRepository Poslovi { get; }
        ITestRepository Testovi { get; }
        IPitanjeRepository Pitanja { get; }
        IOdgovorRepository Odgovori { get; }
        IAplikantTestRepository AplikantTest { get; }
        IAplikantPosaoRepository AplikantPosao { get; }

        Task<int> CommitAsync();
    }
}

