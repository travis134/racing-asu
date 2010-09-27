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

namespace cruisin_asu.Helpers
{
    class Controller
    {

        private ControllerType controllerType;
        public Dictionary<Controls, bool> controlState;
        public Dictionary<Keys, Controls> keyboardControlScheme;
        private KeyboardState keyboardState;

        public Controller(ControllerType controllerType)
        {
            this.controllerType = controllerType;

            this.keyboardControlScheme = new Dictionary<Keys, Controls>();
            this.keyboardControlScheme.Add(Keys.Up, Controls.Up);
            this.keyboardControlScheme.Add(Keys.Down, Controls.Down);
            this.keyboardControlScheme.Add(Keys.Left, Controls.Left);
            this.keyboardControlScheme.Add(Keys.Right, Controls.Right);
            
            this.controlState = new Dictionary<Controls, bool>();
            this.controlState.Add(Controls.Up, false);
            this.controlState.Add(Controls.Down, false);
            this.controlState.Add(Controls.Left, false);
            this.controlState.Add(Controls.Right, false);  
        }

        public void Update(GameTime gameTime)
        {
            switch (controllerType)
            {
                case ControllerType.PC:
                    this.KeyboardUpdate();                    
                    break;
                case ControllerType.SilverLight:
                    throw new NotImplementedException();
                    //TODO: Implement Silverlight specific controls
                    break;
                case ControllerType.Xbox360:
                    throw new NotImplementedException();
                    //TODO: Implement Xbox360 specific controls
                    break;
            }
        }

        private void KeyboardUpdate()
        {
            keyboardState = Keyboard.GetState();
            foreach(Keys key in keyboardState.GetPressedKeys())
            {
                if(keyboardControlScheme.ContainsKey(key))
                {
                    Controls control = keyboardControlScheme[key];
                    if (controlState.ContainsKey(control))
                    {
                        controlState[control] = true;
                    }
                }
            }
            foreach(Keys key in keyboardControlScheme.Keys)
            {
                if (keyboardState.IsKeyUp(key))
                {
                    Controls control = keyboardControlScheme[key];
                    if (controlState.ContainsKey(control))
                    {
                        controlState[control] = false;
                    }
                }
            }
        }

    }
}
