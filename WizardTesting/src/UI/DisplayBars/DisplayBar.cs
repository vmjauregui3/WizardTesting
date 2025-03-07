using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class DisplayBar
    {
        protected int border;

        // This Vector2 is the fixed offset from the bar's moving reference point
        protected Vector2 barBackOffset;
        // This Vector2 is the fixed offset of the colored bar from the back of the bar
        protected Vector2 barOffset;

        public Sprite bar, barBack;

        public DisplayBar(Vector2 dims, int border, Color color, Vector2 offset)
        {
            this.border = border;
            barBackOffset = offset;
            barOffset = new Vector2(border, border);

            bar = new Sprite("Sprites/SolidBar", Vector2.Zero, new Vector2(dims.X - border * 2, dims.Y - border * 2), Vector2.Zero)
            {
                Tint = color
            };
            barBack = new Sprite("Sprites/BarBackground", Vector2.Zero, new Vector2(dims.X, dims.Y), Vector2.Zero)
            {
                Tint = Color.Black
            };
        }


        public virtual void Update(float currentVal, float maxVal, Vector2 reference)
        {
            bar.Dimensions = new Vector2((currentVal / maxVal) * (barBack.Dimensions.X - border * 2), bar.Dimensions.Y);
            barBack.Position = reference + barBackOffset;
            bar.Position = barBack.Position + barOffset;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            barBack.Draw(spriteBatch);
            bar.Draw(spriteBatch);
        }
    }
}
