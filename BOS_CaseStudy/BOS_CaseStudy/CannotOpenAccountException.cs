using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS_CaseStudy
{
    public class CannotOpenAccountException:ApplicationException
    {
        public CannotOpenAccountException(string msg=null,Exception innerException = null) : base(msg, innerException)
        {

        }
    }
}
