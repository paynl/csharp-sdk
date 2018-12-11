using Newtonsoft.Json;
using PAYNLSDK.API;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Net.ProxyConfigurationInjector;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Text;

namespace PAYNLSDK.Net
{
    /// <inheritdoc />
    ///<summary>
    /// This is the default client to be used by the PayNl function calls
    /// </summary>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class Client : IClient
    {
        /// <summary>
        /// If the client needs to work with a proxy, inject it here
        /// </summary>
        protected readonly IProxyConfigurationInjector ProxyConfigurationInjector;
        /// <summary>
        /// The PayNL configuration
        /// </summary>
        protected readonly IPayNlConfiguration SecurityConfiguration;

        /// <inheritdoc />
        [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
        public Client(IPayNlConfiguration securityConfiguration, IProxyConfigurationInjector proxyConfigurationInjector = null)
        {
            SecurityConfiguration = securityConfiguration;
            ProxyConfigurationInjector = proxyConfigurationInjector;
        }

        private const string Endpoint = "https://rest-api.pay.nl";

        /// <inheritdoc />
        public string ClientVersion => "1.1.0.0";

        /// <inheritdoc />
        public string UserAgent => $"PAYNL/SDK/{ClientVersion} DotNet/{Environment.Version.Major}";

        /// <summary>
        /// Performs an actual request
        /// </summary>
        /// <param name="request">Specific request implementation to perform</param>
        /// <returns>raw response string</returns>
        public string PerformRequest(RequestBase request)
        {
            var webRequest = PrepareRequest(request.Url, "POST");
            var rawResponse = PerformRoundTrip2(webRequest, HttpStatusCode.OK, () =>
                {
                    using (var requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        //string serializedResource = resource.Serialize();
                        string serializedResource = ToQueryString(request);
                        requestWriter.Write(serializedResource);
                    }
                }
            );
            request.RawResponse = rawResponse;
            return rawResponse;


            //var webClient = new WebClient();
            //// we are not using the client.Credentials for the reason stated here: https://stackoverflow.com/a/26016919/97615
            ////string credentials = Convert.ToBase64String(
            ////    Encoding.ASCII.GetBytes("token:" + _securityConfiguration.ApiToken));
            ////webClient.Headers[HttpRequestHeader.Authorization] = $"Basic {credentials}";
            //webClient.Credentials = new NetworkCredential("token", _securityConfiguration.ApiToken);
            //webClient.Headers[HttpRequestHeader.UserAgent] = this.UserAgent;
            //webClient.QueryString = GetParameters(request);
            //webClient.BaseAddress = Endpoint;

            //// download data
            //var rawResponse = webClient.DownloadString(request.Url);

            return rawResponse;
        }

        /// <summary>
        /// Returns a NameValueCollection of all parameters used for this call.
        /// </summary>
        /// <returns>Name Value collection of parameters</returns>
        private NameValueCollection GetParameters(RequestBase request)
        {
            var nvc = request.GetParameters();
            if (request.RequiresApiToken)
            {
                ParameterValidator.IsNotEmpty(SecurityConfiguration.ApiToken, nameof(SecurityConfiguration.ApiToken));
                nvc.Add("token", SecurityConfiguration.ApiToken);
            }
            if (request.RequiresServiceId)
            {
                ParameterValidator.IsNotEmpty(SecurityConfiguration.ServiceId, nameof(SecurityConfiguration.ServiceId));
                nvc.Add("serviceId", SecurityConfiguration.ServiceId);
            }

            return nvc;
        }

        /// <summary>
        /// Transform NameValueCollection to a querystring
        /// </summary>
        /// <returns>querystring ready to be appended to the url</returns>
        private string ToQueryString(RequestBase request)
        {
            var nvc = GetParameters(request);
            if (nvc.Count == 0)
            {
                return "";
            }

            var sb = new StringBuilder();
            // TODO: add "?" if GET?

            var first = true;

            foreach (var key in nvc.AllKeys)
            {
                var values = nvc.GetValues(key);
                if (values == null)
                {
                    // don't add empty parameters
                    continue;
                }

                foreach (var value in values)
                {
                    if (!first)
                    {
                        sb.Append("&");
                    }

                    sb.AppendFormat("{0}={1}", Uri.EscapeDataString(key), Uri.EscapeDataString(value));

                    first = false;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Prepares a request
        /// </summary>
        /// <param name="requestUriString">URL to call</param>
        /// <param name="method">Request Method (get, post, delete, put)</param>
        /// <returns>A new WebRequest</returns>
        private HttpWebRequest PrepareRequest(string requestUriString, string method)
        {
            var uriString = $"{Endpoint}/{requestUriString}";
            var uri = new Uri(uriString);
            var request = WebRequest.Create(uri) as HttpWebRequest;
            request.UserAgent = UserAgent;
            const string applicationJsonContentType = "application/json"; // http://tools.ietf.org/html/rfc4627
            const string wwwUrlContentType = "application/x-www-form-urlencoded"; // http://tools.ietf.org/html/rfc4627
            request.Accept = applicationJsonContentType;
            //request.ContentType = ApplicationJsonContentType;
            request.ContentType = wwwUrlContentType;
            request.Method = method;

            if (null != ProxyConfigurationInjector)
            {
                request.Proxy = ProxyConfigurationInjector.InjectProxyConfiguration(request.Proxy, uri);
            }
            return request;
        }

        /// <summary>
        /// Performs the actual HTTP Request
        /// </summary>
        /// <param name="request">the http request</param>
        /// <param name="expectedHttpStatusCode">expected http status code</param>
        /// <param name="requestAction">Any action that can be executed before actually performing the http request</param>
        /// <returns>raw response</returns>
        private string PerformRoundTrip2(HttpWebRequest request, HttpStatusCode expectedHttpStatusCode, Action requestAction)
        {
            try
            {
                requestAction();

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    var statusCode = (HttpStatusCode)response.StatusCode;
                    if (statusCode != expectedHttpStatusCode)
                    {
                        throw new PayNlException(string.Format("Unexpected status code {0}", statusCode));
                    }

                    Stream responseStream = response.GetResponseStream();
                    Encoding encoding = GetEncoding(response);

                    using (var responseReader = new StreamReader(responseStream, encoding))
                    {
                        return responseReader.ReadToEnd();
                    }
                }
            }
            catch (WebException e)
            {
                throw ErrorExceptionFromWebException(e);
            }
            catch (Exception e)
            {
                throw new PayNlException($"Unhandled exception {e.Message}", e);
            }
        }

        /// <summary>
        /// Get the Encoding
        /// </summary>
        /// <param name="response">http response</param>
        /// <returns>Encoding</returns>
        private static Encoding GetEncoding(HttpWebResponse response)
        {
            // TODO: Make this conditional on the encoding of the response.
            Encoding encode = Encoding.UTF8; // GetEncoding("utf-8"); // Encoding.GetEncoding(response.CharacterSet);
            return encode;
        }

        /// <summary>
        /// Build an error exception from a Web Exception
        /// </summary>
        /// <param name="e">web exception</param>
        /// <returns>PayNlException</returns>
        private PayNlException ErrorExceptionFromWebException(WebException e)
        {
            var httpWebResponse = e.Response as HttpWebResponse;
            if (null == httpWebResponse)
            {
                // some kind of network error: didn't even make a connection
                return new PayNlException(e.Message, e);
            }

            var statusCode = (HttpStatusCode)httpWebResponse.StatusCode;
            switch (statusCode)
            {
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.MethodNotAllowed:
                case HttpStatusCode.UnprocessableEntity:
                case HttpStatusCode.BadRequest:
                    using (var responseReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        string rawResponse = responseReader.ReadToEnd();
                        // Try JSON parsing.
                        try
                        {
                            Dictionary<string, string> errors = JsonConvert.DeserializeObject<Dictionary<string, string>>(rawResponse);
                            string errMessage = "";
                            if (errors.ContainsKey("error"))
                            {
                                errMessage = errors["error"];
                            }
                            else if (errors.ContainsKey("message"))
                            {
                                errMessage = errors["message"];
                            }

                            return new PayNlException(errMessage, e);
                        }
                        catch (Exception ex1)
                        {
                            return new PayNlException(string.Format("Unknown error for {0}", statusCode), ex1);
                        }
                    }
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.NotImplemented:
                case HttpStatusCode.BadGateway:
                case HttpStatusCode.ServiceUnavailable:
                case HttpStatusCode.GatewayTimeout:
                case HttpStatusCode.HttpVersionNotSupported:
                case HttpStatusCode.VariantAlsoNegotiates:
                case HttpStatusCode.InsufficientStorage:
                case HttpStatusCode.LoopDetected:
                case HttpStatusCode.BandwidthLimitExceeded:
                case HttpStatusCode.NotExtended:
                case HttpStatusCode.NetworkAuthenticationRequired:
                case HttpStatusCode.NetworkReadTimeoutError:
                case HttpStatusCode.NetworkConnectTimeoutError:
                    return new PayNlException("Something went wrong on our end, please try again", e);
                default:
                    return new PayNlException(string.Format("Unhandled status code {0}", statusCode), e);
            }
        }

    }
}
