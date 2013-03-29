using System.Web.Script.Serialization;

namespace System
{
    public static class StringExtensions
    {
        /// <summary>
        /// Stringfies the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string Stringfy(this Object data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(data);
        }
    }
}
