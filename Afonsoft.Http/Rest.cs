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
        private static RestOptions Build(Action<RestOptions> action)
        {
            RestOptions opt = new RestOptions();
            action.Invoke(opt);
            return opt;
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
        /// <param name="options"></param>
        public Rest(Action<RestOptions> options)
        {
            RestOptions opt = Build(options);

            EndPoint = opt.EndPoint;
            Account = opt.Account;
            Password = opt.Password;
            Timeout = opt.Timeout;
            _headers = opt.HttpHeaders;
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
            EndPoint = "";
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


        private readonly HttpHeaderCollection _headers = new HttpHeaderCollection();

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


        #region HttpGetOrPost and HttpGetOrPostAsync

        /// <summary>
        /// HttpGetOrPostAsync
        /// </summary>
        /// <param name="uri">/API/VALUE</param>
        /// <param name="method">GET, HEAD, POST, PUT, DELETE, TRACE, or OPTIONS.</param>
        /// <param name="postData">Data to send</param>
        /// <returns>String Json</returns>
        public Task<string> HttpGetOrPostAsync(string uri, HttpMethod method, Parameters parameters, byte[] postData = null)
        {
            return Task.Run(() => HttpGetOrPost(uri, method, parameters, postData));
        }

        /// <summary>
        /// HttpGetOrPost
        /// </summary>
        /// <param name="uri">/API/VALUE</param>
        /// <param name="method">GET, HEAD, POST, PUT, DELETE, TRACE, or OPTIONS.</param>
        /// <param name="headers">headers</param>
        /// <param name="postData">Data to send</param>
        /// <returns>String Json</returns>
        public string HttpGetOrPost(string uri, HttpMethod method, Parameters parameters, byte[] postData = null)
        {
            var result = "";
            try
            {
                if (string.IsNullOrEmpty(uri))
                    throw new ArgumentNullException(nameof(uri), "EndPoint is null");

                if (parameters != null && parameters.Count > 0)
                {
                    uri += (uri.IndexOf('?') > 0 ? "&" : "?") + parameters.ToString();
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(EndPoint + uri));

                if (!string.IsNullOrEmpty(Account) && !string.IsNullOrEmpty(Password))
                {
                    request.Credentials = new NetworkCredential(Account, Password);
                    String encoded = Convert.ToBase64String(Encode.GetBytes(Account + ":" + Password));
                    request.Headers.Add("Authorization", "Basic " + encoded);
                }

                if (_headers != null && _headers.Count > 0)
                {
                    foreach (var header in _headers)
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
                    if (postData != null && postData.Length > 0)
                    {
                        request.ContentLength = postData.Length;
                        using (var dataStream = request.GetRequestStream())
                        {
                            dataStream.Write(postData, 0, postData.Length);
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
                            result = streamReader.ReadToEnd().Trim().Replace(Environment.NewLine, "").Replace("\n", "").Replace("\r", "").Trim();
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
                            result = streamReader.ReadToEnd().Trim().Replace(Environment.NewLine, "").Replace("\n", "").Replace("\r", "").Trim();
                        }

                        if (string.IsNullOrEmpty(result))
                        {
                            result = $"A WebException '{wex.Message}' status '{wex.Status}'";
                            result += $", response: {(int)response.StatusCode} {response.StatusDescription}: {wex.Message}";
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
            return HttpGetOrPost(uri, HttpMethod.POST, null);

        }

        /// <summary>
        /// HttpPost
        /// </summary>
        public string HttpPost(string uri, Parameters parameters)
        {
            return HttpGetOrPost(uri, HttpMethod.POST, parameters);

        }
        /// <summary>
        /// HttpPost
        /// </summary>
        public T HttpPost<T>(string uri)
        {
            return Deserialize<T>(HttpGetOrPost(uri, HttpMethod.POST, null));
        }

        /// <summary>
        /// HttpPost
        /// </summary>
        public T HttpPost<T>(string uri, Parameters parameters)
        {
            return Deserialize<T>(HttpGetOrPost(uri, HttpMethod.POST, parameters));
        }

        /// <summary>
        /// HttpPost
        /// </summary>
        public string HttpPost(string uri, byte[] postData)
        {
            return HttpGetOrPost(uri, HttpMethod.POST, null, postData);

        }

        /// <summary>
        /// HttpPost
        /// </summary>
        public string HttpPost(string uri, string postData)
        {
            return HttpGetOrPost(uri, HttpMethod.POST, null,  Encode.GetBytes(postData));

        }
        /// <summary>
        /// HttpPost
        /// </summary>
        public T HttpPost<T>(string uri, byte[] postData)
        {
            return Deserialize<T>(HttpGetOrPost(uri, HttpMethod.POST, null, postData));
        }
        /// <summary>
        /// HttpPost
        /// </summary>
        public T HttpPost<T>(string uri, string postData)
        {
            return Deserialize<T>(HttpGetOrPost(uri, HttpMethod.POST, null, Encode.GetBytes(postData)));
        }

        /// <summary>
        /// HttpPostAsync
        /// </summary>
        public Task<string> HttpPostAsync(string uri)
        {
            return HttpGetOrPostAsync(uri, HttpMethod.POST, null);

        }
        /// <summary>
        /// HttpPostAsync
        /// </summary>
        public Task<string> HttpPostAsync(string uri, Parameters parameters)
        {
            return HttpGetOrPostAsync(uri, HttpMethod.POST, parameters);

        }
        /// <summary>
        /// HttpPostAsync
        /// </summary>
        public async Task<T> HttpPostAsync<T>(string uri)
        {
            return Deserialize<T>(await HttpGetOrPostAsync(uri, HttpMethod.POST, null));
        }
        /// <summary>
        /// HttpPostAsync
        /// </summary>
        public async Task<T> HttpPostAsync<T>(string uri, Parameters parameters)
        {
            return Deserialize<T>(await HttpGetOrPostAsync(uri, HttpMethod.POST, parameters));
        }
        /// <summary>
        /// HttpPostAsync
        /// </summary>
        public Task<string> HttpPostAsync(string uri, byte[] postData)
        {
            return HttpGetOrPostAsync(uri, HttpMethod.POST, null, postData);

        }
        /// <summary>
        /// HttpPostAsync
        /// </summary>
        public async Task<T> HttpPostAsync<T>(string uri, byte[] postData)
        {
            return Deserialize<T>(await HttpGetOrPostAsync(uri, HttpMethod.POST, null, postData));
        }

        /// <summary>
        /// HttpPostAsync
        /// </summary>
        public Task<string> HttpPostAsync(string uri, string postData)
        {
            return HttpGetOrPostAsync(uri, HttpMethod.POST, null, Encode.GetBytes(postData));

        }
        /// <summary>
        /// HttpPostAsync
        /// </summary>
        public async Task<T> HttpPostAsync<T>(string uri, string postData)
        {
            return Deserialize<T>(await HttpGetOrPostAsync(uri, HttpMethod.POST, null, Encode.GetBytes(postData)));
        }

        #endregion

        #region GET

        /// <summary>
        /// HttpGet
        /// </summary>
        public string HttpGet(string uri)
        {
            return HttpGetOrPost(uri, HttpMethod.GET, null);
        }

        /// <summary>
        /// HttpGet
        /// </summary>
        /// <returns></returns>
        public string HttpGet(string uri, Parameters parameters)
        {
            return HttpGetOrPost(uri, HttpMethod.GET, parameters);
        }


        /// <summary>
        /// HttpGetAsync
        /// </summary>
        public Task<string> HttpGetAsync(string uri)
        {
            return HttpGetOrPostAsync(uri, HttpMethod.GET, null);
        }

        /// <summary>
        /// HttpGetAsync
        /// </summary>
        public Task<string> HttpGetAsync(string uri, Parameters parameters)
        {
            return HttpGetOrPostAsync(uri, HttpMethod.GET, parameters);
        }

        /// <summary>
        /// HttpGetAsync
        /// </summary>
        public async Task<T> HttpGetAsync<T>(string uri)
        {
            return Deserialize<T>(await HttpGetOrPostAsync(uri, HttpMethod.GET, null));
        }

        /// <summary>
        /// HttpGetAsync
        /// </summary>
        public async Task<T> HttpGetAsync<T>(string uri, Parameters parameters)
        {
            return Deserialize<T>(await HttpGetOrPostAsync(uri, HttpMethod.GET, parameters));
        }

        /// <summary>
        /// HttpGet
        /// </summary>
        public T HttpGet<T>(string uri)
        {
            return Deserialize<T>(HttpGetOrPost(uri, HttpMethod.GET, null));
        }

        /// <summary>
        /// HttpGet
        /// </summary>
        public T HttpGet<T>(string uri, Parameters parameters)
        {
            return Deserialize<T>(HttpGetOrPost(uri, HttpMethod.GET, parameters));
        }


        #endregion

        #endregion
    }
}