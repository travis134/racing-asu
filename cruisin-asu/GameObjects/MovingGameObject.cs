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

namespace cruisin_asu.GameObjects
{
    class MovingGameObject : GameObject
    {

        public Vector2 velocity;
        public float speed;

        public MovingGameObject(String texturePath, Vector2 position)
            : base(texturePath, position)
        {
            this.velocity = Vector2.Zero;
            this.speed = 1;
        }

        public MovingGameObject(String texturePath, Vector2 position, Vector2 velocity)
            : base(texturePath, position)
        {
            this.velocity = velocity;
            this.speed = 1;
        }

        public MovingGameObject(String texturePath, Vector2 position, Vector2 velocity, float speed)
            : base(texturePath, position)
        {
            this.velocity = velocity;
            this.speed = speed;
        }

        public override void Update(GameTime gameTime)
        {
            if (this.velocity != Vector2.Zero)
            {
                this.velocity.Normalize();
                this.position += this.velocity * speed;
                this.rectangle.X = (int)position.X - texture.Width / 2;
                this.rectangle.Y = (int)position.Y - texture.Height / 2;
                this.rotation = (float)Math.Atan2(velocity.Y, velocity.X);
                //TODO: Generate new bounding rectangle that corresponds with the roatation
            }
           
        }
 
    }
}
