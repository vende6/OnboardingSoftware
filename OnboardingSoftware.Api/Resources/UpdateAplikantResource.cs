﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Resources
{
    public class UpdateAplikantResource
    {
        public string BrojTelefona { get; set; }
        public string MjestoRodjenja { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public string Bio { get; set; }
        public string StatusZaposlenja { get; set; }
        public string TrenutnaPozicija { get; set; }
        public string Industrija { get; set; }
    }
}
