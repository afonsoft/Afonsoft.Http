using System;
using System.Collections.Generic;
using System.Text;

namespace Afonsoft.Http
{
    public class RestOptions
    {
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

        /// <summary>
        /// Account for Basic Authorization
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Password for Basic Authorization
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Add Headers for all future Request
        /// </summary>
        public HttpHeaderCollection HttpHeaders { get; set; }
    }
}
