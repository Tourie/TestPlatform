using System;
using System.Collections.Generic;
using System.Text;

namespace TestPlatform.Core
{
    public class Answer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool isTruth { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
