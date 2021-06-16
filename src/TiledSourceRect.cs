namespace TiledCS
{
    /// <summary>
    /// Used as data type for the GetSourceRect method. Represents basically a rectangle.
    /// </summary>
    public struct TiledSourceRect
    {
        /// <summary>
        /// The x position in pixels from the tile location in the source image
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// The y position in pixels from the tile location in the source image
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// The width in pixels from the tile in the source image
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// The height in pixels from the tile in the source image
        /// </summary>
        public int Height { get; set; }
    }
}