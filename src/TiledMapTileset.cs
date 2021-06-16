namespace TiledCS
{
    /// <summary>
    /// Represents an element within the Tilesets array of a TiledMap object
    /// </summary>
    public struct TiledMapTileset
    {
        public TiledMapTileset(int firstgid, string source)
        {
            Firstgid = firstgid;
            Source = source;
        }

        /// <summary>
        /// The first gid defines which gid matches the tile with source vector 0,0. Is used to determine which tileset belongs to which gid
        /// </summary>
        public int Firstgid { get; }
        /// <summary>
        /// The tsx file path as defined in the map file itself
        /// </summary>
        public string Source { get; }
    }
}