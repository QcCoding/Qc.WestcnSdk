using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

namespace Qc.WestcnSdk
{
    public static class BuilderExtensions
    {
        public static IApplicationBuilder UseWestcnSdk(this IApplicationBuilder app, Func<WestcnConfig> configHandler)
        {
            return app;
        }
    }
}
