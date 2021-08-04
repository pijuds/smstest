using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendTestSms
{
    class TestSms
    {
        public string appid { get; set; }
        public string pwd { get; set; }
        public string msg { get; set; }
        public string template_id { get; set; }
        public TestSms()
        {
            appid = ConfigurationManager.AppSettings["SMS_USR"].ToString();
            pwd = ConfigurationManager.AppSettings["SMS_PWD"].ToString();
            template_id = ConfigurationManager.AppSettings["template_id"].ToString();
           
        }

        public string generatePassword()
        {
            int lenthofpass = 6;
            string allowedChars = "";
            allowedChars = "1,2,3,4,5,6,7,8,9,0";
            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);
            string passwordString = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < lenthofpass; i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                passwordString += temp;
            }
            return passwordString;

        }
        public string OtpMessage()
        {
            string text = "";
            text = string.Format(@"Commercial Taxes Department, Karnataka. Mobile verification pwd: {0}", generatePassword());
            return text;
        }

        public void SMSSEND_V2()
        {
            try
            {
                string smsto = "8088030920";
                
                string r3bnonfilermsg = ConfigurationManager.AppSettings["R3BNONFILER_MSG"].ToString();
                string msg = string.Format(r3bnonfilermsg, "10","ABC pvt ltd", "29070104588", "Sampath", "6789678967","03-03-2021");
                int srno = 0;
                //template_id = "";
                NicTestSms.Service1SoapClient clnt = new NicTestSms.Service1SoapClient();
                 
                bool success = clnt.SMSsend_V2(appid, pwd, smsto, msg, template_id,srno);
                if(success)
                {
                    Console.Write("success");
                }
                else
                {
                    Console.Write("failure");
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine("error");
                Console.WriteLine(ex.Message);
            }


        }

        public void SMSSEND_V5()
        {
            try
            {
                string smsto = ConfigurationManager.AppSettings["mobile_no"].ToString();

                string r3bnonfilermsg = ConfigurationManager.AppSettings["R3BNONFILER_MSG"].ToString();
                string msg = string.Format("74386 SMS sent, out of total 74386 on date 28-07-2021 to einvoice taxpayers.  NIC-GSTN");
                int srno = Convert.ToInt32(ConfigurationManager.AppSettings["sr_no"].ToString());
                //template_id = "";
                ServiceReference1.Service1SoapClient client = new ServiceReference1.Service1SoapClient();

                bool success = client.SMSsend_V2(appid, pwd, smsto, msg, template_id, srno);
                if (success)
                {
                    Console.Write("success");
                }
                else
                {
                    Console.Write("failure");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("error");
                Console.WriteLine(ex.Message);
            }
        }
        }
}
