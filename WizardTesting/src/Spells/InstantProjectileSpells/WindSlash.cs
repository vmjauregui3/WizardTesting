using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class WindSlash : InstantProjectileSpell
    {
        // FireBolts are defualt projectiles currently used for testing.
        public WindSlash(Creature owner) : base(owner, 30, "Sprites/Projectiles/WindSlash", 3f, 10000, 800f, 5)
        {

        }

        public WindSlash(Creature owner, int level, int exp) : base(owner, 30, "Sprites/Projectiles/WindSlash", 3f, 10000, 800f, level, exp, 5)
        {

        }
    }
}
