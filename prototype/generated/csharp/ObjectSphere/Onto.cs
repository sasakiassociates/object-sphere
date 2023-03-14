using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sasaki.Objects
{

  public abstract class Onto
  {
    public readonly bool isOnto = true;
    public static readonly string[] __internals = new[] {"__internals", "isOnto"};

    Dictionary<string, object> _objects = new Dictionary<string, object>();

    public IEnumerable<object> children
    {
      get
      {
        var data = new List<object>();
        foreach(var kvp in _objects)
        {
          if(!__internals.Any(x => x.Equals(kvp.Key))) data.Add(kvp.Value);

        }
        return data;

      }
    }

    public TObj Get<TObj>(string name)
    {
      var obj = this[name];

      if(obj is TObj casted)
      {
        return casted;
      }

      return default;
    }

    public object this[string key]
    {
      get
      {
        if(_objects.ContainsKey(key)) return _objects[key];

        var prop = GetType().GetProperty(key);

        return prop == null ? null : prop.GetValue(this);
      }
      set
      {

        if(_objects.ContainsKey(key))
        {
          _objects[key] = value;
          return;
        }

        var prop = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(p => p.Name == key);

        if(prop == null)
        {
          _objects[key] = value;
          return;
        }

        prop.SetValue(this, value);

      }
    }
  }

}
