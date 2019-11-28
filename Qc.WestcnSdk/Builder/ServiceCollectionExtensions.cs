using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.WestcnSdk
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加西部数码接口SDK，注入默认实现的DefaultWestcnSdkHook
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddWestcnSdk(this IServiceCollection services, Action<WestcnConfig> optionsAction)
        {
            services.AddWestcnSdk<DefaultWestcnSdkHook>(optionsAction);

            return services;
        }
        /// <summary>
        /// 添加西部数码接口SDK，可注入自定义的IWestcnSdkHook
        /// </summary>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddWestcnSdk<T>(this IServiceCollection services, Action<WestcnConfig> optionsAction = null) where T : class, IWestcnSdkHook
        {
            if (optionsAction != null)
            {
                services.Configure(optionsAction);
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            services.AddScoped<IWestcnSdkHook, T>();
            services.AddScoped<WestcnDomainService, WestcnDomainService>();
            services.AddHttpClient();
            return services;
        }
    }
}
