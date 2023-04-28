using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sasaki.Objects
{

  public class Types
  {

  #region Box

    public class Box
    {

    #region members

      [JsonProperty("center")]
      public Point center { get; set; }

      [JsonProperty("xSize")]
      public double? xSize { get; set; }

      [JsonProperty("yize")]
      public double? yize { get; set; }

      [JsonProperty("zsize")]
      public double? zsize { get; set; }

    #endregion

    }

  #endregion

  #region Normal

    public class Normal : IVector
    {

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

    public class NormalCloud : SasakiObject
    {

    #region members

      [JsonProperty("id")]
      public string id { get; set; }

      [JsonProperty("name")]
      public string name { get; set; }

      [JsonProperty("normal")]
      public List<NormalPoint> normal { get; set; }

    #endregion

    }

  #endregion

  #region NormalPoint

    public class NormalPoint
    {

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

    public class Point : IVector
    {

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

    public interface PointCloud
    {
      [JsonProperty("id")]
      string id { get; set; }

      [JsonProperty("name")]
      string name { get; set; }

      [JsonProperty("point")]
      List<Point> point { get; set; }
    }

  #region ResultCloud

    public class ResultCloud
    {

    #region members

      [JsonProperty("data")]
      public List<ResultCloudData> data { get; set; }

      [JsonProperty("id")]
      public string id { get; set; }

      [JsonProperty("point")]
      public List<Point> point { get; set; }

    #endregion

    }

  #endregion

  #region ResultCloudData

    public class ResultCloudData
    {

    #region members

      [JsonProperty("option")]
      public ViewContentOption option { get; set; }

      [JsonProperty("value")]
      public List<int?> value { get; set; }

    #endregion

    }

  #endregion

    public interface SasakiObject
    {
      [JsonProperty("id")]
      string id { get; set; }

      [JsonProperty("name")]
      string name { get; set; }
    }

    public interface IVector
    {
      [JsonProperty("x")]
      double x { get; set; }

      [JsonProperty("y")]
      double y { get; set; }

      [JsonProperty("z")]
      double z { get; set; }
    }

  #region ViewContentOption

    public class ViewContentOption
    {

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
    public enum ViewContentType
    {
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
