using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class RedPentagon : Mob
    {
        public MTimer SpawnTimer;

        private float orbitDistance;
        public RedPentagon(Vector2 position, int ownerId) : base("Sprites/Mobs/RedPentagon", position, 1f, new Vector2(1, 1), 0, ownerId)
        {
            MoveSpeed = 80.0f;
            orbitDistance = 500f;

            health = new VariableStat(30);

            SpawnTimer = new MTimer(4000);
        }

        public override void Update(GameTime gameTime, World world)
        {
            SpawnTimer.UpdateTimer(gameTime);
            if (SpawnTimer.Test())
            {
                SpawnTriangle();
                SpawnTimer.ResetToZero();
            }

            base.Update(gameTime, world);
        }

        public override void AI(GameTime gameTime, Wizard wizard)
        {
            if (Pathing.GetDistance(Sprite.Position, wizard.Sprite.Position) > orbitDistance)
            {
                Sprite.Position += Pathing.DirectionToward(Sprite.Position, wizard.Sprite.Position) * MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            }

            if (Pathing.GetDistance(Sprite.Position, wizard.Sprite.Position) < wizard.HitDistance)
            {
                wizard.UpdateHealth(100);
                isDead = true;
            }
        }

        public virtual void SpawnTriangle()
        {
            GameCommands.PassCreature(new Triangle(new Vector2(Sprite.Position.X, Sprite.Position.Y), this));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
