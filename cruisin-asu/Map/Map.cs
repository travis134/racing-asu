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
            return !(MapInfo[0].LayerInfo[where.X][where.Y] == Tile.BUILDING);
        }

        public static Point VectorToPoint(Vector2 position) {
            return (new Point((int)(position.X / Map.TileSize.X),(int)(position.Y / Map.TileSize.Y)));
        }


    }
}
