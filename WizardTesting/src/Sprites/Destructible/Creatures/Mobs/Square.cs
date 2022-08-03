using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class Square : Mob
    {
        public MTimer SpawnTimer;

        public Square(string path, Vector2 position, Vector2 frameCount, int switchFrame, int ownerId) : base(path, position, 1.5f, frameCount, switchFrame, ownerId)
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
            GameCommands.PassCreature(new Triangle("Sprites/Mobs/Triangle", new Vector2(Sprite.Position.X, Sprite.Position.Y), new Vector2(1, 1), 0, OwnerId));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
