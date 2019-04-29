using System;

namespace Afonsoft.Http
{
    /// <summary>
    /// Header for request
    /// </summary>
    public class HttpHeader
    {
        /// <summary>
        /// Header
        /// </summary>
        public HttpHeader() { }

        /// <summary>
        /// Header
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="value">Value</param>
        public HttpHeader(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }
    }
}
