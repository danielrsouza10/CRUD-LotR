using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Cod3rsGrowth.Web.ExceptionHandler
{
    public static class SerializerSettings
    {
        public static readonly JsonSerializerSettings JsonSerializerSettings;

        static SerializerSettings()
        {
            JsonSerializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented, // Indented para JSON "bonito"
                ContractResolver = new CamelCasePropertyNamesContractResolver(), // Propriedades em camelCase
                NullValueHandling = NullValueHandling.Ignore, // Ignorar propriedades nulas
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore // Ignorar referências circulares
            };
        }
    }

}
