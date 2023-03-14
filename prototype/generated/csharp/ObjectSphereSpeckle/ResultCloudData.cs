using Speckle.Core.Models;
using System.Collections.Generic;

namespace Sasaki.Objects.Speckle
{

  public class ResultCloudData : Base
  {
    public Types.ViewContentOption option { get; set; }

    [Chunkable]
    public List<int> values { get; set; }

    public ResultCloudData()
    { }
  }

}