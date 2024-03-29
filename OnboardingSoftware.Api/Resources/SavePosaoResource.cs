﻿using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Resources
{
    public class SavePosaoResource
    {
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string Kategorija { get; set; }
        public string Opis { get; set; }
        public LokacijaResource Lokacija { get; set; }
    }
}
