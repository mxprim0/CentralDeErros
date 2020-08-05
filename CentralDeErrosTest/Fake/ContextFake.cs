using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErrosTest.Fake
{
    public class ContextFake
    {
        private readonly string _prefixDataBase;

        public ContextFake(string prefixDataBase)
        {
            _prefixDataBase = prefixDataBase;
        }
    }
}
