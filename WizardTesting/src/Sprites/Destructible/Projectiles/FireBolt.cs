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
        public FireBolt(string path, Vector2 position, Creature owner, Vector2 target) : base(path, position, owner, target)
        {
            Sprite.Scale = 3f;
            Speed = 600f;
            Timer = new MTimer(10000);
        }

        // Updates the Projectile.
        public override void Update(GameTime gameTime, List<Destructible> destructibles)
        {
            base.Update(gameTime, destructibles);
        }
    }
}
