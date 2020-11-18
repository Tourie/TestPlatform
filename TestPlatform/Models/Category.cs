using System.Collections.Generic;

namespace TestPlatform.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; }
        public string Description { get; set; }
        public IEnumerable<Test> Tests { get; set; }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}