using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afonsoft.Http
{
    public class HttpHeaderCollection : ICollection<HttpHeader>, IEnumerable<HttpHeader>
    {
        private IList<HttpHeader> _entries = new List<HttpHeader>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public HttpHeader this[int index] => _entries[index];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public HttpHeader this[string parameter] => _entries.FirstOrDefault(x => x.Name == parameter);

        /// <summary>
        /// Count 
        /// </summary>
        public int Count => _entries.Count;

        /// <summary>
        /// IsReadOnly 
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="item">IActiveDirectory</param>
        public void Add(HttpHeader item)
        {
            _entries.Add(item);
        }

        public void Add(string name, string value)
        {
            _entries.Add(new HttpHeader(name, value));
        }

        /// <summary>
        /// Clear
        /// </summary>
        public void Clear()
        {
            _entries.Clear();
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="item">IActiveDirectory</param>
        /// <returns></returns>
        public bool Contains(HttpHeader item)
        {
            return _entries.Contains(item);
        }

        /// <summary>
        /// CopyTo
        /// </summary>
        /// <param name="array">IActiveDirectory</param>
        /// <param name="arrayIndex">int</param>
        public void CopyTo(HttpHeader[] array, int arrayIndex)
        {
            _entries.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<HttpHeader> GetEnumerator()
        {
            return ((IEnumerable<HttpHeader>)_entries).GetEnumerator();
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="item">IActiveDirectory</param>
        /// <returns></returns>
        public bool Remove(HttpHeader item)
        {
            return _entries.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}