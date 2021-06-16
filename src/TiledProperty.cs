namespace TiledCS
{
    /// <summary>
    /// Represents a property object in both tilesets, maps, layers and objects. Values are all in string but you can use the 'type' property for conversions
    /// </summary>
    public struct TiledProperty
    {
        public TiledProperty(string name, string type, string value)
        {
            Name = name;
            Type = type;
            Value = value;
        }

        /// <summary>
        /// The property name or key in string format
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The property type as used in Tiled. Can be bool, number, string, ...
        /// </summary>
        public string Type { get; }
        /// <summary>
        /// The value in string format
        /// </summary>
        public string Value { get; }
    }
}