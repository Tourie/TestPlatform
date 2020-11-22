using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Runtime.Serialization;

namespace TestPlatform.Domain.Core
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int Testid { get; }
        public  string Name { get; private set; }
        public virtual Test Test { get; set; }

        public Question(string Name)
        {
            this.Name = Name;
        }
    }
}