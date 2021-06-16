namespace TiledCS
{
    /// <summary>
    /// Represents an image within a tile
    /// </summary>
    public struct TiledTileImage
    {
        /// <summary>
        /// The image width
        /// </summary>
        public int Width { get; set; }
        
        /// <summary>
        /// The image height
        /// </summary>
        public int Height { get; set; }
        
        /// <summary>
        /// The image source path
        /// </summary>
        public string Source { get; set; }
    }
}