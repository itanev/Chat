using System.Web.Http;
using Thinktecture.IdentityModel.Http.Cors.WebApi;

namespace Chat.Services.App_Start
{
    public class CorsConfig
{
    public static void RegisterCors(HttpConfiguration httpConfig)
    {
        WebApiCorsConfiguration corsConfig = new WebApiCorsConfiguration();
 
        // this adds the CorsMessageHandler to the HttpConfiguration’s
        // MessageHandlers collection
        corsConfig.RegisterGlobal(httpConfig);
       
        corsConfig
            .ForResources("Users")
            .ForAllOrigins()
            .AllowAll();

        corsConfig
            .ForResources("Dropbox")
            .ForAllOrigins()
            .AllowAll();
    }
}
}