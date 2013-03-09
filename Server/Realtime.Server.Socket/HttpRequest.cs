using System.Collections.Generic;

namespace Rtml.Server
{
    public class HttpRequest
    {
        public HttpRequest()
        {
            this.Headers = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Headers
        {
            get;
            private set;
        }

        public string Method
        {
            get;
            set;
        }

        public string Route
        {
            get;
            set;
        }

        public string Body
        {
            get;
            set;
        }

        public byte[] Bytes
        {
            get;
            set;
        }

        public string this[string name]
        {
            get
            {
                string value; this.Headers.TryGetValue(name, out value);
                return value;
            }
        }
    }
}
