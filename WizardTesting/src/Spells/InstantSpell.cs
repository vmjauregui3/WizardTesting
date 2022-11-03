using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class InstantSpell : Spell
    {
        protected float speed;
        protected string path;
        protected float spriteScale;
        protected int duration;

        public InstantSpell(string path, float spriteScale, int duration, float speed, float damage, float manaCost, int cooldown, int castTime) : base(manaCost, cooldown, castTime)
        {
            this.path = path;
            this.damage = damage;
            this.speed = speed;
            this.spriteScale = spriteScale;
            this.duration = duration;
        }

        public void CreateProjectile(Vector2 position, Creature owner, Vector2 target)
        {
            GameCommands.PassProjectile(new Projectile(path, spriteScale, position, owner, target, duration, speed, damage));
            owner.UpdateMana(manaCost);
        }
    }
}
