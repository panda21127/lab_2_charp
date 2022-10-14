using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Person
{
    class Test
    {
        private string nameTest;
        private bool result;

        public Test()
        {
            nameTest = "Math";
            result = true;
        }
        public Test(string nameTest_test, bool result_test)
        {
            nameTest=nameTest_test;
            result = result_test;
        }
        public override string ToString()
        {
            return nameTest +"\t"+ result.ToString();
        }
    }
}
