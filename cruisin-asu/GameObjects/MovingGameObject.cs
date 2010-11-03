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

namespace cruisin_asu.GameObjects {
    class MovingGameObject: GameObject {
        public Vector2 futurePosition;
        public Rectangle futureRectangle;
        public Vector2 direction;
        public float speed;
        public Boolean moving;

        public MovingGameObject(String texturePath, Vector2 position): base(texturePath, position) {
            this.direction = Vector2.Zero;
            this.speed = 1;
        }

        public MovingGameObject(String texturePath, Vector2 position, Vector2 direction): base(texturePath, position) {
            this.direction = direction;
            this.speed = 1;
        }

        public MovingGameObject(String texturePath, Vector2 position, Vector2 direction, float speed): base(texturePath, position) {
            this.direction = direction;
            this.speed = speed;
        }

        public override void LoadContent(ContentManager content) {
            base.LoadContent(content);
            futureRectangle = rectangle;
        }

        public override void Update(GameTime gameTime) {

            if (this.direction != Vector2.Zero) {
                this.direction.Normalize();

                if (this.moving) {
                    this.position += this.direction * speed;
                    this.rectangle.X = (int)position.X - texture.Width / 2;
                    this.rectangle.Y = (int)position.Y - texture.Height / 2;
                }

                this.futurePosition = this.position + (2 * (this.direction * speed));
                this.futureRectangle.X = (int)futurePosition.X - texture.Width / 2;
                this.futureRectangle.Y = (int)futurePosition.Y - texture.Height / 2;
                this.rotation = (float)Math.Atan2(direction.Y, direction.X);
                //TODO: Generate new bounding rectangle that corresponds with the roatation
            }

        }

    }
}
