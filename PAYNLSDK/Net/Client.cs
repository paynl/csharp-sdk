using PAYNLSDK.Net.ProxyConfigurationInjector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using PAYNLSDK.API;
using PAYNLSDK.Exceptions;
using Newtonsoft.Json;

namespace PAYNLSDK.Net
{
    /// <inheritdoc />
    public class Client : IClient
    {
        private readonly IProxyConfigurationInjector _proxyConfigurationInjector;
        private readonly IPayNlConfiguration _securityConfiguration;

        /// <inheritdoc />
        public Client(string apiToken, string serviceId, IProxyConfigurationInjector proxyConfigurationInjector = null)
        {
            _proxyConfigurationInjector = proxyConfigurationInjector;
            _securityConfiguration = new PayNlConfiguration()
            {
                ApiToken = apiToken,
                ServiceId = serviceId
            };
        }

        /// <inheritdoc />
        public Client(IPayNlConfiguration securityConfiguration, IProxyConfigurationInjector proxyConfigurationInjector = null)
        {
            _securityConfiguration = securityConfiguration;
            _proxyConfigurationInjector = proxyConfigurationInjector;
        }

        /// <summary>
        /// PAYNL Endpoint
        /// </summary>
        private const string Endpoint = "https://rest-api.pay.nl";
        
        /// <summary>
        /// Client version
        /// </summary>
        public string ClientVersion => "1.1.0.0";

        /// <summary>
        /// User agent
        /// </summary>
        public string UserAgent => $"PAYNL/SDK/{ClientVersion} DotNet/{Environment.Version.Major}";

        /// <summary>
        /// Performs an actual request
        /// </summary>
        /// <param name="request">Specific request implementation to perform</param>
        /// <returns>raw response string</returns>
        public string PerformRequest(RequestBase request)
        {
            HttpWebRequest httprequest = PrepareRequest(request.Url, "POST");
            string rawResponse = PerformRoundTrip2(httprequest, HttpStatusCode.OK, () =>
            {
                using (var requestWriter = new StreamWriter(httprequest.GetRequestStream()))
                {
                    //string serializedResource = resource.Serialize();
                    string serializedResource = request.ToQueryString();
                    requestWriter.Write(serializedResource);
                }
            }
            );
            request.RawResponse = rawResponse;
            return rawResponse;
        }

        /// <summary>
        /// Prepares a request
        /// </summary>
        /// <param name="requestUriString">URL to call</param>
        /// <param name="method">Request Method (get, post, delete, put)</param>
        /// <returns></returns>
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

            if (null != _proxyConfigurationInjector)
            {
                request.Proxy = _proxyConfigurationInjector.InjectProxyConfiguration(request.Proxy, uri);
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
                    if (statusCode == expectedHttpStatusCode)
                    {
                        Stream responseStream = response.GetResponseStream();
                        Encoding encoding = GetEncoding(response);

                        using (var responseReader = new StreamReader(responseStream, encoding))
                        {
                            return responseReader.ReadToEnd();
                        }
                    }
                    throw new ErrorException(String.Format("Unexpected status code {0}", statusCode));
                }
            }
            catch (WebException e)
            {
                throw ErrorExceptionFromWebException(e);
            }
            catch (Exception e)
            {
                throw new ErrorException(String.Format("Unhandled exception {0}", e), e);
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
        /// <returns>ErrorException</returns>
        private ErrorException ErrorExceptionFromWebException(WebException e)
        {
            var httpWebResponse = e.Response as HttpWebResponse;
            if (null == httpWebResponse)
            {
                // some kind of network error: didn't even make a connection
                return new ErrorException(e.Message, e);
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

                            ErrorException errorException = new ErrorException(errMessage, e);
                            if (errorException != null)
                            {
                                return errorException;
                            }
                        }
                        catch (Exception ex1)
                        {
                            return new ErrorException(String.Format("Unknown error for {0}", statusCode), e);
                        }
                        return new ErrorException(String.Format("Unknown error for {0}", statusCode), e);
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
                    return new ErrorException("Something went wrong on our end, please try again", e);
                default:
                    return new ErrorException(String.Format("Unhandled status code {0}", statusCode), e);
            }
        }

    }
}
