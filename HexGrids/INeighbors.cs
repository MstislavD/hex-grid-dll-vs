namespace HexGrids
{
    public interface INeighbors<T>
    {
        IEnumerable<T> Neighbors { get; }
    }
}
