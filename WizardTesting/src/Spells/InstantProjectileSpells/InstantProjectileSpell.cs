using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class InstantProjectileSpell : Spell
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

        public InstantProjectileSpell(Creature owner, int manaCost, string path, float spriteScale, int duration, float speed, int damage) : base(owner, manaCost, 50, 50)
        {
            this.path = path;
            this.spriteScale = spriteScale;
            this.duration = duration;
            this.speed = speed;
            this.damage = damage;
        }

        public InstantProjectileSpell(Creature owner, int manaCost, string path, float spriteScale, int duration, float speed, int level, int exp, int damage) : base(owner, manaCost, 50, 50, level, exp)
        {
            this.path = path;
            this.spriteScale = spriteScale;
            this.duration = duration;
            this.speed = speed;
            this.damage = damage;
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
