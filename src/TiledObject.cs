using System.Collections.Generic;

namespace TiledCS
{
    /// <summary>
    /// Represents an tiled object defined in object layers
    /// </summary>
    public struct TiledObject
    {
        public TiledObject(
            int id,
            string name,
            string type,
            float x,
            float y,
            int rotation,
            float width,
            float height,
            IEnumerable<TiledProperty> properties
        )
        {
            Id = id;
            Name = name;
            Type = type;
            X = x;
            Y = y;
            Rotation = rotation;
            Width = width;
            Height = height;
            Properties = properties;
        }

        /// <summary>
        /// The object id
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// The object's name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The object type if defined. Null if none was set.
        /// </summary>
        public string Type { get; }
        /// <summary>
        /// The object's x position in pixels
        /// </summary>
        public float X { get; }
        /// <summary>
        /// The object's y position in pixels
        /// </summary>
        public float Y { get; }
        /// <summary>
        /// The object's rotation
        /// </summary>
        public int Rotation { get; }
        /// <summary>
        /// The object's width in pixels
        /// </summary>
        public float Width { get; }
        /// <summary>
        /// The object's height in pixels
        /// </summary>
        public float Height { get; }
        /// <summary>
        /// An array of properties.
        /// </summary>
        public IEnumerable<TiledProperty> Properties { get; }
    }
}