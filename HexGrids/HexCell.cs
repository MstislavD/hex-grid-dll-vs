namespace HexGrids
{

    public class HexCell<TCell, TEdge> : INeighbors<TCell>
    {
        Vertex[] _vertices = new Vertex[6];
        TCell[] _neighbors = new TCell[6];
        TEdge[] _edges = new TEdge[6];

        public Vertex Center { get; set; }
        public void AddNeighbor(TCell cell, int direction) => _neighbors[direction] = cell;
        public void AddVertex(Vertex vertex, int direction) => _vertices[direction] = vertex;
        public void AddEdge(TEdge edge, int direction) => _edges[direction] = edge;
        public TCell GetNeighbor(int direction) => _neighbors[direction % 6];
        public Vertex GetVertex(int direction) => _vertices[direction % 6];
        public TEdge GetEdge(int direction) => _edges[direction % 6];
        public IEnumerable<Vertex> Vertices => _vertices;
        public IEnumerable<TCell> Neighbors => _neighbors.Where(n => n != null);
        public IEnumerable<TEdge> Edges => _edges;
        public TEdge GetEdgeByNeighbor(TCell neighbor) => _edges[Array.IndexOf(_neighbors, neighbor)];
        public int GetDirection(TEdge edge) => _edges.ToList().IndexOf(edge);
        public int GridPositionX { get; set; }
        public int GridPositionY { get; set; }
    }

    class HexCell : HexCell<HexCell, Edge> { }

    class Edge : Edge<HexCell> { }

    class HexGrid : HexGrid<HexCell, Edge>
    {
        public HexGrid(int _width, int _height) : base(_width, _height)
        {
        }
    }
}
