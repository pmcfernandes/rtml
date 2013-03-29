using System.Web.Script.Serialization;

namespace System
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Objectifies the specified data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static object Objectify<T>(this String data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(data);
        }
    }
}
