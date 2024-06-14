using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Layer.Architecture.Helper.Extension
{
    public static class ExtensaoString
    {
        static public string EncodeToBase64(this string texto)
        {
            try
            {
                byte[] textoAsBytes = Encoding.ASCII.GetBytes(texto);
                string resultado = System.Convert.ToBase64String(textoAsBytes);
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        static public string ToJsonFormat(this string text)
        {
            if (text.Trim().Substring(0, 1).IndexOfAny(new[] { '[', '{' }) != 0)
            {
                return text;
            }

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(text);
            return JsonSerializer.Serialize(jsonElement, options);
        }

        static public string SemFormatacaoCPF (this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }
            var str = Regex.Replace(text, "[^0-9]", string.Empty, RegexOptions.None, TimeSpan.FromSeconds(1.5));
            return str;
        }
    }
}
