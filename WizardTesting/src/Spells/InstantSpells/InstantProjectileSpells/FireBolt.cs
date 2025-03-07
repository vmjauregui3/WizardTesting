using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class FireBolt : InstantProjectileSpell
    {
        // FireBolts are defualt projectiles currently used for testing.
        public FireBolt(Creature owner) : base(owner, 50, "Sprites/Projectiles/FireBolt", 3f, 10000, 600f, 10)
        {

        }
        
        public FireBolt(Creature owner, int level, int exp) : base(owner, 50, "Sprites/Projectiles/FireBolt", 3f, 10000, 600f, 10, level, exp)
        {

        }
    }
}
