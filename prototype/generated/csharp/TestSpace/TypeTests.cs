using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Threading;

namespace Sasaki.Objects.Tests
{

  public class TypeTests
  {

    public static string NewId() => Guid.NewGuid().ToString();

    public static List<Types.Point> RandomPoints(int count)
    {
      var rando = new Random();
      var points = new List<Types.Point>(count);
      for(int i = 0; i < count; i++)
      {
        points.Add(new Types.Point() {x = rando.NextDouble(), y = rando.NextDouble(), z = rando.NextDouble()});
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
          value = data,
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
        point = RandomPoints(10),
        data = RandomResultData(10, 2)
      };
      var container = new Onto();
      container["ResultCloud"] = obj;
      
      var serializer = JsonSerializer.Create(ObjectSphere.settings);

      Types.ResultCloud result = null;
      var path = @"D:\Projects\Sasaki\object-sphere\prototype\csharp-test.json";

      using(var handle = new JsonTextWriter(new StreamWriter(path)))
      {
        serializer.Serialize(handle, container);
      }

      Assert.IsTrue(File.Exists(path));

      using(var handle = new JsonTextReader(new StreamReader(path)))
      {
        result = serializer.Deserialize<Types.ResultCloud>(handle);
      }

      Assert.IsNotNull(result);

      Assert.IsTrue(obj.id.Equals(result.id));
      Assert.IsTrue(obj.point.Count == result.point.Count);
      Assert.IsTrue(obj.data.Count == result.data.Count);

      for(int pIndex = 0; pIndex < obj.point.Count; pIndex++)
      {
        var p1 = obj.point[pIndex];
        var p2 = result.point[pIndex];

        Assert.IsTrue(p1.x.Equals(p2.x) &&
                      p1.y.Equals(p2.y) &&
                      p1.z.Equals(p2.z)
        );
      }

      for(int rIndex = 0; rIndex < obj.data.Count; rIndex++)
      {
        var r1 = obj.data[rIndex];
        var r2 = result.data[rIndex];
        Assert.IsTrue(r1.option.type == r2.option.type);
        Assert.IsTrue(r1.option.content.Equals(r2.option.content) &&
                      r1.option.target.Equals(r2.option.target));

        for(int i = 0; i < r1.value.Count; i++)
        {
          Assert.NotNull(r1.value[i]);
          Assert.NotNull(r2.value[i]);
          Assert.AreEqual(r1.value[i], r2.value[i]);

        }

      }

      Assert.Pass();
    }
  }

}
