using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.WebUI.ExtensionMethod
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string jsonData = JsonConvert.SerializeObject(value);
            session.SetString(key,jsonData);
        }

        public static D GetObject<D>(this ISession session,string key) where D : class
        {
            string jsonData = session.GetString(key);

            if (String.IsNullOrEmpty(jsonData))
            {
                return null;
            }
            else
            {
                D data = JsonConvert.DeserializeObject<D>(jsonData);
                return data;
            }
        }
    }
}
