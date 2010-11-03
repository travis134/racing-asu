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
using cruisin_asu.Helpers;

namespace cruisin_asu.GameObjects {

    class PlayerGameObject: MovingGameObject {
        private Controller controller;

        public PlayerGameObject(String texturePath, Vector2 position, Controller controller): base(texturePath, position) {
            this.controller = controller;
            this.speed = 1;
        }

        public override void Update(GameTime gameTime) {

            if (controller.controlState[Controls.Up]) {
                direction.Y = -1;
            } else if (controller.controlState[Controls.Down]) {
                direction.Y = 1;
            } else {
                direction.Y = 0;
            }

            if (controller.controlState[Controls.Left]) {
                direction.X = -1;
            } else if (controller.controlState[Controls.Right]) {
                direction.X = 1;
            } else {
                direction.X = 0;
            }

            if (controller.controlState[Controls.SpeedUp]) {
                speed = 3;
            } else {
                speed = 1;
            }

            base.Update(gameTime);
        }

    }
}
