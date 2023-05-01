using System.Reflection;
using System.Collections;


namespace Stratosphere
{

  public static class OntoPasta
  {
    internal static bool IsList(this object obj, out List<object> list)
    {
      list = new List<object>();

      if(obj.IsList())
        list = ((IEnumerable)obj).Cast<object>().ToList();

      return list.Any();
    }

    internal static bool IsList(this object? obj) => obj != null && obj.GetType().IsList();

    internal static bool IsList(this Type? type)
    {
      if(type == null)
        return false;

      return typeof(IEnumerable).IsAssignableFrom(type) && !typeof(IDictionary).IsAssignableFrom(type) && type != typeof(string);
    }
  }

  public interface IOntoNode
  {
    public List<T> Onto<T>();
  }

  public abstract class OntoNode : IOntoNode
  {

    public List<T> Onto<T>()
    {

      List<List<T>> results = new List<List<T>> {new List<T>()};

      var target = typeof(T);
      var node = this.GetType();
      var props = node.GetProperties();

      foreach(PropertyInfo prop in props)
      {
        List<T>? list = null;
        var propValue = prop.GetValue(this);

        if(propValue == null) continue;

        var type = prop.PropertyType;

        if(type.IsList())
        {
          //Note: this might cause an issue if we end up using multiple generics at some point. For now I think it's fine
          if(type.GetGenericArguments().Single() == target)
          {
            list = (List<T>)propValue;
          }
          else
          {
            list = new List<T>();
            var propValueList = ((IEnumerable)propValue).Cast<object>().ToList();
           
            foreach(var item in propValueList)
            {
              if(item == null) continue;

              if(item.GetType() is T castedItem)
              {
                list.Add(castedItem);
              }
              else if(item is OntoNode itemOnto)
              {
                var nestedItems = itemOnto.Onto<T>();
                if(nestedItems.Count > 0)
                {
                  list.AddRange(nestedItems);
                }
              }
            }
          }
        }
        else
        {
          if(type == target)
          {
            list = new List<T> {(T)propValue};
          }
          else if(propValue is IOntoNode ontoNode)
          {
            list = ontoNode.Onto<T>();
          }
        }

        if(list != null)
        {
          results.Add(list);
        }
      }

      return results.ToArray().Aggregate((a, b) => a.Concat(b).ToList());
    }
  }

}
