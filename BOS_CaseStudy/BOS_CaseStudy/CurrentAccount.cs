using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS_CaseStudy
{
    public class CurrentAccount : Account
    {
        public string companyName { get; set; }
        public string Website { get; set; }
        public string registrationNo { get; set; }

        public override bool Open()
        {
            //throw new NotImplementedException();
            if (registrationNo == null)
                throw new CannotOpenAccountException("Cannot open account as Registration number is null");
            IsActive = true;
            Console.WriteLine("Account opened successfully");
            return true;
        }
    }
}
