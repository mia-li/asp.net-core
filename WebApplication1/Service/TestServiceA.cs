using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interface;

namespace WebApplication1.Service
{
    public class TestServiceA:ITestServiceA
    {
        public TestServiceA()
        {
            Console.WriteLine($"{this.GetType().Name}被构造...");
        }
        public void show()
        {
            Console.WriteLine("a1234");
        }
    }
}
