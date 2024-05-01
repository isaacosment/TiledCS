using System.Collections.Generic;

namespace TiledCS
{
    /// <summary>
    /// Represents an tiled object defined in object layers
    /// </summary>
    public struct TiledObject
    {
        /// <summary>
        /// The object id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The tile gid used as this object's image
        /// </summary>
        public int Gid { get; set; }
        /// <summary>
        /// The object's name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The object type if defined. Null if none was set.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// The object's x position in pixels
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// The object's y position in pixels
        /// </summary>
        public float Y { get; set; }
        /// <summary>
        /// The object's rotation
        /// </summary>
        public int Rotation { get; set; }
        /// <summary>
        /// The object's width in pixels
        /// </summary>
        public float Width { get; set; }
        /// <summary>
        /// The object's height in pixels
        /// </summary>
        public float Height { get; set; }
        /// <summary>
        /// An array of properties.
        /// </summary>
        public IEnumerable<TiledProperty> Properties { get; set; }

        public TiledShape Shape { get; set; }
    }
}