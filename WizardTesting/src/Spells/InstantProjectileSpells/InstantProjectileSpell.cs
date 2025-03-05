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

        protected Stat duration;
        public int Duration
        {
            get { return (int)Math.Round(duration.Value, 4); }
        }
        protected Stat speed;
        public float Speed
        {
            get { return speed.Value; }
        }

        protected Stat damage;
        public int Damage
        {
            get { return (int)Math.Round(damage.Value, 4); }
        }

        public Vector2 Target;

        public InstantProjectileSpell(Creature owner, int manaCost, string path, float spriteScale, int duration, float speed, int damage) : base(owner, manaCost, 50, 50)
        {
            this.path = path;
            this.spriteScale = spriteScale;
            this.duration = new Stat(duration);
            this.speed = new Stat(speed);
            this.damage = new Stat(damage);
        }

        public InstantProjectileSpell(Creature owner, int manaCost, string path, float spriteScale, int duration, float speed, int level, int exp, int damage) : base(owner, manaCost, 50, 50, level, exp)
        {
            this.path = path;
            this.spriteScale = spriteScale;
            this.duration = new Stat(duration);
            this.speed = new Stat(speed);
            this.damage = new Stat(damage);
        }

        public override void QuickCast(Vector2 target)
        {
            Target = target;
            base.QuickCast(target);
        }

        public override void CastEffect()
        {
            GameCommands.PassProjectile(new Projectile(path, spriteScale, new Vector2(owner.Sprite.Position.X, owner.Sprite.Position.Y), this, Target, Duration, Speed, Damage));   
        }
    }
}
