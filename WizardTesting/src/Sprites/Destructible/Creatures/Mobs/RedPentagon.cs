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

        public RedPentagon(Vector2 position, int ownerId) : base("Sprites/Mobs/RedPentagon", position, 1.5f, new Vector2(1, 1), 0, ownerId)
        {
            MoveSpeed = 80.0f;

            health = 3;
            healthMax = health;

            SpawnTimer = new MTimer(4000);
        }

        public override void Update(GameTime gameTime, Player enemy)
        {
            SpawnTimer.UpdateTimer(gameTime);
            if (SpawnTimer.Test())
            {
                SpawnTriangle();
                SpawnTimer.ResetToZero();
            }

            base.Update(gameTime, enemy);
        }

        public virtual void SpawnTriangle()
        {
            GameCommands.PassSpawnPoint(new TriangleSummon(new Vector2(Sprite.Position.X, Sprite.Position.Y), OwnerId));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
