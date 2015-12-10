using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;
using Triangles;

namespace TrianglesIntegrationTests
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]
        public void SerializeAndDeserialize_Triangle_Success()
        {
            Triangle triangle1 = new Triangle(1, 1.5, 2);

            //Serialize triangle to triangleBytes
            byte[] triangleBytes;
            BinaryFormatter bf1 = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf1.Serialize(ms, triangle1);
                triangleBytes = ms.ToArray();
            }

            //Deserialize triangleBytes to triangle
            Triangle triangle2;
            BinaryFormatter bf2 = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(triangleBytes, 0, triangleBytes.Length))
            {
                triangle2 = (Triangle) bf2.Deserialize(ms);
            }

            Assert.That(triangle1.Equals(triangle2));
        }
    }
}
