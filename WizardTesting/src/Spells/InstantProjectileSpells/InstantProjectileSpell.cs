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
