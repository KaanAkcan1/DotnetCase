using DotnetCase.Business.Interfaces;
using DotnetCase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCase.Business.Strategies
{    
    public class ExecuteOperationActivityStrategy : IActivityStrategy
    {
        public void Handle(Activity activity)
        {
            activity.Description = "ExecuteOperationActivity : " + activity.Description;
        }
    }
}
