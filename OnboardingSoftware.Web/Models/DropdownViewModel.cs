using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Web.Models
{
    public class DropdownViewModel
    {
        public DropdownViewModel()
        {
            TagResources = new List<SelectListItem>();

        }
        public string SelectedValue { get; set; }
        public List<SelectListItem> TagResources { get; set; }

    }
}
