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
        public Portal(Vector2 position, int ownerId) : base("Sprites/SpawnPoints/Portal", position, ownerId)
        {

        }

        public override void Update(GameTime gameTime, World world)
        {
            base.Update(gameTime, world);
        }

        public override void SpawnMob()
        {
            int num = WizardTesting.rand.Next(1, 10 + 1);

            Mob tempMob = null;

            if(num <= 8)
            {
                tempMob = new Square(new Vector2(Sprite.Position.X, Sprite.Position.Y), OwnerId);
            }
            else if(num <= 9)
            {
                tempMob = new RedPentagon(new Vector2(Sprite.Position.X, Sprite.Position.Y), OwnerId);
            }

            if(tempMob != null)
            {
                GameCommands.PassCreature(tempMob);
            }
        }
    }
}
