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
    class GameObject
    {
        public String texturePath;
        public Texture2D texture;
        public Vector2 position;
        public Rectangle rectangle;
        public Color tintColor;
        public Boolean visible;
        public float zindex;
        public float rotation;
        public float scale;

        public GameObject(String texturePath, Vector2 position)
        {
            this.texturePath = texturePath;
            this.position = position;
            this.tintColor = Color.White;
            this.visible = true;
            this.zindex = 0.0f;
            this.rotation = 0f;
            this.scale = 1.0f;
        }

        public virtual void LoadContent(ContentManager content)
        {
            this.texture = content.Load<Texture2D>(texturePath);
            this.rectangle = new Rectangle(
                (int)position.X - texture.Width/2,
                (int)position.Y - texture.Height/2, 
                texture.Width, 
                texture.Height
                );
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (this.visible)
            {
                spriteBatch.Draw(this.texture, this.position, null, this.tintColor, this.rotation, new Vector2(texture.Width/2, texture.Height/2), this.scale, SpriteEffects.None, this.zindex);
            }
        }
    }
}
