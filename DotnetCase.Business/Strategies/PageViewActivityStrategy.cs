using DotnetCase.Business.Interfaces;
using DotnetCase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCase.Business.Strategies
{
    public class PageViewActivityStrategy : IActivityStrategy
    {
        public void Handle(Activity activity)
        {
            activity.Description = "PageViewActivity : " + activity.Description;
        }
    }
}
