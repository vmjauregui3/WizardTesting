using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class Projectile : Impermanent
    {
        // Projectiles are objects that trasmit the agency of Creatures between Player's authority.

        // All game objects have a direction and speed.
        public float Damage;

        // Constructor requires components for the Sprite, the owner information, and the target information (which is currently static).
        // TODO: Modify projectiles to allow them moving targets.

        public Projectile(string path, Vector2 position, float scale, Vector2 frameCount, int switchFrame, Spell ownerSpell, int duration, Vector2 direction, float speed, float damage) : base(path, position, scale, frameCount, switchFrame, ownerSpell, duration)
        {
            Direction = direction;
            MoveSpeed = new Stat(speed);

            // Rotates Sprite to move in Direction.
            Sprite.Rotation = Pathing.RotateTowards(Vector2.Zero, direction);

            Damage = damage;
        }

        // Updates the Projectile's Sprite and Timer.
        // Default Projectile moves linearly toward target at a constant speed and is destroyed upon impact or after life duration.
        public virtual void Update(GameTime gameTime, List<Destructible> destructibles)
        {
            base.Update(gameTime);

            if (HitSomething(destructibles))
            {
                done = true;
                spell.GainExp(1);
            }
        }

        // Checks whether the Projectile hit a creature.
        public virtual bool HitSomething(List<Destructible> destructibles)
        {
            foreach (Destructible destructible in destructibles)
            {
                if (spell.Owner.OwnerId != destructible.OwnerId && Pathing.GetDistance(Sprite.Position, destructible.Sprite.Position) < destructible.HitDistance)
                {
                    destructible.AddHealth(-Damage);
                    return true;
                }
            }

            return false;
        }
    }
}
