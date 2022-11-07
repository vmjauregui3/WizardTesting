using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class EarthShard : InstantProjectileSpell
    {
        // FireBolts are defualt projectiles currently used for testing.
        public EarthShard(Creature owner) : base(owner, 4f, "Sprites/Projectiles/EarthShard", 3f, 10000, 400f, 10f)
        {

        }
    }
}
