using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class IceSpike : Spell
    {
        protected string path;
        protected float spriteScale;

        protected int duration;
        public int Duration
        {
            get { return duration; }
        }
        protected float speed;
        public float Speed
        {
            get { return speed; }
        }

        public Vector2 Target;

        // FireBolts are defualt projectiles currently used for testing.
        public IceSpike(Creature owner) : base(owner, 60, 50, 50)
        {
            path = "Sprites/Projectiles/FireBolt";
            spriteScale = 3f;
            duration = 10000;
            speed = 800f;
            damage = 10;
        }

        public IceSpike(Creature owner, int level, int exp) : base(owner, 60, 50, 50, level, exp)
        {
            path = "Sprites/Projectiles/IceSpike";
            spriteScale = 3f;
            duration = 10000;
            speed = 800f;
            damage = 10;
        }

        public override void QuickCast(Vector2 target)
        {
            Target = target;
            base.QuickCast(target);
        }

        public override void CastEffect()
        {
            GameCommands.PassProjectile(new Projectile(path, spriteScale, new Vector2(owner.Sprite.Position.X, owner.Sprite.Position.Y), this, Target, duration, speed, damage));
        }
    }
}
