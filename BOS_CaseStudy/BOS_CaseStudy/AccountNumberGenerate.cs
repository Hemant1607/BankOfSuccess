using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS_CaseStudy
{
    class AccountNumberGenerate
    {
        //public static int AccNo = 1000;
        public static int AccountNo()
        {
            StreamReader reader = null;
            StreamWriter writer = null;
            int number;
            try
            {
                reader = new StreamReader("number.txt");
                number = int.Parse(reader.ReadLine());
                reader.Close();
                writer = new StreamWriter("number.txt");
                writer.WriteLine(++number);
                //writer.Close();
            }
            finally
            {
                reader.Close();
                writer.Close();

            }
            //int number = AccNo;
            //AccNo += 1;
            return number;


        }
        
    }
}
