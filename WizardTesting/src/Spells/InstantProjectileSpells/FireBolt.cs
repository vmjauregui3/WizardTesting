using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class FireBolt : Spell
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
        public FireBolt(Creature owner) : base(owner, 50, 50, 50)
        {
            //manaCost = 50;
            path = "Sprites/Projectiles/FireBolt";
            spriteScale = 3f;
            duration = 10000;
            speed = 600f;
            damage = 10;
        }
        
        public FireBolt(Creature owner, int level, int exp) : base(owner, 50, 50, 50, level, exp)
        {
            path = "Sprites/Projectiles/FireBolt";
            spriteScale = 3f;
            duration = 10000;
            speed = 600f;
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
