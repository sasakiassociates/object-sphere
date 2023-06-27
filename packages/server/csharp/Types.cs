using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GraphQLCodeGen {
  public class Types {
    
    #region Building
    public class Building {
      #region members
      [JsonProperty("id")]
      public string id { get; set; }
    
      [JsonProperty("name")]
      public string name { get; set; }
      #endregion
    }
    #endregion
    
    #region CloudPoint
    public class CloudPoint {
      #region members
      [JsonProperty("meta")]
      public string meta { get; set; }
    
      [JsonProperty("x")]
      public int x { get; set; }
    
      [JsonProperty("y")]
      public int y { get; set; }
    
      [JsonProperty("z")]
      public int z { get; set; }
      #endregion
    }
    #endregion
    
    #region ContextOption
    public class ContextOption {
      #region members
      [JsonProperty("content")]
      public ViewContext content { get; set; }
    
      [JsonProperty("target")]
      public ViewContext target { get; set; }
      #endregion
    }
    #endregion
    
    #region Desk
    public class Desk : RobinObject {
      #region members
      [JsonProperty("id")]
      public int id { get; set; }
    
      [JsonProperty("name")]
      public string name { get; set; }
      #endregion
    }
    #endregion
    
    #region Location
    public class Location : RobinObject {
      #region members
      [JsonProperty("account_id")]
      public int account_id { get; set; }
    
      [JsonProperty("address")]
      public string address { get; set; }
    
      [JsonProperty("id")]
      public int id { get; set; }
    
      [JsonProperty("latitude")]
      public double? latitude { get; set; }
    
      [JsonProperty("longitude")]
      public double? longitude { get; set; }
    
      [JsonProperty("name")]
      public string name { get; set; }
      #endregion
    }
    #endregion
    
    #region Organization
    public class Organization : RobinObject {
      #region members
      [JsonProperty("id")]
      public int id { get; set; }
    
      [JsonProperty("name")]
      public string name { get; set; }
      #endregion
    }
    #endregion
    
    #region Query
    public class Query {
      #region members
      [JsonProperty("auth")]
      public bool? auth { get; set; }
    
      [JsonProperty("building")]
      public Building building { get; set; }
    
      [JsonProperty("location")]
      public Location location { get; set; }
    
      [JsonProperty("organization")]
      public Organization organization { get; set; }
    
      [JsonProperty("space")]
      public Space space { get; set; }
    
      [JsonProperty("spaces")]
      public List<Space> spaces { get; set; }
      #endregion
    }
    #endregion
    
    #region ResulData
    public class ResulData {
      #region members
      [JsonProperty("id")]
      public string id { get; set; }
    
      [JsonProperty("info")]
      public ContextOption info { get; set; }
    
      [JsonProperty("values")]
      public List<double> values { get; set; }
      #endregion
    }
    #endregion
    
    #region ResultCloud
    public class ResultCloud {
      #region members
      [JsonProperty("Point")]
      public List<CloudPoint> Point { get; set; }
    
      [JsonProperty("ResultCloudData")]
      public ResulData ResultCloudData { get; set; }
      #endregion
    }
    #endregion
    
    public interface RobinObject {
      [JsonProperty("id")]
      int id { get; set; }
    
      [JsonProperty("name")]
      string name { get; set; }
    }
    
    #region Space
    public class Space : RobinObject {
      #region members
      [JsonProperty("description")]
      public string description { get; set; }
    
      [JsonProperty("id")]
      public int id { get; set; }
    
      [JsonProperty("level_id")]
      public int? level_id { get; set; }
    
      [JsonProperty("name")]
      public string name { get; set; }
    
      [JsonProperty("type")]
      public string type { get; set; }
      #endregion
    }
    #endregion
    
    #region ViewContext
    public class ViewContext {
      #region members
      [JsonProperty("contentType")]
      public string contentType { get; set; }
    
      [JsonProperty("id")]
      public string id { get; set; }
    
      [JsonProperty("name")]
      public string name { get; set; }
      #endregion
    }
    #endregion
  }
  
}
