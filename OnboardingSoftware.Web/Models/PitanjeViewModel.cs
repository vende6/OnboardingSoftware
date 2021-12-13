using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Web.Models
{
    public class PitanjeViewModel
    {

        public PitanjeViewModel()
        {
            TagResources = new List<SelectListItem>();
        }


        public int ID { get; set; }
        public string Tekst { get; set; }
        public string Tip { get; set; }
        public string RedniBroj { get; set; }
        public int TestID { get; set; }

        public string Test { get; set; }

        public string SelectedTag { get; set; }
        public List<SelectListItem> TagResources { get; set; }

    }
}
