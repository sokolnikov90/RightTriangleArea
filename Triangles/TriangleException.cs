using System;
using System.Runtime.Serialization;

namespace Triangles
{
    [Serializable]
    public class TriangleException : Exception, ISerializable
    {
        public TriangleException()
        { }

        public TriangleException(string message)
            : base(message) { }

        public TriangleException(string message, Exception inner)
            : base(message, inner) { }

        protected TriangleException(SerializationInfo info, StreamingContext ctxt)
            : base(info, ctxt) { }
    }
}
