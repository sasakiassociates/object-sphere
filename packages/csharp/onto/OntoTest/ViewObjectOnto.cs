using Sasaki.Objects.ViewObjects.Onto;
using Stratosphere;
using ViewObjects;
using ViewObjects.Clouds;
using ViewObjects.Contents;

namespace OntoTest;

[TestFixture]
public class ViewObjectOnto
{



  List<int>? GenerateValues(int count)
  {
    List<int>? values = new();
    var r = new Random();
    for(int i = 0; i < count; i++)
    {
      values.Add(r.Next());
    }
    return values;
  }

  [Test]
  public void ResultCloud_Onto()
  {
    // var item = Speckle.Newtonsoft.Json.JsonConvert()

    var points = new CloudPoint[10];
    for(int i = 0; i < 10; i++) points[i] = new CloudPoint(i, i, i);

    var target = new Content(ViewContentType.Potential, viewName: "kitty");
    var blocker = new Content(ViewContentType.Existing, viewName: "chubby");
    
    var data = new List<IResultCloudData>()
    {
      new ResultCloudDataOnto()
      {
        count = points.Length, info = new ContentOption(target, target, ViewContentType.Potential), values = GenerateValues(points.Length)
      },
      new ResultCloudDataOnto()
      {
        count = points.Length, info = new ContentOption(target, blocker, ViewContentType.Existing), values = GenerateValues(points.Length)
      },
    };

    var og = new ResultCloudOnto()
    {
      Points = points,
      Data = data
    };
    
    var path = @"..\..\..\viewobject-resultcloud-test.json";

    using StreamWriter sw = new(path);
    sw.Write(Onto.Serialize(og));
    sw.Close();

    using StreamReader sr = new(path);
    var json = sr.ReadToEnd();

    var de = Onto.Deserialize<ResultCloudOnto>(json);
    Assert.That(de, Is.Not.Null);
    Assert.That(de.Data, Is.Not.Empty);
    Assert.That(de.Points, Is.Not.Empty);
    
    Assert.That(de.Points, Is.EqualTo(og.Points));
    Assert.That(de.Data, Is.EqualTo(og.Data));
  }

}
