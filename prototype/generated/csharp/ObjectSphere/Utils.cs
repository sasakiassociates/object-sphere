using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sasaki.Objects
{

  public static class Utils
  {

    /// <summary>
    /// Short hand for passing the type from <param name="obj"></param> to <see cref="IsList(Type)"/>   
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool IsList(this object obj) => obj != null && obj.GetType().IsList();

    /// <summary>
    /// Returns true if <param name="type"></param> derives from a <seealso cref="IEnumerable"/>, is not type <seealso cref="IDictionary"/>, and is not type <seealso cref="string"/>. 
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool IsList(this Type type)
    {
      if(type == null) return false;
      return typeof(IEnumerable).IsAssignableFrom(type) && !typeof(IDictionary).IsAssignableFrom(type) && type != typeof(string);
    }

    /// <summary>
    /// Shorthand for checking if object is a list. If true will cast to a generic object type collection
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    public static bool IsList(this object obj, out List<object> list)
    {
      list = new List<object>();

      if(obj.IsList()) list = ((IEnumerable)obj).Cast<object>().ToList();

      return list.Any();
    }
  }

}
