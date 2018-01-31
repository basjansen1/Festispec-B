using Festispec.Domain;
using Festispec.Routes;

namespace Festispec.State
{
    public interface IState
    {
        Route CurrrentRoute { get; set; }
        
        Employee CurrentUser { get; set; }

        bool IsOnline { get; }
    }
}
