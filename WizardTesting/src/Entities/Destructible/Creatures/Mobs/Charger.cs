using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class Charger : Mob
    {
        public MTimer CastTimer;

        private float dashDistance;
        private Vector2 dashDirection;

        public Charger(Vector2 position, int ownerId) : base("Sprites/Mobs/ChargerSpriteSheet", position, 1.0f, new Vector2(6, 1), 200, ownerId)
        {
            MoveSpeed = new Stat(80.0f);
            dashDistance = 300f;

            health = new VariableStat(20);

            CastTimer = new MTimer(1200);
            //spell = new FireBolt(this);
        }

        public override void Update(GameTime gameTime, World world)
        {
            CastTimer.UpdateTimer(gameTime);

            base.Update(gameTime, world);
        }

        public override void AI(GameTime gameTime, World world)
        {
            Creature targetCreature = world.User.Wizard;
            if (Sprite.IsActive && CastTimer.Test())
            {
                IsCasting = true;
                CastTimer.ResetToZero();
                Sprite.IsActive = false;
            }
            if (!IsCasting)
            {
                if (Pathing.GetDistance(Sprite.Position, targetCreature.Sprite.Position) > dashDistance)
                {
                    Sprite.IsActive = false;
                    dashDirection = Pathing.DirectionToward(Sprite.Position, targetCreature.Sprite.Position);
                    Sprite.Rotation = Pathing.RotateTowards(Vector2.Zero, dashDirection);
                    Sprite.Position += dashDirection * MoveSpeed.Value * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    CastTimer.ResetToZero();
                }
                else
                {
                    Sprite.IsActive = true;
                }
            }
            else
            {
                Sprite.Position += dashDirection * MoveSpeed.Value * 5 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (CastTimer.Test())
                {
                    IsCasting = false;
                    CastTimer.ResetToZero();
                }
            }

            if (Pathing.GetDistance(Sprite.Position, targetCreature.Sprite.Position) < targetCreature.HitDistance)
            {
                targetCreature.AddHealth(-100);
                isDestroyed = true;
            }


            if (Pathing.GetDistance(Sprite.Position, targetCreature.Sprite.Position) < targetCreature.HitDistance)
            {
                targetCreature.AddHealth(-100);
                isDestroyed = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
