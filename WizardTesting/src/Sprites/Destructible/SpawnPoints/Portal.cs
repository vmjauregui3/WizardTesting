using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WizardTesting
{
    public class Portal : SpawnPoint
    {
        public Portal(Vector2 position, int ownerId) : base("Sprites/SpawnPoint", position, ownerId)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void SpawnMob()
        {
            GameCommands.PassCreature(new Triangle("Sprites/Mobs/Triangle", new Vector2(Sprite.Position.X, Sprite.Position.Y), new Vector2(1, 1), 0, OwnerId));
        }
    }
}
