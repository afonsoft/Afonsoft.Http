using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Afonsoft.Http
{
    /// <summary>
    /// Url Query Paramenter
    /// </summary>
    public class Parameters : Dictionary<string, string>
    {
        /// <summary>
        /// Parameter
        /// </summary>
        protected internal Parameters()
        {
        }

        /// <summary>
        /// Initializes a new Param map with an initial key/value pair.
        /// 
        /// <pre>
        ///   ("/foo/bar", PHttpParameterarams.with("first_name", "John"));
        /// </pre>
        /// </summary>
        /// <param name="key"> the key for the parameter to send to the API </param>
        /// <param name="value"> the value for the given key </param>
        /// <returns> the Param object, allowing for convenient chaining </returns>
        public static Parameters With(string key, string value)
        {
            return (new Parameters()).And(key, value);
        }

        /// <summary>
        /// Adds another key/value pair to the Params map. Automatically
        /// converts all values to strings.
        /// 
        /// <pre>
        ///   ("/foo/bar", HttpParameter.with("first_name", "John").and("last_name", "Smith"));
        /// </pre>
        /// </summary>
        /// <param name="key"> the key for the parameter to send to the API </param>
        /// <param name="value"> the value for the given key </param>
        /// <returns> the Param object, allowing for convenient chaining </returns>
        public virtual Parameters And(string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
                value = "";
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                this[key] = value.ToString().Trim();
            return this;
        }

        /// <summary>
        /// Converts params into a HTTP query string.
        /// </summary>
        /// <returns></returns>
        protected internal virtual string ToQueryString()
        {
            StringBuilder query = new StringBuilder();
            bool first = true;
            foreach (KeyValuePair<string, string> entry in this)
            {
                if (!first)
                {
                    query.Append("&");
                }
                first = false;
                try
                {
                    query.Append(HttpUtility.UrlEncode(entry.Key));
                    query.Append("=");
                    query.Append(HttpUtility.UrlEncode(entry.Value));
                }
                catch (Exception)
                {
                    // no need to anything
                }
            }

            return query.ToString();
        }

        /// <summary>
        /// Converts params into a HTTP query string.
        /// </summary>
        public override string ToString()
        {
            return ToQueryString();
        }
    }


}
