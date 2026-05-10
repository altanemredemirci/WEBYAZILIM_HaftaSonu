using System.Text.Json;

namespace _13_State_Management_2.Extensions
{
    public static class SessionExtensions
    {
        //Nesneyi JSON'a çevirip Session'a kaydeder.
        public static void SetObjectAsJson(this ISession session, string key, object value) 
        { 
            session.SetString(key,JsonSerializer.Serialize(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
