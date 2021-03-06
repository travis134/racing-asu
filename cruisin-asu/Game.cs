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
using cruisin_asu.Map;

namespace cruisin_asu {

    public class Game: Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Controller controller2;
        Controller controller;
        PlayerGameObject player;
        PlayerGameObject player2;
        GameObject map;
        GameObject realMap;
        


        public Game() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {
            #if !XBOX
                controller = new Controller(ControllerType.PC);
            #else
                controller = new Controller(ControllerType.Xbox360);
            #endif 

#if !XBOX
                controller2 = new Controller(ControllerType.PC2);
#else
                controller2 = new Controller(ControllerType.Xbox360);
#endif 

            player = new PlayerGameObject("player", new Vector2(0, 0),controller);
            player.zindex = 0.9f;

            player2 = new PlayerGameObject("player", new Vector2(120, 120), controller2);
            player2.zindex = 0.9f;

            map = new GameObject("map", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2));
            map.zindex = 0.2f;

            realMap = new GameObject("realmap", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2));
            map.zindex = 0.4f;

            base.Initialize();
        }

        protected override void LoadContent() {
            player2.LoadContent(Content);
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
            if (GameObject.IntersectPixels(player2.futureRectangle, player2.textureData, map.rectangle, map.textureData))
            {
                player2.moving = false;
            }
            else
            {
                player2.moving = true;
            }

            controller2.Update(gameTime);
            player2.Update(gameTime);



            map.Update(gameTime);
            realMap.Update(gameTime);

            if (controller.controlState[Controls.Exit]) {
                this.Exit();
            }

            Console.Out.WriteLine(Map.Map.VectorToPoint(player.position).ToString());

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.FrontToBack, SaveStateMode.None);
            realMap.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
