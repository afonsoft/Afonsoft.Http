using System;
using System.Collections.Generic;
using System.Text;

namespace Afonsoft.Http
{
    /// <summary>
    /// Url Query Paramenter
    /// </summary>
    public class HttpParameter
    {
        /// <summary>
        /// Parameter
        /// </summary>
        public HttpParameter() { }

        /// <summary>
        /// Parameter
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="value">Value</param>
        public HttpParameter(string name, string value)
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
