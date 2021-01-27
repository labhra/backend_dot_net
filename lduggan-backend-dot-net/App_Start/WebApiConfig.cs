using System;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNetCore.Authorization;

namespace lduggan_backend_dot_net.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new System.Web.Http.AuthorizeAttribute());
        }
    }
}
