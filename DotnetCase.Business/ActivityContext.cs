using DotnetCase.Business.Interfaces;
using DotnetCase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCase.Business
{
    public class ActivityContext
    {
        private readonly IActivityStrategy _strategy;

        public ActivityContext(IActivityStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ApplyStrategy(Activity activity)
        {
            _strategy.Handle(activity);
        }
    }
}
