using Desafio.Application.ViewModels.CreateUpdate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Desafio.Application.Test
{
    public static class JsonHelper
    {
        public static T Deserialize<T>(string filename)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "json", filename);
            var content = File.ReadAllText(filePath, Encoding.UTF8);
            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

            return JsonSerializer.Deserialize<T>(content, options);
        }

        public static string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize<T>(obj);
        }
    }
}
 