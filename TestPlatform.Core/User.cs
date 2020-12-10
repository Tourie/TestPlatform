﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestPlatform.Core
{
    public class User: IdentityUser
    {
        public IEnumerable<Test> PassedTests { get; set; }
    }
}
