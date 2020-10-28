using System.Collections.Generic;
using System.Threading;

namespace TestPlatform.Models
{
    public class Test
    {
        public int Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public uint Time { get; set; } 
        public int CategoryId { get; private set; }
       
        public virtual Category Category { get; set; }
        public IEnumerable<Question> Questions { get; set; }

        public Test(string name, string description, uint time)
        {
            Name = name;
            Description = description;
            Time = time;
/*            CategoryId = categoryId;
*/        }
    }
}