using System;

namespace KargerMinCut
{
    public class Edge : IEquatable<Edge>
    {
        public Edge(Vertex vertex1, Vertex vertex2)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
        }

        public Edge(Vertex vertex1, Vertex vertex2, bool directional)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            _directional = directional;
        }

        private readonly bool _directional;
        public Vertex Vertex1 { get; set; }
        public Vertex Vertex2 { get; set; }

        public bool Equals(Edge other)
        {
            var baseComparisonResult = Vertex1.Name == other.Vertex1.Name && Vertex2.Name == other.Vertex2.Name;
            if (!_directional)
            {
                return baseComparisonResult ||
                       (Vertex1.Name == other.Vertex2.Name && Vertex2.Name == other.Vertex1.Name);
            }
            return baseComparisonResult;
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
                if (!_directional) 
                    return _directional.GetHashCode() ^ Vertex1.GetHashCode() ^ Vertex2.GetHashCode();
                
                var hashCode = _directional.GetHashCode();
                hashCode = (hashCode*397) ^ Vertex1.GetHashCode();
                hashCode = (hashCode*397) ^ Vertex2.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Vertex1.Name, Vertex2.Name);
        }
    }
}