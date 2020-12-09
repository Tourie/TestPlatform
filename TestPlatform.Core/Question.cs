using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Runtime.Serialization;

namespace TestPlatform.Core
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Testid { get; set; }
        public virtual Test Test { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public int IdRightAnswer { get; set; }
    }
}