using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Server.Models
{
    public class HomeModel
    {
        Dictionary<int, bool> tests = new Dictionary<int, bool>();
        public Dictionary<int, bool> ReturnDict()
        {
            tests.Add(1, true);
            tests.Add(2, false);
            return tests;
        }
    }
}
