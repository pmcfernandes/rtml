using System.Web.Script.Serialization;

namespace System
{
    public static class ObjectExtensions
    {
        public static object Objectify<T>(this String data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(data);
        }
    }
}
