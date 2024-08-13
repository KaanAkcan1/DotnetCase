using DotnetCase.Data.Models;

namespace DotnetCase.Business.Interfaces
{
    public interface IActivityStrategy
    {
        void Handle(Activity activity);
    }
}
