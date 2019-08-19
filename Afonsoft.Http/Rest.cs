using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Afonsoft.Http
{/// <summary>
 /// HttpMethod
 /// </summary>
    public enum HttpMethod
    {
        /// <summary>
        /// Method GET
        /// </summary>
        GET,
        /// <summary>
        /// Method PUT
        /// </summary>
        PUT,
        /// <summary>
        /// Method POST
        /// </summary>
        POST,
        /// <summary>
        /// Method DELETE
        /// </summary>
        DELETE
    }

    /// <summary>
    /// Classe Http para trabalhar com REST
    /// </summary>
    /// <c>
    /// Avianca.Library.Http.Rest request = new Avianca.Library.Http.Rest("https://api.afonsoft.com.br");
    ///            request.AddParameter("username", "anogueira");
    ///            request.AddParameter("password", "*****");
    ///            var tokenRequest = request.HttpPost("/API/Users/Login");
    ///            if (tokenRequest != null)
    ///            {
    ///                string token = tokenRequest.Token;
    ///                request.AddHeader("Token", tokenRequest.Authorization.Token.Value);
    ///                var userInfo = request.HttpGet("/API/Users/Info");
    ///                if (userInfo != null)
    ///                {
    ///                }
    ///            }
    /// </c>
    public class Rest
    {
        /// <summary>
        /// Classe Http para trabalhar com REST
        /// </summary>
        /// <c>
        /// Avianca.Library.Http.Rest request = new Avianca.Library.Http.Rest("https://api.afonsoft.com.br");
        ///            request.AddParameter("username", "anogueira");
        ///            request.AddParameter("password", "*****");
        ///            var tokenRequest = request.HttpPost("/API/Users/Login");
        ///            if (tokenRequest != null)
        ///            {
        ///                string token = tokenRequest.Token;
        ///                request.AddHeader("Token", tokenRequest.Authorization.Token.Value);
        ///                var userInfo = request.HttpGet("/API/Users/Info");
        ///                if (userInfo != null)
        ///                {
        ///                }
        ///            }
        /// </c>
        /// <param name="endPoint">https://api.afonsoft.com.br</param>
        public Rest(string endPoint)
        {
            EndPoint = endPoint;
            Account = "";
            Password = "";
        }

        /// <summary>
        /// Classe Http para trabalhar com REST
        /// </summary>
        /// <c>
        /// Avianca.Library.Http.Rest request = new Avianca.Library.Http.Rest("https://api.afonsoft.com.br");
        ///            request.AddParameter("username", "anogueira");
        ///            request.AddParameter("password", "*****");
        ///            var tokenRequest = request.HttpPost("/API/Users/Login");
        ///            if (tokenRequest != null)
        ///            {
        ///                string token = tokenRequest.Token;
        ///                request.AddHeader("Token", tokenRequest.Authorization.Token.Value);
        ///                var userInfo = request.HttpGet("/API/Users/Info");
        ///                if (userInfo != null)
        ///                {
        ///                }
        ///            }
        /// </c>
        public Rest()
        {
            EndPoint = "https://api.afonsoft.com.br";
            Account = "";
            Password = "";
        }

        /// <summary>
        /// Classe Http para trabalhar com REST
        /// </summary>
        /// <c>
        /// Avianca.Library.Http.Rest request = new Avianca.Library.Http.Rest("https://api.afonsoft.com.br");
        ///            request.AddParameter("username", "anogueira");
        ///            request.AddParameter("password", "*****");
        ///            var tokenRequest = request.HttpPost("/API/Users/Login");
        ///            if (tokenRequest != null)
        ///            {
        ///                string token = tokenRequest.Token;
        ///                request.AddHeader("Token", tokenRequest.Authorization.Token.Value);
        ///                var userInfo = request.HttpGet("/API/Users/Info");
        ///                if (userInfo != null)
        ///                {
        ///                }
        ///            }
        /// </c>
        /// <param name="endPoint">https://api.afonsoft.com.br</param>
        /// <param name="account">Account for Basic Authorization</param>
        /// <param name="password">Password for Basic Authorization</param>
        public Rest(string endPoint, string account, string password)
        {
            EndPoint = endPoint;
            Account = account;
            Password = password;
        }

        /// <summary>
        /// Classe Http para trabalhar com REST
        /// </summary>
        /// <param name="account">Account for Basic Authorization</param>
        /// <param name="password">Password for Basic Authorization</param>
        /// <c>
        /// Avianca.Library.Http.Rest request = new Avianca.Library.Http.Rest("https://api.afonsoft.com.br");
        ///            request.AddParameter("username", "anogueira");
        ///            request.AddParameter("password", "*****");
        ///            var tokenRequest = request.HttpPost("/API/Users/Login");
        ///            if (tokenRequest != null)
        ///            {
        ///                string token = tokenRequest.Token;
        ///                request.AddHeader("Token", tokenRequest.Authorization.Token.Value);
        ///                var userInfo = request.HttpGet("/API/Users/Info");
        ///                if (userInfo != null)
        ///                {
        ///                }
        ///            }
        /// </c>
        public Rest(string account, string password)
        {
            EndPoint = "https://api.afonsoft.com.br";
            Account = account;
            Password = password;
        }

        /// <summary>
        /// Encode Default UTF8
        /// </summary>
        public Encoding Encode { get; set; } = Encoding.UTF8;

        private T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// EndPoint => https://api.afonsoft.com.br
        /// </summary>
        public string EndPoint { get; set; }

        /// <summary>
        /// Timeout
        /// <c>
        /// Default: 240000
        /// </c>
        /// </summary>
        public int Timeout { get; set; } = 240000;

        private CookieContainer _cookieContainer = new CookieContainer();

        /// <summary>
        /// CookieContainer
        /// </summary>
        public CookieContainer Cookie
        {
            get => _cookieContainer;
            set => _cookieContainer = value;
        }

        /// <summary>
        /// Account for Basic Authorization
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Password for Basic Authorization
        /// </summary>
        public string Password { get; set; }


        private readonly List<HttpHeader> _headers = new List<HttpHeader>();
        private List<HttpParameter> Parameters = new List<HttpParameter>();

        /// <summary>
        /// Add Headers for all future Request
        /// </summary>
        public void AddHeader(string name, string value)
        {
            _headers.Add(new HttpHeader(name, value));
        }

        /// <summary>
        /// recover all Header
        /// </summary>
        public HttpHeader[] GetHeader()
        {
            return _headers.ToArray();
        }

        /// <summary>
        /// recover Header
        /// </summary>
        public HttpHeader GetHeader(string name)
        {
            return _headers.FirstOrDefault(x => x.Name == name);
        }

        /// <summary>
        /// Add paramenter for a request, after request this list is clean
        /// </summary>
        public void AddParameter(string name, string value)
        {
            Parameters.Add(new HttpParameter(name, value));
        }

        #region HttpGetOrPost and HttpGetOrPostAsync



        /// <summary>
        /// HttpGetOrPostAsync
        /// </summary>
        /// <param name="uri">/API/VALUE</param>
        /// <param name="method">GET, HEAD, POST, PUT, DELETE, TRACE, or OPTIONS.</param>
        /// <param name="headers">headers</param>
        /// <param name="postData">Data to send</param>
        /// <returns>String Json</returns>
        public Task<string> HttpGetOrPostAsync(string uri, HttpMethod method, List<HttpHeader> headers = null, string postData = null)
        {
            return Task.Run(() => HttpGetOrPost(uri, method, headers, postData));
        }

        /// <summary>
        /// HttpGetOrPost
        /// </summary>
        /// <param name="uri">/API/VALUE</param>
        /// <param name="method">GET, HEAD, POST, PUT, DELETE, TRACE, or OPTIONS.</param>
        /// <param name="headers">headers</param>
        /// <param name="postData">Data to send</param>
        /// <returns>String Json</returns>
        public string HttpGetOrPost(string uri, HttpMethod method, List<HttpHeader> headers = null, string postData = null)
        {
            var result = "";
            try
            {
                if (headers == null)
                    headers = _headers;

                if (Parameters != null && Parameters.Count > 0)
                {
                    foreach (HttpParameter paramenter in Parameters)
                    {
                        uri += (uri.IndexOf('?') > 0 ? "&" : "?") + paramenter.Name + "=" + HttpUtility.UrlEncode(paramenter.Value);
                    }
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(EndPoint + uri));

                if (!string.IsNullOrEmpty(Account) && !string.IsNullOrEmpty(Password))
                {
                    request.Credentials = new NetworkCredential(Account, Password);
                    String encoded = Convert.ToBase64String(Encode.GetBytes(Account + ":" + Password));
                    request.Headers.Add("Authorization", "Basic " + encoded);
                }

                if (headers != null && headers.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        if (request.Headers.AllKeys.Count(x => x == header.Name) <= 0)
                        {
                            request.Headers.Add(header.Name, header.Value);
                        }
                    }
                }

                request.KeepAlive = true;
                request.Timeout = Timeout;
                request.AllowAutoRedirect = true;
                request.CookieContainer = _cookieContainer;
                request.Method = method.ToString();
                request.ContentLength = 0;
                request.Accept = "application/json, application/xml, text/html, text/plain";
                request.ServicePoint.Expect100Continue = false;

                if (method == HttpMethod.POST || method == HttpMethod.PUT || method == HttpMethod.DELETE)
                {
                    request.ContentType = "application/json";
                    if (!string.IsNullOrEmpty(postData))
                    {
                        byte[] postDataBytes = Encode.GetBytes(postData);
                        request.ContentLength = postDataBytes.Length;
                        using (var dataStream = request.GetRequestStream())
                        {
                            dataStream.Write(postDataBytes, 0, postDataBytes.Length);
                        }
                    }
                }

                using (var httpWebResponse = request.GetResponse() as HttpWebResponse)
                {
                    if (httpWebResponse != null)
                    {
                        string Charset = httpWebResponse.CharacterSet;
                        Encode = Encoding.GetEncoding(Charset);

                        _cookieContainer.Add(httpWebResponse.Cookies);
                        using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encode, true))
                        {
                            result = streamReader.ReadToEnd().Trim().Replace(Environment.NewLine, "").Replace("\n", "").Replace("\r", "");
                        }
                    }
                }

            }
            catch (WebException wex)
            {

                var response = (HttpWebResponse)wex.Response;
                if (response != null)
                {
                    try
                    {
                        using (var streamReader = new StreamReader(response.GetResponseStream(), Encode, true))
                        {
                            result = streamReader.ReadToEnd().Trim().Replace(Environment.NewLine, "").Replace("\n", "").Replace("\r", "");
                        }
                    }
                    catch (Exception)
                    {
                        result = $"A WebException '{wex.Message}' status '{wex.Status}'";
                        result += $", response: {(int)response.StatusCode} {response.StatusDescription}: {wex.Message}";
                    }
                }
                throw new Exception(result, wex);
            }
            finally
            {
                Parameters = new List<HttpParameter>();
            }
            return result;
        }

        #endregion

        #region HttpPost and HttpGet

        #region POST

        /// <summary>
        /// HttpPost
        /// </summary>
        public string HttpPost(string uri)
        {
            return HttpGetOrPost(uri, HttpMethod.POST);

        }
        /// <summary>
        /// HttpPost
        /// </summary>
        public T HttpPost<T>(string uri)
        {
            return Deserialize<T>(HttpGetOrPost(uri, HttpMethod.POST));
        }
        /// <summary>
        /// HttpPost
        /// </summary>
        public string HttpPost(string uri, string postData)
        {
            return HttpGetOrPost(uri, HttpMethod.POST, null, postData);

        }
        /// <summary>
        /// HttpPost
        /// </summary>
        public T HttpPost<T>(string uri, string postData)
        {
            return Deserialize<T>(HttpGetOrPost(uri, HttpMethod.POST, null, postData));
        }
        /// <summary>
        /// HttpPost
        /// </summary>
        public string HttpPost(string uri, List<HttpHeader> headers, string postData)
        {
            return HttpGetOrPost(uri, HttpMethod.POST, headers, postData);

        }
        /// <summary>
        /// HttpPost
        /// </summary>
        public T HttpPost<T>(string uri, List<HttpHeader> headers, string postData)
        {
            return Deserialize<T>(HttpGetOrPost(uri, HttpMethod.POST, headers, postData));
        }
        /// <summary>
        /// HttpPost
        /// </summary>
        public string HttpPost(string uri, List<HttpHeader> headers)
        {
            return HttpGetOrPost(uri, HttpMethod.POST, headers);
        }
        /// <summary>
        /// HttpPost
        /// </summary>
        public T HttpPost<T>(string uri, List<HttpHeader> headers)
        {
            return Deserialize<T>(HttpGetOrPost(uri, HttpMethod.POST, headers));
        }

        /// <summary>
        /// HttpPostAsync
        /// </summary>
        public Task<string> HttpPostAsync(string uri)
        {
            return HttpGetOrPostAsync(uri, HttpMethod.POST);

        }
        /// <summary>
        /// HttpPostAsync
        /// </summary>
        public async Task<T> HttpPostAsync<T>(string uri)
        {
            return Deserialize<T>(await HttpGetOrPostAsync(uri, HttpMethod.POST));
        }
        /// <summary>
        /// HttpPostAsync
        /// </summary>
        public async Task<string> HttpPostAsync(string uri, string postData)
        {
            return await HttpGetOrPostAsync(uri, HttpMethod.POST, null, postData);

        }
        /// <summary>
        /// HttpPostAsync
        /// </summary>
        public async Task<T> HttpPostAsync<T>(string uri, string postData)
        {
            return Deserialize<T>(await HttpGetOrPostAsync(uri, HttpMethod.POST, null, postData));
        }
        /// <summary>
        /// HttpPostAsync
        /// </summary>

        public Task<string> HttpPostAsync(string uri, List<HttpHeader> headers, string postData)
        {
            return HttpGetOrPostAsync(uri, HttpMethod.POST, headers, postData);

        }

        /// <summary>
        /// HttpPostAsync
        /// </summary>
        public async Task<T> HttpPostAsync<T>(string uri, List<HttpHeader> headers, string postData)
        {
            return Deserialize<T>(await HttpGetOrPostAsync(uri, HttpMethod.POST, headers, postData));
        }
        /// <summary>
        /// HttpPostAsync
        /// </summary>
        public Task<string> HttpPostAsync(string uri, List<HttpHeader> headers)
        {
            return HttpGetOrPostAsync(uri, HttpMethod.POST, headers);

        }
        /// <summary>
        /// HttpPostAsync
        /// </summary>
        public async Task<T> HttpPostAsync<T>(string uri, List<HttpHeader> headers)
        {
            return Deserialize<T>(await HttpGetOrPostAsync(uri, HttpMethod.POST, headers));
        }


        #endregion

        #region GET

        /// <summary>
        /// HttpGet
        /// </summary>
        public string HttpGet(string uri)
        {
            return HttpGetOrPost(uri, HttpMethod.GET);
        }


        /// <summary>
        /// HttpGetAsync
        /// </summary>
        public Task<string> HttpGetAsync(string uri)
        {
            return HttpGetOrPostAsync(uri, HttpMethod.GET);
        }

        /// <summary>
        /// HttpGetAsync
        /// </summary>
        public async Task<T> HttpGetAsync<T>(string uri)
        {
            return Deserialize<T>(await HttpGetOrPostAsync(uri, HttpMethod.GET));
        }

        /// <summary>
        /// HttpGet
        /// </summary>
        public T HttpGet<T>(string uri)
        {
            return Deserialize<T>(HttpGetOrPost(uri, HttpMethod.GET));
        }

        /// <summary>
        /// HttpGet
        /// </summary>
        public T HttpGet<T>(string uri, List<HttpHeader> headers)
        {
            return Deserialize<T>(HttpGetOrPost(uri, HttpMethod.GET, headers));
        }

        /// <summary>
        /// HttpGetAsync
        /// </summary>
        public async Task<T> HttpGetAsync<T>(string uri, List<HttpHeader> headers)
        {
            return Deserialize<T>(await HttpGetOrPostAsync(uri, HttpMethod.GET, headers));
        }


        /// <summary>
        /// HttpGetAsync
        /// </summary>
        public Task<string> HttpGetAsync(string uri, List<HttpHeader> headers)
        {
            return HttpGetOrPostAsync(uri, HttpMethod.GET, headers);
        }

        /// <summary>
        /// HttpGet
        /// </summary>
        public string HttpGet(string uri, List<HttpHeader> headers)
        {
            return HttpGetOrPost(uri, HttpMethod.GET, headers);
        }

        #endregion

        #endregion
    }
}