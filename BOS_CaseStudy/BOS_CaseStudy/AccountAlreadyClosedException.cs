using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS_CaseStudy
{
    public class AccountAlreadyClosedException:ApplicationException
    {
        public AccountAlreadyClosedException(string msg=null,Exception InnerException=null):base(msg,InnerException)
        {

        }
    }
}
