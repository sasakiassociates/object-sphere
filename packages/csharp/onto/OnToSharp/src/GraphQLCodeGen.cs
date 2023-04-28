using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

using Types;

namespace GraphQLCodeGen {
  
  public class Schema {
    
    public interface Normal {
      [JsonProperty("x")]
      public int x { get; set; }
    
      [JsonProperty("y")]
      public int y { get; set; }
    
      [JsonProperty("z")]
      public int z { get; set; }
    }
    
    public interface NormalPoint {
      [JsonProperty("Normal")]
      public Types.Normal Normal { get; set; }
    
      [JsonProperty("Point")]
      public Types.Point Point { get; set; }
    }
    
    public interface Point {
      [JsonProperty("x")]
      public int x { get; set; }
    
      [JsonProperty("y")]
      public int y { get; set; }
    
      [JsonProperty("z")]
      public int z { get; set; }
    }
    
    public interface Result {
      [JsonProperty("ResultCloud")]
      public List<Types.ResultCloud> ResultCloud { get; set; }
    }
    
    public interface ResultCloud {
      [JsonProperty("NormalPoint")]
      public List<Types.NormalPoint> NormalPoint { get; set; }
    
      [JsonProperty("ResultCloudData")]
      public Types.ResultCloudData ResultCloudData { get; set; }
    }
    
    public interface ResultCloudData {
      [JsonProperty("data")]
      public string data { get; set; }
    
      [JsonProperty("here")]
      public string here { get; set; }
    
      [JsonProperty("right")]
      public string right { get; set; }
    
      [JsonProperty("some")]
      public string some { get; set; }
    }
  }
  
}
