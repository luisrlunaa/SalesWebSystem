using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SalesWebSystem.Application.Utilities
{
    public static class SessionExtensions
    {

        /// <summary>
        /// Set Name the session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.Set<string>(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// Get value the session for name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.Get<string>(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
