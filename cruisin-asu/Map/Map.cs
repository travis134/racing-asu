using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace cruisin_asu.Map {
    class Map {

        public static Vector2 TileSize;
        public List<Layer> MapInfo;

        public Map(List<Layer> MapInfo,Vector2 TileSize) {
            this.MapInfo = MapInfo;
            Map.TileSize = TileSize;
        }

        public bool IsPathable(Vector2 position) {
            Point where = Map.VectorToPoint(position);
            if (where.X <= MapInfo[0].LayerInfo.Length && where.Y <= MapInfo[0].LayerInfo[0].Length) {
                return (MapInfo[0].LayerInfo[where.X][where.Y].pathable);
            } else {
                return false;
            }
        }

        public bool IsPathable(Point position) {
            if (position.X <= MapInfo[0].LayerInfo.Length && position.Y <= MapInfo[0].LayerInfo[0].Length) {
                return (MapInfo[0].LayerInfo[position.X][position.Y].pathable);
            } else {
                return false;
            }
        }

        public TileType GetTileType(Vector2 position) {
            Point where = Map.VectorToPoint(position);
            if (where.X <= MapInfo[0].LayerInfo.Length && where.Y <= MapInfo[0].LayerInfo[0].Length) {
                return MapInfo[0].LayerInfo[where.X][where.Y].type;
            } else {
                return TileType.WHOKNOWS;
            }
        }

        public TileType GetTileType(Point position) {
            if (position.X <= MapInfo[0].LayerInfo.Length && position.Y <= MapInfo[0].LayerInfo[0].Length) {
                return MapInfo[0].LayerInfo[position.X][position.Y].type;
            } else {
                return TileType.WHOKNOWS;
            }
        }

        public static Point VectorToPoint(Vector2 position) {
            return (new Point((int)(position.X / Map.TileSize.X),(int)(position.Y / Map.TileSize.Y)));
        }


    }
}
