﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroid_2._0
{
    public static class Input
    {
        private static KeyboardState KS, oldKS;
        private static MouseState MS, oldMS;
        private static Point mousePoint;
        private static Vector2 mousePosition;

        private static KeyboardState writingKS, writingOldKS;

        private static Keys[] pressedKeys;

        public static void Update()
        {
            oldKS = KS;
            oldMS = MS;

            mousePoint.X = Mouse.GetState().X;
            mousePoint.Y = Mouse.GetState().Y;
            mousePosition.X = Mouse.GetState().X;
            mousePosition.Y = Mouse.GetState().Y;

            pressedKeys = Keyboard.GetState().GetPressedKeys();

            MS = Mouse.GetState();
            KS = Keyboard.GetState();
        }

        public static Keys[] PressedKeys()
        {
            int lastKeyPressed = pressedKeys.Length - 1;

            //if(pressedKeys[lastKeyPressed] = "retun")



            return pressedKeys;
        }

        public static void DrawPressedKeys(SpriteBatch spriteBatch, Vector2 Position)
        {
            if (pressedKeys == null)
                return;

            Keys lastKey;
            Keys currKey;

            try
            {
                for (int i = 0; i < pressedKeys.Length; i++)
                {
                    if (pressedKeys.Length > 1)
                    {
                        lastKey = pressedKeys[i--];
                        spriteBatch.DrawString(Textures.font, pressedKeys[i].ToString(), new Vector2(Position.X + Textures.font.MeasureString(lastKey.ToString()).X, Position.Y), Color.White);

                    }
                    else
                    {
                        currKey = pressedKeys[i];
                        spriteBatch.DrawString(Textures.font, pressedKeys[i].ToString(), new Vector2(Position.X + Textures.font.MeasureString(currKey.ToString()).X, Position.Y), Color.White);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        public static bool LeftClick()
        {
            return MS.LeftButton == ButtonState.Pressed && oldMS.LeftButton == ButtonState.Released;
        }

        public static bool RightClick()
        {
            return MS.RightButton == ButtonState.Pressed && oldMS.RightButton == ButtonState.Released;
        }

        public static bool Clicked(Keys key)
        {
            return KS.IsKeyDown(key) && oldKS.IsKeyUp(key);
        }

        public static bool Holding(Keys key)
        {
            return KS.IsKeyDown(key);
        }

        public static Point MousePoint()
        {
            return mousePoint;
        }

        public static Vector2 MousePosition()
        {
            return mousePosition;
        }

        public static bool HoldingLeft()
        {
            return MS.LeftButton == ButtonState.Pressed;
        }

        public static bool HoldingRight()
        {
            return MS.RightButton == ButtonState.Pressed;
        }
    }
}
