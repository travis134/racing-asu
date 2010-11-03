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
    class GameObject {
        public String texturePath;
        public Texture2D texture;
        public Vector2 position;
        public Rectangle rectangle;
        public Color tintColor;
        public Boolean visible;
        public float zindex;
        public float rotation;
        public float scale;
        public Color[] textureData;

        public GameObject(String texturePath, Vector2 position) {
            this.texturePath = texturePath;
            this.position = position;
            this.tintColor = Color.White;
            this.visible = true;
            this.zindex = 0.0f;
            this.rotation = 0f;
            this.scale = 1.0f;
        }

        public virtual void LoadContent(ContentManager content) {
            this.texture = content.Load<Texture2D>(texturePath);
            this.rectangle = new Rectangle((int)position.X - texture.Width / 2, (int)position.Y - texture.Height / 2, texture.Width, texture.Height);
            this.textureData = new Color[texture.Width * texture.Height];
            this.texture.GetData(this.textureData);
        }

        public virtual void Update(GameTime gameTime) {

        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            if (this.visible) {
                spriteBatch.Draw(this.texture, this.position, null, 
                    this.tintColor, this.rotation, new Vector2(texture.Width / 2, texture.Height / 2), 
                    this.scale, SpriteEffects.None, this.zindex);
            }
        }

        public static bool IntersectPixels(Rectangle rectangleA, Color[] dataA, Rectangle rectangleB, Color[] dataB) {
            // Find the bounds of the rectangle intersection
            int top = Math.Max(rectangleA.Top, rectangleB.Top);
            int bottom = Math.Min(rectangleA.Bottom, rectangleB.Bottom);
            int left = Math.Max(rectangleA.Left, rectangleB.Left);
            int right = Math.Min(rectangleA.Right, rectangleB.Right);

            // Check every point within the intersection bounds
            for (int y = top; y < bottom; y++) {
                for (int x = left; x < right; x++) {
                    // Get the color of both pixels at this point
                    Color colorA = dataA[(x - rectangleA.Left) + (y - rectangleA.Top) * rectangleA.Width];
                    Color colorB = dataB[(x - rectangleB.Left) + (y - rectangleB.Top) * rectangleB.Width];

                    // If both pixels are not completely transparent,
                    if (colorA.A != 0 && colorB.A != 0) {
                        // then an intersection has been found
                        return true;
                    }
                }
            }

            // No intersection found
            return false;
        }

    }

}
