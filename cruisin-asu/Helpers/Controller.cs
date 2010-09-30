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

namespace cruisin_asu.Helpers {

    class Controller {

        private ControllerType controllerType;
        public Dictionary<Controls, bool> controlState;
        public Dictionary<Keys, Controls> keyboardControlScheme;
        public Dictionary<Buttons, Controls> xbox360ControlScheme;
        private KeyboardState keyboardState;
        private GamePadState gamePadState;

        public Controller(ControllerType controllerType) {
            this.controllerType = controllerType;

            switch (controllerType) {
                case ControllerType.PC:
                    this.keyboardControlScheme = new Dictionary<Keys, Controls>();
                    this.keyboardControlScheme.Add(Keys.Up, Controls.Up);
                    this.keyboardControlScheme.Add(Keys.Down, Controls.Down);
                    this.keyboardControlScheme.Add(Keys.Left, Controls.Left);
                    this.keyboardControlScheme.Add(Keys.Right, Controls.Right);
                    this.keyboardControlScheme.Add(Keys.Escape, Controls.Exit);
                    this.keyboardControlScheme.Add(Keys.Space, Controls.SpeedUp);
                    break;
                case ControllerType.PC2:
                    this.keyboardControlScheme = new Dictionary<Keys, Controls>();
                    this.keyboardControlScheme.Add(Keys.W, Controls.Up);
                    this.keyboardControlScheme.Add(Keys.S, Controls.Down);
                    this.keyboardControlScheme.Add(Keys.A, Controls.Left);
                    this.keyboardControlScheme.Add(Keys.D, Controls.Right);
                    this.keyboardControlScheme.Add(Keys.Escape, Controls.Exit);
                    this.keyboardControlScheme.Add(Keys.Z, Controls.SpeedUp);
                    break;
                case ControllerType.Xbox360:
                    this.xbox360ControlScheme = new Dictionary<Buttons, Controls>();
                    this.xbox360ControlScheme.Add(Buttons.DPadUp, Controls.Up);
                    this.xbox360ControlScheme.Add(Buttons.DPadDown, Controls.Down);
                    this.xbox360ControlScheme.Add(Buttons.DPadLeft, Controls.Left);
                    this.xbox360ControlScheme.Add(Buttons.DPadRight, Controls.Right);
                    this.xbox360ControlScheme.Add(Buttons.Back, Controls.Exit);
                    this.xbox360ControlScheme.Add(Buttons.RightTrigger, Controls.SpeedUp);
                    break;
            }

            this.controlState = new Dictionary<Controls, bool>();
            this.controlState.Add(Controls.Up, false);
            this.controlState.Add(Controls.Down, false);
            this.controlState.Add(Controls.Left, false);
            this.controlState.Add(Controls.Right, false);
            this.controlState.Add(Controls.Exit, false);
            this.controlState.Add(Controls.SpeedUp, false);
        }

        public void Update(GameTime gameTime) {
            switch (controllerType) {
                case ControllerType.PC:
                    this.KeyboardUpdate();
                    break;
                case ControllerType.PC2:
                    this.KeyboardUpdate();
                    break;
                case ControllerType.SilverLight:
                    throw new NotImplementedException();
                    //TODO: Implement Silverlight specific controls
                    break;
                case ControllerType.Xbox360:
                    this.Xbox360Update();
                    break;
            }
        }

        private void KeyboardUpdate() {
            keyboardState = Keyboard.GetState();
            foreach (Keys key in keyboardControlScheme.Keys) {
                if (keyboardState.IsKeyDown(key)) {
                    Controls control = keyboardControlScheme[key];
                    if (controlState.ContainsKey(control)) {
                        controlState[control] = true;
                    }
                } else if (keyboardState.IsKeyUp(key)) {
                    Controls control = keyboardControlScheme[key];
                    if (controlState.ContainsKey(control)) {
                        controlState[control] = false;
                    }
                }
            }
        }

        private void Xbox360Update() {
            gamePadState = GamePad.GetState(PlayerIndex.One);
            foreach (Buttons button in xbox360ControlScheme.Keys) {
                if (gamePadState.IsButtonDown(button)) {
                    Controls control = xbox360ControlScheme[button];
                    if (controlState.ContainsKey(control)) {
                        controlState[control] = true;
                    }
                } else if (gamePadState.IsButtonUp(button)) {
                    Controls control = xbox360ControlScheme[button];
                    if (controlState.ContainsKey(control)) {
                        controlState[control] = false;
                    }
                }
            }
        }

    }
}
