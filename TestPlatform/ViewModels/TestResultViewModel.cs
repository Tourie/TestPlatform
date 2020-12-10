using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestPlatform.Core;

namespace TestPlatform.WEB.ViewModels
{
    public class TestResultViewModel
    {
        [Display (Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "RightAnswers")]
        public int RightAnswers { get; set; }
        [Display (Name = "Answers")]
        public int Answers { get; set; }
        [Display(Name = "Finished")]
        public DateTime finished { get; set; }

        [Display(Name = "Test")]
        public Test Test { get; set; }

        [Display(Name = "User")]
        public User User { get; set; }
    }
}
