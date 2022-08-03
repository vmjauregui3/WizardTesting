using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class FireBolt : Projectile
    {
        public FireBolt(string path, Vector2 position, Creature owner, Vector2 target) : base(path, position, owner, target)
        {
            Sprite.Scale = 3f;
            Speed = 600f;
            Timer = new MTimer(10000);
        }

        public override void Update(GameTime gameTime, List<Creature> creatures)
        {
            base.Update(gameTime, creatures);
        }
    }
}
