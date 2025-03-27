using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest
{
    public class Func
    {
        public string RetursPikachuIfZero(int num)
        {
            if (num == 0)
            {
                return "Pikachu";
            }
            return "Not Pikachu";

        }
    }
}