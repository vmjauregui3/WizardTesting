using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class Projectile
    {
        // Projectiles are objects that trasmit the agency of Creatures between Player's authority.

        // Projectiles contain a sprite that represents them visiually and contains their game location.
        public AnimatedSprite Sprite;

        // All game objects have a direction and speed.
        public Vector2 Direction;
        public float Speed;
        public float Damage;

        // Variable that determines when the projectile gets destroyed.
        protected bool done;
        public bool Done
        {
            get { return done; }
        }

        // Owner tracks which Creature that produced the projectile.
        // TODO: Change the Owner to a new class that defines all game objects with agency.
        public Creature Owner;
        protected Spell spell;

        // Timer tracks how long the projectile can exist before being destroyed.
        public MTimer Timer;

        // Constructor requires components for the Sprite, the owner information, and the target information (which is currently static).
        // TODO: Modify projectiles to allow them moving targets.
        public Projectile(string path, float spriteScale, Vector2 position, Spell ownerSpell, Vector2 target, int duration, float speed, float damage)
        {
            Sprite = new AnimatedSprite(path, new Vector2(position.X, position.Y));
            Sprite.Scale = spriteScale;
            // Rotates Sprite toward target.
            Sprite.Rotation = Pathing.RotateTowards(Sprite.Position, target);

            done = false;
            Owner = ownerSpell.Owner;
            this.spell = ownerSpell;

            Speed = speed;
            Damage = damage;

            Timer = new MTimer(duration);

            Direction = Vector2.Normalize(target - position);
        }

        public void SetIsDone()
        {
            done = true;
        }

        // Updates the Projectile's Sprite and Timer.
        // Default Projectile moves linearly toward target at a constant speed and is destroyed upon impact or after life duration.
        public virtual void Update(GameTime gameTime, List<Destructible> destructibles)
        {
            Sprite.Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            Timer.UpdateTimer(gameTime);
            if(Timer.Test())
            {
                done = true;
            }

            if (HitSomething(destructibles))
            {
                done = true;
                spell.GainExp(1);
            }
        }

        // Draws the Projectile's Sprite
        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        // Checks whether the Projectile hit a creature.
        // TODO: Modify projectile to check whether it hits SpawnPoints.
        public virtual bool HitSomething(List<Destructible> destructibles)
        {
            for (int i = destructibles.Count - 1; i >= 0; i--)
            {
                if (Owner.OwnerId != destructibles[i].OwnerId && Pathing.GetDistance(Sprite.Position, destructibles[i].Sprite.Position) < destructibles[i].HitDistance)
                {
                    destructibles[i].AddHealth(-Damage);
                    return true;
                }
            }
            return false;
        }
    }
}
