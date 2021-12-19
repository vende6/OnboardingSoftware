using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Web.Models
{
    public class OdgovorViewModel
    {
        public OdgovorViewModel()
        {
            TagResources = new List<SelectListItem>();
        }


        public string ID { get; set; }
        public string PonudjeniOdgovor_1 { get; set; }
        public string PonudjeniOdgovor_2 { get; set; }
        public string PonudjeniOdgovor_3 { get; set; }
        public string PonudjeniOdgovor_4 { get; set; }
        public int PitanjeID { get; set; }

        public string Pitanje { get; set; }

        public string SelectedTag { get; set; }
        public List<SelectListItem> TagResources { get; set; }

    }
}

