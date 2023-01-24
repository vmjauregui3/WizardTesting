using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class InstantProjectileSpell : Spell
    {
        protected float speed;
        public float Speed
        {
            get { return speed; }
        }
        protected int duration;
        public int Duration
        {
            get { return duration; }
        }
        protected string path;
        protected float spriteScale;

        public InstantProjectileSpell(Creature owner, int manaCost, string path, float spriteScale, int duration, float speed, int damage) : base(owner, manaCost, 50, 50)
        {
            this.path = path;
            this.damage = damage;
            this.speed = speed;
            this.spriteScale = spriteScale;
            this.duration = duration;
        }

        public InstantProjectileSpell(Creature owner, int level, int manaCost, int damage, int cooldown, int castTime, int duration, float speed) : base(owner, level, manaCost, damage, cooldown, castTime)
        {

        }

        public override void CastSpell(Vector2 target)
        {
            CreateSimpleProjectile(target);
            base.CastSpell();
        }

        public void CreateSimpleProjectile(Vector2 target)
        {
            GameCommands.PassProjectile(new Projectile(path, spriteScale, new Vector2(owner.Sprite.Position.X, owner.Sprite.Position.Y), owner, target, duration, speed, damage));   
        }
    }
}
