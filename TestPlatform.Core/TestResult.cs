using System;
using System.Collections.Generic;
using System.Text;

namespace TestPlatform.Core
{
    public class TestResult
    {
        public int Id { get; set; }
        public int RightAnswers { get; set; }
        public int Answers { get; set; }
        public DateTime Started { get; set; }
        public DateTime Finished { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
