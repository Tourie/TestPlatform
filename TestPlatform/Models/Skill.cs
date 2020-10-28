using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestPlatform.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Test> Tests { get; set; }

        public Skill(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
