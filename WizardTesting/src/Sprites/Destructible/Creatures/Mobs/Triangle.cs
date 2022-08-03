using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class Triangle : Mob
    {
        public Triangle(string path, Vector2 position, Vector2 frameCount, int switchFrame, int ownerId) : base(path, position, 1f, frameCount, switchFrame, ownerId)
        {

        }

        public override void Update(GameTime gameTime, Player enemy)
        {
            base.Update(gameTime, enemy);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
