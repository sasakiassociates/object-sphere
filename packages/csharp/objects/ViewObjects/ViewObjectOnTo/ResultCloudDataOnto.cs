using Newtonsoft.Json;
using Stratosphere;
using ViewObjects.Clouds;
using ViewObjects.Contents;

namespace Sasaki.Objects.ViewObjects.Onto;

public class ResultCloudDataOnto : OntoNode, IResultCloudData
{

  public ResultCloudDataOnto()
  { }

  [JsonConstructor]
  public ResultCloudDataOnto(ContentOption option, int count, List<int> values)
  {
    this.count = count;
    this.info = option;
    this.values = values;
  }

  public IContentOption? info { get; set; }
  public int count { get; set; } = 0;
  public List<int>? values { get; set; } = new List<int>();
}