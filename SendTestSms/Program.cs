using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendTestSms
{
    class Program
    {


        static void Main(string[] args)
        {
            //string[] Args = { "TESTSMS" };
            //args = Args;

            switch (args[0].ToString().ToUpper().Replace("'", ""))
            {
                

                case "SENDTESTSMS":
                    TestSms sms = new TestSms();
                    sms.SMSSEND_V2();
                    break;

                case "TESTSMS":
                    TestSms ms = new TestSms();
                    ms.SMSSEND_V5();
                    break;
            }
        }
    }
}
