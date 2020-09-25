using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Runtime.Serialization;

namespace TestPlatform.Models
{
    public class Question
    {
        private int Testid { get; }
        public  string Name { get; private set; }

        public Question(string Name)
        {
            
        }
    }
}