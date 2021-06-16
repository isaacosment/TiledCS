using System.Collections.Generic;

namespace TiledCS
{
    /// <summary>
    /// Represents a tile within a tileset
    /// </summary>
    /// <remarks>These are not defined for all tiles within a tileset, only the ones with properties, terrains and animations.</remarks>
    public struct TiledTile
    {
        /// <summary>
        /// The tile id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The terrain definitions as int array. These are indices indicating what part of a terrain and which terrain this tile represents.
        /// </summary>
        /// <remarks>In the map file empty space is used to indicate null or no value. However, since it is an int array I needed something so I decided to replace empty values with -1.</remarks>
        public int[] Terrain { get; set; }
        /// <summary>
        /// An array of properties. Is null if none were defined.
        /// </summary>
        public IEnumerable<TiledProperty> Properties { get; set; }
        /// <summary>
        /// An array of tile animations. Is null if none were defined. 
        /// </summary>
        public IEnumerable<TiledTileAnimation> Animations { get; set; }
        /// <summary>
        /// The individual tile image
        /// </summary>
        public TiledTileImage? Image { get; set; }
    }
}