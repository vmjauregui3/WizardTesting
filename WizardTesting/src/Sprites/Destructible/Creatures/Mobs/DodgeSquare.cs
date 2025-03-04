using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class DodgeSquare : Mob
    {
        public FireBolt spell;
        public MTimer CastTimer;
        public DodgeSquare(Vector2 position, int ownerId) : base("Sprites/Mobs/Square", position, 1f, new Vector2(1, 1), 0, ownerId)
        {
            CastTimer = new MTimer(1000);
            spell = new FireBolt(this);
        }

        public override void Update(GameTime gameTime, World world)
        {
            CastTimer.UpdateTimer(gameTime);
            if (CastTimer.Test())
            {
                spell.QuickCast(world.User.Wizard.Sprite.Position);
                CastTimer.ResetToZero();
            }

            base.Update(gameTime, world);
        }

        public override void AI(GameTime gameTime, World world)
        {
            Creature targetCreature = world.User.Wizard;
            Vector2 dodgeVector = Vector2.Zero;
            float dodgeUrgency = hitDistance / MoveSpeed;
            for (int i = world.Projectiles.Count - 1; i >= 0; i--)
            {
                if (world.Projectiles[i].Owner.OwnerId != OwnerId)
                {
                    Vector2 threatVector = Pathing.DirectionToward(world.Projectiles[i].Sprite.Position, Sprite.Position);
                    if (Pathing.NormDot(threatVector, world.Projectiles[i].Direction) > 0.8f)
                    {
                        float threatCross = Pathing.CrossProduct(world.Projectiles[i].Direction, threatVector);
                        if (threatCross > 0)
                        {
                            dodgeVector = new Vector2(-world.Projectiles[i].Direction.Y, world.Projectiles[i].Direction.X); // CCW
                        }
                        else
                        {
                            dodgeVector = new Vector2(world.Projectiles[i].Direction.Y, -world.Projectiles[i].Direction.X); // CW
                        }
                        dodgeUrgency = dodgeUrgency / ((Pathing.GetDistance(Sprite.Position, world.Projectiles[i].Sprite.Position)/world.Projectiles[i].Speed) + dodgeUrgency);
                    }
                }
            }
            Vector2 toTarget = Pathing.DirectionToward(Sprite.Position, targetCreature.Sprite.Position);
            Vector2 moveDirection = Vector2.Normalize(dodgeVector * dodgeUrgency + toTarget * (1 - dodgeUrgency));


            Sprite.Position += moveDirection * MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Pathing.GetDistance(Sprite.Position, targetCreature.Sprite.Position) < targetCreature.HitDistance)
            {
                targetCreature.UpdateHealth(100);
                isDead = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
