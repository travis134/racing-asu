using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cruisin_asu.Map {
    class Tile {
        public bool pathable;
        public TileType type;

        public Tile(bool pathable, TileType type) {
            this.pathable = pathable;
            this.type = type;
        }
    }
}
