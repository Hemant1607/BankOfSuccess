using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS_CaseStudy
{
    static public class Alert
    {
        public static void Mail(string msg)
        {
            Console.WriteLine("Mail: " + msg);
        }

        public static void SMS(string msg)
        {
            Console.WriteLine("SMS: " + msg);
        }
    }

}
