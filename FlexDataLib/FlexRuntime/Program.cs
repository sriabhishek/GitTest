using FlexRule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexDataLib;

namespace FlexRuntime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---");
            FlexCall();
            Console.WriteLine("---");
          
        }

        private static void FlexCall()
        {
            Console.WriteLine("Validate Age");
            var engine = RuntimeEngine.FromXml(File.OpenRead("DecisionTableAge.xml"));
            CheckAge(engine);
            
        }

        private static void CheckAge(IRuntimeEngine engine)
        {
            var emp = new EmpClass();
            emp.EmpAge = 44;
            emp.EmpName = "Abc";
            emp.EmpSal = 20000;
            var result = engine.Run(emp);

            if (!(bool)result.Context.VariableContainer["EMP"])
            {
                foreach (var n in result.Context.Notifications.Default.Notices)
                    Console.WriteLine("{0}: {1}", n.Type, n.Message);
            }
            else
            {
                Console.WriteLine("{0}, Cheerrrssss!", emp.EmpName);
            }
        }
    }
}
