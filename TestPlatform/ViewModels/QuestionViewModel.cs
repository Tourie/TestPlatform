using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Core;

namespace TestPlatform.WEB.ViewModels
{
    public class QuestionViewModel
    {
        public int TestId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Answers")]
        public IEnumerable<Answer> Answers { get; set; }
    }
}
