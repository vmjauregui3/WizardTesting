using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class StatDisplayBar : DisplayBar
    {
        public StatDisplayBar(Vector2 dims, int border, Color color, Vector2 offset) : base(dims, border, color, offset)
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

        public virtual void Update(VariableStat stat, Vector2 reference)
        {
            base.Update(stat.Value, stat.ValueMax, reference);
        }
    }
}
