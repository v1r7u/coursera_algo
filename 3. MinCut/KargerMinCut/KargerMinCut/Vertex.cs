namespace KargerMinCut
{
    public class Vertex
    {
        public Vertex()
        {
        }
        public Vertex(int name)
        {
            Name = name;
        }

        public int Name { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
