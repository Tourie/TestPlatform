using System.Collections.Generic;

namespace TestPlatform.Models
{
    public class Test
    {
        public int Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int CategoryId { get; private set; }
        public virtual Category Category { get; set; }
        IEnumerable<Question> Questions { get; set; }

        public Test(string name, string description)
        {
            Name = name;
            Description = description;
/*            CategoryId = categoryId;
*/        }
    }
}