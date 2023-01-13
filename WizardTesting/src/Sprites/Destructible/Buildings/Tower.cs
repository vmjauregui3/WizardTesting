using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class Tower : Building
    {
        // 
        public Tower(Vector2 position, int ownerId) : base("Sprites/Buildings/Tower", position, 2f, new Vector2(1, 1), 0, ownerId)
        {
            healthMax = 50;
            health = healthMax;
        }
    }
}
