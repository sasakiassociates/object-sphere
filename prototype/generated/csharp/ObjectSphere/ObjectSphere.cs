using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sasaki.Objects
{

  public static class ObjectSphere
  {
    public static DefaultContractResolver resolver => new DefaultContractResolver()
    {
      NamingStrategy = new SnakeCaseNamingStrategy
      {
        ProcessDictionaryKeys = true,
        OverrideSpecifiedNames = true,
        ProcessExtensionDataNames = false
      },
    };

    public static JsonSerializerSettings settings => new JsonSerializerSettings()
    {
      ContractResolver = resolver,
      Formatting = Formatting.Indented,
      TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
    };

    public static TOn Deserialize<TOn>(string obj) where TOn : Onto
    {
      return JsonConvert.DeserializeObject<TOn>(obj);
    }

    public static string Serialize<TOn>(TOn obj) where TOn : Onto
    {
      return JsonConvert.SerializeObject(obj, new JsonSerializerSettings(settings));
    }
  }

}
