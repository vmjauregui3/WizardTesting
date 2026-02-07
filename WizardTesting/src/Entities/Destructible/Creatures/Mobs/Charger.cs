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

        public Charger(Vector2 position, int ownerId) : base("Sprites/Mobs/ChargerSpriteSheet", position, 1.0f, new Vector2(6, 1), 500, ownerId)
        {
            MoveSpeed = new Stat(80.0f);
            health = new VariableStat(20);

            CastTimer = new MTimer(1000);
            //spell = new FireBolt(this);
        }

        public override void Update(GameTime gameTime, World world)
        {
            CastTimer.UpdateTimer(gameTime);
            if (CastTimer.Test())
            {
                CastTimer.ResetToZero();
            }

            base.Update(gameTime, world);
        }

        public override void AI(GameTime gameTime, World world)
        {
            Creature targetCreature = world.User.Wizard;
            if (Pathing.GetDistance(Sprite.Position, targetCreature.Sprite.Position) > dashDistance)
            {
                Sprite.Position += Pathing.DirectionToward(Sprite.Position, targetCreature.Sprite.Position) * MoveSpeed.Value * (float)gameTime.ElapsedGameTime.TotalSeconds;

            }

            if (Pathing.GetDistance(Sprite.Position, targetCreature.Sprite.Position) < targetCreature.HitDistance)
            {
                targetCreature.AddHealth(-100);
                isDead = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
