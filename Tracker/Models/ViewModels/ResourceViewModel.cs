using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Tracker.Models.ViewModels
{
    public class ResourceViewModel
    {
        [Key]
        [Required]
        public int resourceId { get; set; }
        [Display(Name = "Resource Name")]
        [Required(ErrorMessage = "*")]
        public string resourceName { get; set; }

        [Display(Name = "Link")]
        [Required(ErrorMessage = "*")]
        public string resourceLink { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "*")]
        public string description { get; set; }
        
        [Display(Name = "Proficiency Level")]
        [Required(ErrorMessage = "*")]
        public int proficiencyId { get; set; }



    }
}