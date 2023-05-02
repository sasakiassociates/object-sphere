using Stratosphere;
using ViewObjects;
using ViewObjects.Studies;

namespace Sasaki.Objects.ViewObjects.Onto
{

  public class ViewStudyOnto : OntoNode, IViewStudy
  {

    public ViewStudyOnto()
    {
      ViewId = Guid.NewGuid().ToString();
    }

    public string ViewId { get; }
    public string? ViewName { get; set; }
    public List<IViewObject>? objects { get; set; } = new List<IViewObject>();
  }


}
