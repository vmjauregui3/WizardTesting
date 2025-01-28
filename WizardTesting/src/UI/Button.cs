using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WizardTesting
{
    public class Button : Sprite
    {
        protected bool isHovered, isPressed;
        protected string text;

        protected Color color, hoverColor, pressedColor;

        protected SpriteFont font;

        public object info;

        PassObject ButtonClicked;

        public Button(string path, Vector2 position, Vector2 dimensions, string fontPath, string text, PassObject ButtonClicked, object info)
            : base(path, position, dimensions, Vector2.Zero)
        {
            this.text = text;
            this.ButtonClicked = ButtonClicked;
            this.info = info;

            if (fontPath != "")
            {
                font = WizardTesting.WContent.Load<SpriteFont>("Fonts/ComicSansMS16");
            }

            isPressed = false;
            hoverColor = new Color(200, 230, 255);
        }

        public override void Update()
        {
            if (Hover())
            {
                isHovered = true;
                if (MCursor.Instance.LeftClick())
                {
                    isHovered = false;
                    isPressed = true;
                }
                else if (MCursor.Instance.LeftClickRelease())
                {
                    RunButtonClick();
                }
            }
            else
            {
                isHovered = false;
                Tint = Color.White;
            }

            if (!MCursor.Instance.LeftClick() && !MCursor.Instance.LeftClickRelease())
            {
                isPressed = false;
            }

            if (isPressed)
            {
                Tint = Color.Gray;
            }
            else if (isHovered)
            {
                Tint = hoverColor;
            }
        }

        public void Reset()
        {
            isHovered = false;
            isPressed = false;
            Tint = Color.White;
        }

        public virtual void RunButtonClick()
        {
            if (ButtonClicked != null)
            {
                ButtonClicked(info);
            }

            Reset();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            Vector2 stringDimensions = font.MeasureString(text);
            spriteBatch.DrawString(font, text, Position + new Vector2(stringDimensions.X / 2, stringDimensions.Y / 2), Color.Black);
        }
    }
}
