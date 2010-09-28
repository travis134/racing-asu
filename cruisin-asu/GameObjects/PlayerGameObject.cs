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
                velocity.Y = -1;
            } else if (controller.controlState[Controls.Down]) {
                velocity.Y = 1;
            } else {
                velocity.Y = 0;
            }

            if (controller.controlState[Controls.Left]) {
                velocity.X = -1;
            } else if (controller.controlState[Controls.Right]) {
                velocity.X = 1;
            } else {
                velocity.X = 0;
            }

            if (controller.controlState[Controls.SpeedUp])
            {
                speed = 3;
            }
            else
            {
                speed = 1;
            }

            base.Update(gameTime);
        }

    }
}
