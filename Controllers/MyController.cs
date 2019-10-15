using System.Web.Mvc;
using System.Web.Routing;

namespace FMVCP.Controllers
{
    public class MyController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            var ip = requestContext.HttpContext.Request.UserHostAddress;
            var response = requestContext.HttpContext.Response;
            response.Write("<h2>Ваш IP-адрес: " + ip + "</h2>");
        }
    }
}