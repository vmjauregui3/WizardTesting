using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class LightBeam : Projectile
    {
        // FireBolts are defualt projectiles currently used for testing.
        public LightBeam(Vector2 position, Spell ownerSpell, Vector2 target) : base("Sprites/Projectiles/LightBeam", 3f, position, ownerSpell, target, 10000, 600f, 10f)
        {
        }

        // Updates the Projectile.
        public override void Update(GameTime gameTime, List<Destructible> destructibles)
        {
            base.Update(gameTime, destructibles);
        }
    }
}
