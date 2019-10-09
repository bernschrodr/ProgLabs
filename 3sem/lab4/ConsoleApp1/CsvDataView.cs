using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    struct Product
    {
        public string name;
        public string type;
        public List<WhereSell> whereSell;

    }

    struct WhereSell
    {
        public string shopId;
        public string cost;
        public string count;

    }
}
