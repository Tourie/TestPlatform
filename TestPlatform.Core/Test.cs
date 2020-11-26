using System;
using System.Collections.Generic;
using System.Threading;

namespace TestPlatform.Core
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint Time { get; set; } 
      /*  public DateTime Created { get; set; }
        public DateTime Changed { get; set; }*/

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Question> Questions { get; set; }
    }
}