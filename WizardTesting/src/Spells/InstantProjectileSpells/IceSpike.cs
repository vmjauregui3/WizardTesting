using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class IceSpike : InstantProjectileSpell
    {

        public IceSpike(Creature owner) : base(owner, 60, "Sprites/Projectiles/IceSpike", 3f, 10000, 800f, 10)
        {

        }

        public IceSpike(Creature owner, int level, int exp) : base(owner, 60, "Sprites/Projectiles/IceSpike", 3f, 10000, 800f, level, exp, 10)
        {

        }

    }
}
