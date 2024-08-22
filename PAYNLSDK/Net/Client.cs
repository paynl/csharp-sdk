using PAYNLSDK.Net.ProxyConfigurationInjector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using PAYNLSDK.API;
using PAYNLSDK.Exceptions;
using Newtonsoft.Json;
using System.Configuration;
using System.Reflection;
using System.Linq;

namespace PAYNLSDK.Net
{
    public class Client : IClient
    {
        /// <summary>
        /// PAYNL API TOKEN
        /// </summary>
        public string ApiToken
        {
            get;
            private set;
        }

        /// <summary>
        /// PAYNL SERVICE ID
        /// </summary>
        public string ServiceID
        {
            get;
            private set;
        }

        /// <summary>
        /// Proxy injector
        /// </summary>
        public IProxyConfigurationInjector ProxyConfigurationInjector 
        {
            get; private set; 
        }

        /// <summary>
        /// API VERSION
        /// </summary>
        public string ApiVersion
        {
            get;
            private set;
        }

        /// <summary>
        /// Client version
        /// </summary>
        public string ClientVersion
        {
            get { return "1.0.3.0"; }
        }

        /// <summary>
        /// User agent
        /// </summary>
        public string UserAgent
        {
            get { return string.Format("PAYNL/SDK/{0} DotNet/{1}", ClientVersion, ""); }
        }

        /// <summary>
        /// Create a new Service client
        /// </summary>
        /// <param name="apiToken">PAYNL Api Token</param>
        /// <param name="serviceID">PAYNL Service ID</param>
        /// <param name="proxyConfigurationInjector">Proxy Injector</param>
        public Client(string apiToken, string serviceID, IProxyConfigurationInjector proxyConfigurationInjector)
        {
            ApiToken = apiToken;
            ServiceID = serviceID;
            ProxyConfigurationInjector = proxyConfigurationInjector;
        }

        /// <summary>
        /// Create a new Service client
        /// </summary>
        /// <param name="apiToken">PAYNL Api Token</param>
        /// <param name="serviceID">PAYNL Service ID</param>
        public Client(string apiToken, string serviceID)
            : this(apiToken, serviceID, null)
        {
        }

        /// <summary>
        /// Create a new Service client
        /// </summary>
        /// <param name="apiToken">PAYNL Api Token</param>
        public Client(string apiToken)
            : this(apiToken, null, null)
        {
        }

        /// <summary>
        /// create new Client
        /// </summary>
        public Client()
            : this(null, null, null)
        {
        }

        /// <summary>
        /// Performs an actual request
        /// </summary>
        /// <param name="request">Specific request implementation to perform</param>
        /// <returns>raw response string</returns>
        public string PerformRequest(RequestBase request)
        {
            if (request.ToQueryString().Contains("transactionId"))
            {
                string TransactionCore = request.GetParameters().Get("TransactionId").Substring(0,2);
                if (TransactionCore == "51")
                {
                    PAYNLSDK.API.RequestBase.Core = PAYNLSDK.API.RequestBase.Core2;
                }
                else if (TransactionCore == "52")
                {
                    PAYNLSDK.API.RequestBase.Core = PAYNLSDK.API.RequestBase.Core3;
                }
            }

                
            HttpWebRequest httprequest = PrepareRequest(request.Url, "POST", PAYNLSDK.API.RequestBase.Core);
            string rawResponse = PerformRoundTrip2(httprequest, HttpStatusCode.OK, HttpStatusCode.Created, () =>
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
        /// <param name="endpoint">Core to use for request</param>
        /// <returns></returns>
        private HttpWebRequest PrepareRequest(string requestUriString, string method, string endpoint)
        {
            if(String.IsNullOrEmpty(endpoint))
            {
                endpoint = PAYNLSDK.API.RequestBase.Core1;
            }

            if (!requestUriString.Contains("/Transaction/info/") && !requestUriString.Contains("/Transaction/start/"))
            {
                endpoint = PAYNLSDK.API.RequestBase.Core4;
            }

            string uriString = String.Format("{0}/{1}", endpoint, requestUriString);
            var uri = new Uri(uriString);
            var request = WebRequest.Create(uri) as HttpWebRequest;
            request.UserAgent = UserAgent;
            const string ApplicationJsonContentType = "application/json"; // http://tools.ietf.org/html/rfc4627
            const string WWWUrlContentType = "application/x-www-form-urlencoded"; // http://tools.ietf.org/html/rfc4627
            request.Accept = ApplicationJsonContentType;
            //request.ContentType = ApplicationJsonContentType;
            request.ContentType = WWWUrlContentType;
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
        private string PerformRoundTrip2(HttpWebRequest request, HttpStatusCode expectedHttpStatusCode1, HttpStatusCode expectedHttpStatusCode2, Action requestAction)
        {
            try
            {
                requestAction();

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    var statusCode = (HttpStatusCode)response.StatusCode;
                    if (statusCode == expectedHttpStatusCode1 || statusCode == expectedHttpStatusCode2)
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
