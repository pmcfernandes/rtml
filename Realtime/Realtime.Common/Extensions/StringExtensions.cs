using System.Web.Script.Serialization;

namespace System
{
    public static class StringExtensions
    {
        public static string Stringfy(this Object data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(data);
        }
    }
}
