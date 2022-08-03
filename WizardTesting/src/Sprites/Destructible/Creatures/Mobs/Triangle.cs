using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class Triangle : Mob
    {
        public Triangle(Vector2 position, int ownerId) : base("Sprites/Mobs/Triangle", position, 1f, new Vector2(1, 1), 0, ownerId)
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
