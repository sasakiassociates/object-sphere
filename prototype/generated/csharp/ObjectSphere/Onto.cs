using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sasaki.Objects
{

  public class Onto
  {
    public static readonly string[] __internals = {"__internals", "isOnto"};

    Dictionary<string, object> _objects = new Dictionary<string, object>();

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



    /// <summary>
    /// Recursive search through all objects in the class
    /// </summary>
    /// <param name="name">the key to find</param>
    /// <param name="depth">the max child depth to search</param>
    /// <typeparam name="TObj"></typeparam>
    /// <returns></returns>
    public TObj Get<TObj>(string name, int depth = 10)
    {
      var obj = this[name];

      if(obj is TObj casted) return casted;

      var index = 0;
      foreach(var kvp in _objects)
      {
        var child = Traverse<TObj>(kvp.Value, name, depth, ref index);
        if(child != null) return child;
      }

      return default(TObj);
    }

    static TObj Traverse<TObj>(object item, string name, int depth, ref int index)
    {
      // 0. for each traverse we assume this is a new layer of the 
      index++;
      // 1. check if first try worked 
      if(item is TObj casted) return casted;

      // 2. check if we have hit the max depth
      if(index >= depth) return default(TObj);

      // 3. handle potential collections
      if(item is Onto onto)
      {
        var o = onto[name];
        if(o is TObj itemCast) return itemCast;

        foreach(var oChild in onto.children)
        {
          var childObj = Traverse<TObj>(oChild, name, depth, ref index);
          if(childObj != null) return childObj;
        }
      }
      else if(item.IsList(out var items))
      {
        foreach(var child in items)
        {
          var childObj = Traverse<TObj>(child, name, depth, ref index);
          if(childObj != null) return childObj;
        }
      }
      return default(TObj);
    }

  }



}
