using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class IceSpike : InstantProjectileSpell
    {
        // FireBolts are defualt projectiles currently used for testing.
        public IceSpike(Creature owner) : base(owner, 6f, "Sprites/Projectiles/IceSpike", 3f, 10000, 800f, 10f)
        {

        }
    }
}
