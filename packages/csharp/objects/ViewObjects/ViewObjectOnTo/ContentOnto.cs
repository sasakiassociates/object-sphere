using Stratosphere;
using ViewObjects;
using ViewObjects.Contents;

namespace Sasaki.Objects.ViewObjects.Onto;

public class ContentOnto : OntoNode, IContent
{


  public ContentOnto()
  {
    ViewId = Guid.NewGuid().ToString();
  }

  public string ViewName { get; set; }
  public string ViewId { get; }
  public ViewContentType type { get; }
  public ViewColor Color { get; set; }
}