using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WizardTesting
{
    public class SquareSummon : SpawnPoint
    {
        public SquareSummon(Vector2 position, int ownerId) : base("Sprites/SpawnPoints/SquareSummon", position, ownerId)
        {

        }

        public override void Update(GameTime gameTime, Player enemy)
        {
            base.Update(gameTime, enemy);
        }

        public override void SpawnMob()
        {
            GameCommands.PassCreature(new Square(new Vector2(Sprite.Position.X, Sprite.Position.Y), OwnerId));
        }
    }
}
