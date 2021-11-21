using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS_CaseStudy
{
    public class SavingsAccount:Account
    {
        public DateTime dateOfBirth { get; set; }
        public string Gender { get; set; }
        public string phoneNo { get; set; }

        public override bool Open()
        {
            //throw new NotImplementedException();
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (age < 18)
                throw new CannotOpenAccountException("Cannot open account as age is less than 18");
            if (age == 18)
            {
                if(today.Month<dateOfBirth.Month)
                    throw new CannotOpenAccountException("Cannot open account as age is less than 18");
                else if (today.Month == dateOfBirth.Month)
                {
                    if(today.Day<dateOfBirth.Day)
                        throw new CannotOpenAccountException("Cannot open account as age is less than 18");
                }
            }

            IsActive = true;
            Console.WriteLine("Account opened successfully");


            return true;
        }
    }
}
