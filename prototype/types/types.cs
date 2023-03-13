using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GraphQLCodeGen {
  public class Types {
    
    public interface Bounds {
      [JsonProperty("x")]
      int x { get; set; }
    
      [JsonProperty("y")]
      int y { get; set; }
    
      [JsonProperty("z")]
      int z { get; set; }
    }
    
    public interface NormalPoint {
      [JsonProperty("Normals")]
      Normals Normals { get; set; }
    
      [JsonProperty("Point")]
      Point Point { get; set; }
    }
    
    public interface Normals {
      [JsonProperty("x")]
      int x { get; set; }
    
      [JsonProperty("y")]
      int y { get; set; }
    
      [JsonProperty("z")]
      int z { get; set; }
    }
    
    public interface Point {
      [JsonProperty("x")]
      int x { get; set; }
    
      [JsonProperty("y")]
      int y { get; set; }
    
      [JsonProperty("z")]
      int z { get; set; }
    }
    
    public interface Result {
      [JsonProperty("ResultCloud")]
      List<ResultCloud> ResultCloud { get; set; }
    }
    
    public interface ResultCloud {
      [JsonProperty("NormalPoint")]
      List<NormalPoint> NormalPoint { get; set; }
    
      [JsonProperty("ResultCloudData")]
      ResultCloudData ResultCloudData { get; set; }
    }
    
    public interface ResultCloudData {
      [JsonProperty("data")]
      string data { get; set; }
    
      [JsonProperty("here")]
      string here { get; set; }
    
      [JsonProperty("right")]
      string right { get; set; }
    
      [JsonProperty("some")]
      string some { get; set; }
    }
  }
  
}
