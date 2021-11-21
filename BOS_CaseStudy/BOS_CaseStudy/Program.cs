using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS_CaseStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount s1 = new SavingsAccount { Name = "Saving1", dateOfBirth = DateTime.Parse("22/01/2000"), phoneNo = "23455355" };
            SavingsAccount s2 = new SavingsAccount { Name = "Saving2", dateOfBirth = DateTime.Parse("20/11/2002"), phoneNo = "297785355" };

            try
            {
                s1.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                s2.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

           
            s1.Deposit(200000);
            s1.pin = "1234";
            Console.WriteLine(s1.accNo);
            Console.WriteLine(s2.accNo);
            s1.privelage = Account.Privelage.PREMIUM;
            //s1.Close();
            //s2.Close();
            Transfer t1 = new Transfer { Amount = 20000, FromAccount = s1, ToAccount = s2, userGivenPin = "1234" };

            try
            {
                t1.MakeTransaction();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
