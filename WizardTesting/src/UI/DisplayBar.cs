using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class DisplayBar
    {
        private int border;

        // This Vector2 is the fixed offset from the bar's moving reference point
        private Vector2 barBackOffset;

        public Sprite bar, barBack;

        public DisplayBar(Vector2 dims, int border, Color color, Vector2 location)
        {
            this.border = border;

            bar = new Sprite("Sprites/SolidBar", Vector2.Zero, new Vector2(dims.X - border*2, dims.Y - border*2), Vector2.Zero);
            bar.Tint = color;
            barBack = new Sprite("Sprites/BarBackground", Vector2.Zero, new Vector2(dims.X, dims.Y), Vector2.Zero);
            barBack.Tint = Color.Black;

            barBackOffset = new Vector2(location.X, location.Y + (int)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - barBack.Dimensions.Y);
        }


        public virtual void Update(float currentVal, float maxVal, Vector2 reference)
        {
            bar.Dimensions = new Vector2((currentVal / maxVal) * (barBack.Dimensions.X - border * 2), bar.Dimensions.Y);
            barBack.Position = reference + barBackOffset;
            bar.Position = new Vector2(border, border) + barBack.Position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            barBack.Draw(spriteBatch);
            bar.Draw(spriteBatch);
        }
    }
}
