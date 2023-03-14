using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Sasaki.Objects {
  public class Types {
    
    #region Box
    public class Box {
      #region members
      [JsonProperty("center")]
      public CloudPoint center { get; set; }
    
      [JsonProperty("xsize")]
      public double? xsize { get; set; }
    
      [JsonProperty("ysize")]
      public double? ysize { get; set; }
    
      [JsonProperty("zsize")]
      public double? zsize { get; set; }
      #endregion
    }
    #endregion
    
    #region BoxInput
    public class BoxInput {
      #region members
      public double? xsize { get; set; }
    
      public double? ysize { get; set; }
    
      public double? zsize { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
    
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CloudPoint
    public class CloudPoint {
      #region members
      [JsonProperty("meta")]
      public string meta { get; set; }
    
      [JsonProperty("point")]
      public Point point { get; set; }
      #endregion
    }
    #endregion
    
    #region Normal
    public class Normal : Vector {
      #region members
      [JsonProperty("x")]
      public double x { get; set; }
    
      [JsonProperty("y")]
      public double y { get; set; }
    
      [JsonProperty("z")]
      public double z { get; set; }
      #endregion
    }
    #endregion
    
    #region NormalCloud
    public class NormalCloud : SasakiObject {
      #region members
      [JsonProperty("id")]
      public string id { get; set; }
    
      [JsonProperty("name")]
      public string name { get; set; }
    
      [JsonProperty("normals")]
      public List<NormalPoint> normals { get; set; }
      #endregion
    }
    #endregion
    
    #region NormalPoint
    public class NormalPoint {
      #region members
      [JsonProperty("meta")]
      public string meta { get; set; }
    
      [JsonProperty("normal")]
      public Normal normal { get; set; }
    
      [JsonProperty("point")]
      public Point point { get; set; }
      #endregion
    }
    #endregion
    
    #region Point
    public class Point : Vector {
      #region members
      [JsonProperty("x")]
      public double x { get; set; }
    
      [JsonProperty("y")]
      public double y { get; set; }
    
      [JsonProperty("z")]
      public double z { get; set; }
      #endregion
    }
    #endregion
    
    #region Query
    public class Query {
      #region members
      [JsonProperty("getObject")]
      public SasakiObject getObject { get; set; }
    
      [JsonProperty("getPoints")]
      public List<CloudPoint> getPoints { get; set; }
      #endregion
    }
    #endregion
    
    #region ResultCloud
    public class ResultCloud {
      #region members
      [JsonProperty("data")]
      public List<ResultCloudData> data { get; set; }
    
      [JsonProperty("id")]
      public string id { get; set; }
    
      [JsonProperty("points")]
      public List<CloudPoint> points { get; set; }
      #endregion
    }
    #endregion
    
    #region ResultCloudData
    public class ResultCloudData {
      #region members
      [JsonProperty("option")]
      public ViewContentOption option { get; set; }
    
      [JsonProperty("values")]
      public List<int?> values { get; set; }
      #endregion
    }
    #endregion
    
    /// <summary>
    /// A simple container object that is mainly used for acting as an anchor point for a specific workflow type
    /// </summary>
    public interface SasakiContainer {
      /// <summary>
      /// The id related to the reference object id
      /// </summary>
      [JsonProperty("id")]
      string id { get; set; }
    
      /// <summary>
      /// An optional name for the object
      /// </summary>
      [JsonProperty("name")]
      string name { get; set; }
    
      /// <summary>
      /// The items it contains
      /// </summary>
      [JsonProperty("objects")]
      List<SasakiObject> objects { get; set; }
    }
    
    /// <summary>
    /// A simple object used for Sasaki projects
    /// </summary>
    public interface SasakiObject {
      /// <summary>
      /// The id related to the reference object id
      /// </summary>
      [JsonProperty("id")]
      string id { get; set; }
    
      /// <summary>
      /// An optional name for the object
      /// </summary>
      [JsonProperty("name")]
      string name { get; set; }
    }
    
    public interface Vector {
      [JsonProperty("x")]
      double x { get; set; }
    
      [JsonProperty("y")]
      double y { get; set; }
    
      [JsonProperty("z")]
      double z { get; set; }
    }
    
    #region ViewCloud
    public class ViewCloud : SasakiObject {
      #region members
      [JsonProperty("id")]
      public string id { get; set; }
    
      [JsonProperty("name")]
      public string name { get; set; }
    
      [JsonProperty("points")]
      public List<CloudPoint> points { get; set; }
      #endregion
    }
    #endregion
    
    #region ViewContentOption
    public class ViewContentOption {
      #region members
      [JsonProperty("content")]
      public string content { get; set; }
    
      [JsonProperty("target")]
      public string target { get; set; }
    
      [JsonProperty("type")]
      public ViewContentType type { get; set; }
      #endregion
    }
    #endregion
      /// <summary>
      /// A set of statuses a Content type would utilize in a View Study
      /// </summary>
    public enum ViewContentType {
      /// <summary>
      /// The main blocking content item that sets the study with a current condition value
      /// </summary>
      EXISTING,
      /// <summary>
      /// Optional content items that gives studies the ability to have multiple scenarios
      /// </summary>
      PROPOSED,
      /// <summary>
      /// The potential content item used to gather the max amount of pixels in a view
      /// </summary>
      TARGET
    }
    
  }
  
}
