using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace TiledCS
{
    /// <summary>
    /// Represents a Tiled tileset
    /// </summary>
    public class TiledTileset
    {
        /// <summary>
        /// The Tiled version used to create this tileset
        /// </summary>
        public string TiledVersion { get; set; }
        /// <summary>
        /// The tileset name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The tile width in pixels
        /// </summary>
        public int TileWidth { get; set; }
        /// <summary>
        /// The tile height in pixels
        /// </summary>
        public int TileHeight { get; set; }
        /// <summary>
        /// The total amount of tiles
        /// </summary>
        public int TileCount { get; set; }
        /// <summary>
        /// The amount of horizontal tiles
        /// </summary>
        public int Columns { get; set; }
        /// <summary>
        /// The file path to the image used for this tileset
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// The image width in pixels
        /// </summary>
        public int ImageWidth { get; set; }
        /// <summary>
        /// The image height in pixels
        /// </summary>
        public int ImageHeight { get; set; }
        /// <summary>
        /// The amount of spacing between the tiles in pixels
        /// </summary>
        public int Spacing { get; set; }
        /// <summary>
        /// The amount of margin between the tiles in pixels
        /// </summary>
        public int Margin { get; set; }
        /// <summary>
        /// An array of tile definitions
        /// </summary>
        /// <remarks>Not all tiles within a tileset have definitions. Only those with properties, animations, terrains, ...</remarks>
        public TiledTile[] Tiles { get; set; }
        /// <summary>
        /// An array of terrain definitions
        /// </summary>
        public List<TiledTerrain> Terrains { get; set; }
        /// <summary>
        /// An array of tileset properties
        /// </summary>
        public TiledProperty[] Properties { get; set; }

        /// <summary>
        /// Returns an empty instance of TiledTileset
        /// </summary>
        public TiledTileset()
        {

        }

        /// <summary>
        /// Loads a tileset in TSX format and parses it
        /// </summary>
        /// <param name="path">The file path of the TSX file</param>
        /// <exception cref="TiledException">Thrown when the file could not be found or parsed</exception>
        public TiledTileset(string path)
        {
            // Check the file
            if (!File.Exists(path))
            {
                throw new TiledException($"{path} not found");
            }
            
            if (path.EndsWith(".tsx")) { 
                throw new TiledException("Unsupported file format");
            }

            var content = File.ReadAllText(path);
            ParseXml(content);
        }

        /// <summary>
        /// Can be used to parse the content of a TSX tileset manually instead of loading it using the constructor
        /// </summary>
        /// <param name="xml">The tmx file content as string</param>
        /// <exception cref="TiledException"></exception>
        public void ParseXml(string xml)
        {
            try
            {
                var document = new XmlDocument();
                document.LoadXml(xml);

                var nodeTileset = document.SelectSingleNode("tileset");
                var nodeImage = nodeTileset.SelectSingleNode("image");
                var nodesTile = nodeTileset.SelectNodes("tile");
                var nodesProperty = nodeTileset.SelectNodes("properties/property");
                var nodesTerrain = nodeTileset.SelectNodes("terraintypes/terrain");

                TiledVersion = nodeTileset.Attributes["tiledversion"].Value;
                Name = nodeTileset.Attributes["name"]?.Value;
                TileWidth = int.Parse(nodeTileset.Attributes["tilewidth"].Value);
                TileHeight = int.Parse(nodeTileset.Attributes["tileheight"].Value);
                TileCount = int.Parse(nodeTileset.Attributes["tilecount"].Value);
                Columns = int.Parse(nodeTileset.Attributes["columns"].Value);

                if (nodeTileset.Attributes["margin"] != null)
                {
                    Margin = int.Parse(nodeTileset.Attributes["margin"].Value);
                }
                if (nodeTileset.Attributes["spacing"] != null)
                {
                    Spacing = int.Parse(nodeTileset.Attributes["spacing"].Value);
                }

                if (nodeImage != null)
                {
                    Image = nodeImage.Attributes["source"].Value;
                    ImageWidth = int.Parse(nodeImage.Attributes["width"].Value);
                    ImageHeight = int.Parse(nodeImage.Attributes["height"].Value);
                }

                Tiles = ParseTiles(nodesTile);
                Properties = ParseProperties(nodesProperty).ToArray();
                Terrains = ParseTerrains(nodesTerrain);
            }
            catch (Exception ex)
            {
                throw new TiledException("Unable to parse xml data, make sure the xml data represents a valid Tiled tileset", ex);
            }
        }

        private IEnumerable<TiledTileAnimation> ParseAnimations(XmlNodeList nodeList)
        {
            var result = new List<TiledTileAnimation>(nodeList.Count);

            foreach (XmlNode node in nodeList)
            {
                var tileid = int.Parse(node.Attributes["tileid"].Value);
                var duration = TimeSpan.FromMilliseconds(int.Parse(node.Attributes["duration"].Value));
                
                var animation = new TiledTileAnimation(tileid, duration);
                result.Add(animation);
            }
            
            return result;
        }

        private IEnumerable<TiledProperty> ParseProperties(XmlNodeList nodeList)
        {
            var result = new List<TiledProperty>(nodeList.Count);

            foreach (XmlNode node in nodeList)
            {
                var name = node.Attributes["name"].Value;
                var type = node.Attributes["type"]?.Value;
                var value = node.Attributes["value"]?.Value;

                if (value == null && node.InnerText != null)
                {
                    value = node.InnerText;
                }

                var property = new TiledProperty(name, type, value);

                result.Add(property);
            }

            return result;
        }

        private TiledTile[] ParseTiles(XmlNodeList nodeList)
        {
            var result = new List<TiledTile>(nodeList.Count);

            foreach (XmlNode node in nodeList)
            {
                var nodesProperty = node.SelectNodes("properties/property");
                var nodesAnimation = node.SelectNodes("animation/frame");
                var nodeImage = node.SelectSingleNode("image");

                var tile = new TiledTile()
                {
                    Id = int.Parse(node.Attributes["id"].Value),
                    Terrain = node.Attributes["terrain"]?.Value.Split(',').AsIntArray(),
                    Animations = ParseAnimations(nodesAnimation),
                    Properties = ParseProperties(nodesProperty)
                };
                
                if (nodeImage != null)
                {
                    tile.Image = new TiledTileImage()
                    {
                        Width = int.Parse(nodeImage.Attributes["width"].Value),
                        Height = int.Parse(nodeImage.Attributes["height"].Value),
                        Source = nodeImage.Attributes["source"].Value
                    };
                }

                result.Add(tile);
            }

            return result.ToArray();
        }

        private List<TiledTerrain> ParseTerrains(XmlNodeList nodeList)
        {
            var result = new List<TiledTerrain>(nodeList.Count);

            foreach (XmlNode node in nodeList)
            {
                var name = node.Attributes["name"].Value;
                var tile = int.Parse(node.Attributes["tile"].Value);
                
                var terrain = new TiledTerrain(name, tile);

                result.Add(terrain);
            }

            return result;
        }
    }
}