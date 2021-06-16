using System.Collections.Generic;

namespace TiledCS
{

    /// <summary>
    /// Represents a tile layer as well as an object layer within a tile map
    /// </summary>
    public struct TiledLayer
    {
        public TiledLayer(int id, string name, int width, int height, LayerType type, bool visible, int[] data, byte[] dataRotationFlags, IEnumerable<TiledObject> objects)
        {
            Id = id;
            Name = name;
            Width = width;
            Height = height;
            Type = type;
            Visible = visible;
            Data = data;
            DataRotationFlags = dataRotationFlags;
            Objects = objects;
        }

        /// <summary>
        /// The layer id
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// The layer name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Total horizontal tiles
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// Total vertical tiles
        /// </summary>
        public int Height { get; }
        /// <summary>
        /// The layer type. Usually this is "objectgroup" or "tilelayer".
        /// </summary>
        public LayerType Type { get; }
        /// <summary>
        /// Defines if the layer is visible in the editor
        /// </summary>
        public bool Visible { get; }
        /// <summary>
        /// An int array of gid numbers which define which tile is being used where. The length of the array equals the layer width * the layer height. Is null when the layer is not a tilelayer.
        /// </summary>
        public int[] Data { get; }
        /// <summary>
        /// A parallel array to data which stores the rotation flags of the tile.
        /// Bit 3 is horizontal flip,
        /// bit 2 is vertical flip, and
        /// bit 1 is (anti) diagonal flip.
        /// Is null when the layer is not a tilelayer.
        /// </summary>
        public byte[] DataRotationFlags { get; }
        /// <summary>
        /// The list of objects in case of an objectgroup layer. Is null when the layer has no objects.
        /// </summary>
        public IEnumerable<TiledObject> Objects { get; }
    }
}