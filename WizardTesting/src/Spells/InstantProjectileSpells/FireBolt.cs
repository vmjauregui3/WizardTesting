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
        public FireBolt(Creature owner) : base(owner, 5f, "Sprites/Projectiles/FireBolt", 3f, 10000, 600f, 10f)
        {

        }
    }
}
