using DotnetCase.Business.Interfaces;
using DotnetCase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCase.Business.Strategies
{
    public class UserLoginActivityStrategy : IActivityStrategy
    {
        public void Handle(Activity activity)
        {
            activity.Description = "LoginActivity : " + activity.Description;
        }
    }
}
