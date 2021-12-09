using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OnboardingSoftware.Web.Models;

namespace OnboardingSoftware.Web.Resources
{
    public class LinkResource
    {
        public LinkResource()
        {
            //TagResources = new List<TagResource>();
            TagResources = new List<SelectListItem>();
            NewTagResources = new List<SelectListItem>();
        }
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string UserId { get; set; }
        //public ICollection<TagResource> TagResources { get; set; }
        // public DropdownViewModel DropdownResource { get; set; }

        public string SelectedTag { get; set; }
        public List<SelectListItem> TagResources { get; set; }
        public List<SelectListItem> NewTagResources { get; set; }
    }
}

