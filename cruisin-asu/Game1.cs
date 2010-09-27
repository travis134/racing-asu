using System;
using System.Collections.Generic;
using System.Linq;
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
using cruisin_asu.GameObjects;

namespace cruisin_asu {

    public class Game1: Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Controller controller;
        PlayerGameObject player;
        GameObject map;
        GameObject realMap;


        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {
            #if !XBOX
                controller = new Controller(ControllerType.PC);
            #else
                controller = new Controller(ControllerType.Xbox360);
            #endif

            player = new PlayerGameObject("player", new Vector2(0, 0),controller);
            player.zindex = 0.9f;

            map = new GameObject("map", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2));
            map.zindex = 0.2f;

            realMap = new GameObject("realmap", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2));
            map.zindex = 0.4f;

            base.Initialize();
        }

        protected override void LoadContent() {
            player.LoadContent(Content);
            map.LoadContent(Content);
            realMap.LoadContent(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent() {

        }

        protected override void Update(GameTime gameTime) {

            if (GameObject.IntersectPixels(player.futureRectangle, player.textureData, map.rectangle, map.textureData)) {
                player.moving = false;
            } else {
                player.moving = true;
            }

            controller.Update(gameTime);
            player.Update(gameTime);
            map.Update(gameTime);
            realMap.Update(gameTime);

            if (controller.controlState[Controls.Exit]) {
                this.Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.FrontToBack, SaveStateMode.None);
            realMap.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
