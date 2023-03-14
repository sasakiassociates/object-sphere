using Speckle.Core.Models;
using System.Collections.Generic;

namespace Sasaki.Objects.Speckle
{

  public class ResultCloud : Base
  {
    public List<ResultCloudData> data { get; set; }

    [Chunkable]
    public List<double> points { get; set; }

    [Chunkable]
    public List<string> metas { get; set; }

    public ResultCloud()
    { }

  }

}