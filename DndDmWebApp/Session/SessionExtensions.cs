using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DndDmWebApp.Session
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
                                  JsonConvert.DeserializeObject<T>(value);
        }
    }

    //public static class SessionVariables
    //{
    //    public static readonly string CurrentGame = "CurrentGame";
    //}
}
