using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class InstantProjectileSpell : Spell
    {
        protected float speed;
        protected string path;
        protected float spriteScale;
        protected int duration;

        public InstantProjectileSpell(Creature owner, float manaCost, string path, float spriteScale, int duration, float speed, float damage) : base(owner, manaCost, 50, 50)
        {
            this.path = path;
            this.damage = damage;
            this.speed = speed;
            this.spriteScale = spriteScale;
            this.duration = duration;
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
