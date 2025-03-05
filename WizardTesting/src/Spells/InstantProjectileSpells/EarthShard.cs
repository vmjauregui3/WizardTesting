using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class EarthShard : InstantProjectileSpell
    {
        public EarthShard(Creature owner) : base(owner, 40, "Sprites/Projectiles/EarthShard", 3f, 10000, 400f, 10)
        {

        }

        public EarthShard(Creature owner, int level, int exp) : base(owner, 40, "Sprites/Projectiles/EarthShard", 3f, 10000, 400f, level, exp, 10)
        {

        }
    }
}
