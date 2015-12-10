using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;
using Triangles;

namespace TrianglesIntegrationTests
{
    [TestFixture]
    public class RigntTriangleTests
    {
        [Test]
        public void SerializeAndDeserialize_RightTriangle_Success()
        {
            RightTriangle triangle1 = new RightTriangle(3, 4, 5);

            //Serialize rightTriangle to rightTriangleBytes
            byte[] rightTriangleBytes;
            BinaryFormatter bf1 = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf1.Serialize(ms, triangle1);
                rightTriangleBytes = ms.ToArray();
            }

            //Deserialize rightTriangleBytes to rightTriangle
            RightTriangle rightTriangle2;
            BinaryFormatter bf2 = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(rightTriangleBytes, 0, rightTriangleBytes.Length))
            {
                rightTriangle2 = (RightTriangle)bf2.Deserialize(ms);
            }

            Assert.That(triangle1.Equals(rightTriangle2));
        }
    }
}
