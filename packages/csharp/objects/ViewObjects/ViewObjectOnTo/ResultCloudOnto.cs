using Newtonsoft.Json;
using Stratosphere;
using ViewObjects.Clouds;

namespace Sasaki.Objects.ViewObjects.Onto;

public class ResultCloudOnto : OntoNode, IResultCloud
{
    
  public ResultCloudOnto()
  {
    ViewId = Guid.NewGuid().ToString();
  }

  [JsonConstructor]
  public ResultCloudOnto(List<ResultCloudDataOnto> data, CloudPoint[] point)
  {
    ViewId = Guid.NewGuid().ToString();
    Points = point;
    Data = data.Cast<IResultCloudData>().ToList();
  }


  public string ViewId { get; }
  public CloudPoint[]? Points { get; set; }
  public List<IResultCloudData>? Data { get; set; }
    
  // public List<ResultCloudDataOnto>? Data { get; set; } = new List<ResultCloudDataOnto>();
  // [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
}