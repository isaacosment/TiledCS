using System;

namespace TiledCS
{
    /// <summary>
    /// Represents a tile animation. Tile animations are a group of tiles which act as frames for an animation.
    /// </summary>
    public struct TiledTileAnimation
    {
        /// <summary>
        /// Constructs a new tiled tile animation with the specified tile id and duration.
        /// </summary>
        /// <param name="tileid">The tile id within a tilset.</param>
        /// <param name="duration">The duration of the animation.</param>
        public TiledTileAnimation(int tileid, TimeSpan duration)
        {
            Tileid = tileid;
            Duration = duration;
        }

        /// <summary>
        /// The tile id within a tileset
        /// </summary>
        public int Tileid { get; }
        /// <summary>
        /// The duration.
        /// </summary>
        public TimeSpan Duration { get; }
    }
}