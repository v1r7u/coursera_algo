using System;

namespace KosarajuAlgorithm.GraphClasses
{
    public class Edge : IEquatable<Edge>
    {
        public Edge(Vertex vertex1, Vertex vertex2)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
        }

        public Vertex Vertex1 { get; set; }
        public Vertex Vertex2 { get; set; }

        public bool Equals(Edge other)
        {
            return Vertex1.Name == other.Vertex1.Name && Vertex2.Name == other.Vertex2.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Edge)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 1;
                hashCode = (hashCode * 397) ^ Vertex1.GetHashCode();
                hashCode = (hashCode * 397) ^ Vertex2.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Vertex1.Name, Vertex2.Name);
        }
    }
}