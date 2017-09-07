using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Welcome.Extensions
{
    public static class SessionExtensions
    {
        public static T Get<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(data);
            }
        }

        public static void Set<T>(this ISession session, string key, T value)
        {
            var data = JsonConvert.SerializeObject(value);
            session.SetString(key, data);
        }
    }
}