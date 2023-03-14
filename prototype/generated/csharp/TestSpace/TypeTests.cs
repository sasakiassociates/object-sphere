using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Sasaki.Objects.Tests
{

  public class TypeTests
  {

    public static string NewId() => Guid.NewGuid().ToString();

    public static List<Types.CloudPoint> RandomPoints(int count)
    {
      var rando = new Random();
      var points = new List<Types.CloudPoint>(count);
      for(int i = 0; i < count; i++)
      {
        points.Add(new Types.CloudPoint()
        {
          point = new Types.Point() {x = rando.NextDouble(), y = rando.NextDouble(), z = rando.NextDouble()},
          meta = "other info"
        });
      }
      return points;
    }

    public static List<Types.ResultCloudData> RandomResultData(int pointCount, int valueCount)
    {
      var rando = new Random();
      var items = new List<Types.ResultCloudData>(valueCount);
      for(int i = 0; i < valueCount; i++)
      {
        var data = new List<int?>();
        for(int j = 0; j < pointCount; j++) data.Add(rando.Next());

        items.Add(new Types.ResultCloudData()
        {
          values = data,
          option = new Types.ViewContentOption() {content = $"Content-{i}", target = "Content-0", type = Types.ViewContentType.TARGET}
        });
      }
      return items;
    }

    [Test]
    public void ResultCloudTest()
    {
      var obj = new Types.ResultCloud()
      {
        id = NewId(),
        points = RandomPoints(100),
        data = RandomResultData(100, 2)
      };

      var serializer = JsonSerializer.CreateDefault();
      Types.ResultCloud result = null;
      serializer.Formatting = Formatting.Indented;
      var path = @"D:\Projects\Sasaki\object-sphere\prototype\csharp-test.json";

      using(var handle = new JsonTextWriter(new StreamWriter(path)))
      {
        serializer.Serialize(handle, obj);
      }

      Assert.IsTrue(File.Exists(path));

      using(var handle = new JsonTextReader(new StreamReader(path)))
      {
        result = serializer.Deserialize<Types.ResultCloud>(handle);
      }

      Assert.IsNotNull(result);

      Assert.IsTrue(obj.id.Equals(result.id));
      Assert.IsTrue(obj.points.Count == result.points.Count);
      Assert.IsTrue(obj.data.Count == result.data.Count);

      for(int pIndex = 0; pIndex < obj.points.Count; pIndex++)
      {
        var p1 = obj.points[pIndex];
        var p2 = result.points[pIndex];

        Assert.IsTrue(p1.meta.Equals(p2.meta));
        Assert.IsTrue(p1.point.x.Equals(p2.point.x) &&
                      p1.point.y.Equals(p2.point.y) &&
                      p1.point.z.Equals(p2.point.z)
        );
      }

      for(int rIndex = 0; rIndex < obj.data.Count; rIndex++)
      {
        var r1 = obj.data[rIndex];
        var r2 = result.data[rIndex];
        Assert.IsTrue(r1.option.type == r2.option.type);
        Assert.IsTrue(r1.option.content.Equals(r2.option.content) &&
                      r1.option.target.Equals(r2.option.target));

        for(int i = 0; i < r1.values.Count; i++)
        {
          Assert.NotNull(r1.values[i]);
          Assert.NotNull(r2.values[i]);
          Assert.AreEqual(r1.values[i], r2.values[i]);

        }

      }

      Assert.Pass();
    }
  }

}
