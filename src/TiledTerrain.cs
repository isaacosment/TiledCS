namespace TiledCS
{
    /// <summary>
    /// Represents a terrain definition.
    /// </summary>
    public struct TiledTerrain
    {
        /// <summary>
        /// Constructs a new terrain with the specified name and tile.
        /// </summary>
        /// <param name="name">The terrain name.</param>
        /// <param name="tile">The tile used as icon in the terrain editor.</param>
        public TiledTerrain(string name, int tile)
        {
            Name = name;
            Tile = tile;
        }

        /// <summary>
        /// The terrain name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The tile used as icon for the terrain editor
        /// </summary>
        public int Tile { get; }
    }
}