using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using PAYNLFormsApp.Objects;
using PAYNLSDK;
using PAYNLSDK.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServicesExtension
    {
        /// <summary>
        /// Client version
        /// </summary>
        public static string ClientVersion
        {
            get { return "1.0.0.0"; }
        }

        /// <summary>
        /// User agent
        /// </summary>
        public static string UserAgent
        {
            get { return $"PAYNL/SDK/{ClientVersion} DotNet/"; }
        }

        public static void AddPaynl(this IServiceCollection services, AppSettings settings)
        {
            services.AddLogging();

            var contentType = new MediaTypeWithQualityHeaderValue(settings.ApplicationJsonContentType);

            if (settings.UseProxy)
            {
                services.AddHttpClient(Constants.HttpClientProxy)
                    .ConfigureHttpClient((e) =>
                    {
                        e.BaseAddress = new Uri(settings.BaseAddress);
                        e.DefaultRequestHeaders.TryAddWithoutValidation(Constants.UserAgentHeader, UserAgent);
                        e.DefaultRequestHeaders.Accept.Add(contentType);
                    })
                    .ConfigurePrimaryHttpMessageHandler(() =>
                    {
                        return new HttpClientHandler
                        {
                            Proxy = new WebProxy(settings.ProxyAddress),
                            UseProxy = true
                        };
                    });
            }
            else
            {
                services.AddHttpClient(Constants.HttpClientDefault)
                    .ConfigureHttpClient((e) =>
                    {
                        e.BaseAddress = new Uri(settings.BaseAddress);
                        e.DefaultRequestHeaders.TryAddWithoutValidation(Constants.UserAgentHeader, UserAgent);
                        e.DefaultRequestHeaders.Accept.Add(contentType);
                    });
            }

            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<IUtilityService, UtilityService>();
        }
    }
}
