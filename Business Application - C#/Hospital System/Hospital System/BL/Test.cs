using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_System.BL
{
    class Test
    {
        private string name;
        private string result;
        public Test(string name)
        {
            this.name = name;
            result = "Null";
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetResult()
        {
            return result;
        }
        public void SetResult(string result)
        {
            this.result = result;
        }
        public string toString()
        {
            return "Test[name=" + name + ",result=" + result + "]";
        }
    }
}
