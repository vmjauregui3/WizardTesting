using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class FireBolt : Projectile
    {
        // FireBolts are defualt projectiles currently used for testing.
        public FireBolt(Vector2 position, Creature owner, Vector2 target) : base("Sprites/Projectiles/FireBolt", 3f, position, owner, target, 1000, 600f, 10f)
        {
            Timer = new MTimer(10000);
        }

        // Updates the Projectile.
        public override void Update(GameTime gameTime, List<Destructible> destructibles)
        {
            base.Update(gameTime, destructibles);
        }
    }
}
