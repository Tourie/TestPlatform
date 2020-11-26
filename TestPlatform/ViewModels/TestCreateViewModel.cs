using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Core;

namespace TestPlatform.WEB.ViewModels
{
    public class TestCreateViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Time")]
        public uint Time { get; set; }
        
        [Required]
        [Display(Name = "Category")]
        public int[] TestCategory { get;set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
