using Stratosphere;
using Types;

namespace OntoTest;

public class Tests
{


  [Test]
  public void ResultCloud_OntoClass()
  {

    using StreamReader r = new(@"..\..\..\testfile.json");
    string json = r.ReadToEnd();

    Result? result = Onto.Deserialize<Result>(json);

    Assert.That(result, Is.Not.Null);

    Console.WriteLine(result.ResultCloud.FirstOrDefault().ResultCloudData);

    List<ResultCloud> clouds = result.Onto<ResultCloud>();
    Assert.That(clouds, Is.Not.Empty);

    // Console.WriteLine(Onto.Serialize(clouds[0]));

    var ontoData = result.Onto<Point>();
    Assert.That(ontoData, Is.Not.Empty);
    Console.WriteLine(Onto.Serialize(ontoData[0]));
    // when we traverse this we are still looking for point cloud types
    // and we want to check if there is any items nested in there 

  }

  [Test]
  public void Point_OntoClass()
  {
    var path = @"..\..\..\point-test.json";
    var og = new PointNode(10, 5, 2);

    using StreamWriter sw = new(path);
    sw.Write(Onto.Serialize(og));
    sw.Close();

    using StreamReader sr = new(path);
    var json = sr.ReadToEnd();

    var de = Onto.Deserialize<PointNode>(json);
    Assert.That(de, Is.Not.Null);
    Assert.True(de.x == og.x && de.y == og.y && de.z == og.z);


  }

  [Test]
  public void PointCloud_OntoClass()
  {
    var path = @"..\..\..\pointcloud-test.json";

    var values = new List<PointNode>();
    for(int i = 0; i < 10; i++)
    {
      values.Add(new PointNode(i, i, i));
    }

    var og = new PointCloud(values);

    using StreamWriter sw = new(path);
    sw.Write(Onto.Serialize(og));
    sw.Close();

    using StreamReader sr = new(path);
    var json = sr.ReadToEnd();

    var de = Onto.Deserialize<PointCloud>(json);
    Assert.That(de, Is.Not.Null);
    Assert.That(de.points, Is.Not.Empty);
    Assert.IsTrue(de.points.Count == og.points.Count);

    for(int i = 0; i < de.points.Count; i++)
    {
      Assert.True(de.points[i].x == og.points[i].x && de.points[i].y == og.points[i].y && de.points[i].z == og.points[i].z);
    }

  }


  [Test]
  public void Onto_NestedStuff()
  {


    var values = new List<PointNode>();
    for(int i = 0; i < 10; i++)
    {
      values.Add(new PointNode(i, i, i));
    }
    var container = new ContainerNode() {node = new List<IOntoNode>() {new PointCloud(values), new PointNode(200, 200, 200)}};

    var result = container.Onto<IOntoNode>();

    Assert.That(result, Is.Not.Null);
    Assert.That(result, Is.Not.Empty);
    result.ForEach(Console.WriteLine);
  }

#region test objects

  public class ContainerNode : OntoNode
  {
    public List<IOntoNode> node = new();


    public ContainerNode()
    { }
  }

  public class PointCloud : OntoNode
  {

    public PointCloud()
    { }

    public PointCloud(List<PointNode> points)
    {
      this.points = points;
    }

    public List<PointNode> points = new List<PointNode>();
  }

  /// <summary>
  /// a simple object that inherits from <seealso cref="OntoNode"/>
  /// </summary>
  public class PointNode : OntoNode
  {

    public int x, y, z;

    public PointNode()
    { }

    public PointNode(int x, int y, int z)
    {
      this.x = x;
      this.y = y;
      this.z = z;
    }

    public override string ToString() => $"{x},{y},{z}";

  }

#endregion

}
