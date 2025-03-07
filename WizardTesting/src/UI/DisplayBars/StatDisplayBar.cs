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
            
        }

        public virtual void Update(VariableStat stat, Vector2 reference)
        {
            base.Update(stat.Value, stat.ValueMax, reference);
        }
    }
}
