using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS_CaseStudy
{
    public class NotEnoughBalanceException:ApplicationException
    {
        public NotEnoughBalanceException(string msg=null,Exception InnerException=null):base(msg,InnerException)
        {

        }
    }
}
