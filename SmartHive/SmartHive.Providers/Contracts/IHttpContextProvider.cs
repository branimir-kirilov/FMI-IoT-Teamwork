using Microsoft.Owin;
using System.Security.Principal;
using System.Web;

namespace SmartHive.Providers.Contracts
{
    public interface IHttpContextProvider
    {
        HttpContext CurrentHttpContext { get; }

        IOwinContext CurrentOwinContext { get; }

        IIdentity CurrentIdentity { get; }
        TManager GetUserManager<TManager>();
    }
}
