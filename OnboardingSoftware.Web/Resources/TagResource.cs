using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Web.Resources
{
    public class ModelVariables //multiselectlist
    {
        public IEnumerable<SelectListItem> Options { set; get; }
        public string[] SelectedOptions { set; get; }
        public int LinkId { get; set; }
        public string TagName { get; set; }

    }
    public class TagResource
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public int LinkId { get; set; }
        public string NumberOfOccurances { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
