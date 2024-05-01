using System;
using System.Collections.Generic;

namespace TiledCS
{
    /// <summary>
    /// Represents a type of shape in Tiled.
    /// </summary>
    public enum TiledShape
    {
        Rectangle,
        Point,
        Ellipse
    }

    /// <summary>
    /// Represents a property object in both tilesets, maps, layers and objects. Values are all in string but you can use the 'type' property for conversions
    /// </summary>
    public struct TiledProperty : IEquatable<TiledProperty>
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

        public override bool Equals(object obj)
        {
            return obj is TiledProperty property && Equals(property);
        }

        public bool Equals(TiledProperty other)
        {
            return Name == other.Name &&
                   Type == other.Type &&
                   Value == other.Value;
        }

        public override int GetHashCode()
        {
            int hashCode = 1168257605;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
            return hashCode;
        }

        public static bool operator ==(TiledProperty left, TiledProperty right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TiledProperty left, TiledProperty right)
        {
            return !(left == right);
        }
    }
}