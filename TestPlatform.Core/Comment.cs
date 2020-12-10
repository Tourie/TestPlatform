using System;
using System.Collections.Generic;
using System.Text;

namespace TestPlatform.Core
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public DateTime PostedDate { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }

        public User User { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}
