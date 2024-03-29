﻿using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Core.Services.Associations
{
    public interface IAplikantInteresService
    {
        Task<IEnumerable<AplikantInteres>> GetApplicantsInterests();
        Task<IEnumerable<AplikantInteres>> GetApplicantInterests(int aplikantId);
        Task<bool> CreateAplikantInteresi(IEnumerable<AplikantInteres> newAplikantInteres);
    }
}
