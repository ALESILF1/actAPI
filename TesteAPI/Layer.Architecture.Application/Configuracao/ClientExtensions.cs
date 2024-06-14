using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace Layer.Architeture.Configuracao
{
    public partial class ApplicationAuthenticationClient
    {
        void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
        {
            settings.ContractResolver = new SafeContractResolver();
        }

        private class SafeContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var jsonProp = base.CreateProperty(member, memberSerialization);
                jsonProp.Required = Required.Default;
                return jsonProp;
            }
        }
    }

    public partial class OpenIdConfigurationClient
    {
        void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
        {
            settings.ContractResolver = new SafeContractResolver();
        }

        class SafeContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var jsonProp = base.CreateProperty(member, memberSerialization);
                jsonProp.Required = Required.Default;
                return jsonProp;
            }
        }
    }
}
