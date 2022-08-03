using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WizardTesting
{
    public class TriangleSummon : SpawnPoint
    {
        private int maxSpawns, totalSpawns;

        public TriangleSummon(Vector2 position, int ownerId) : base("Sprites/SpawnPoints/TriangleSummon", position, ownerId)
        {
            totalSpawns = 0;
            maxSpawns = 3;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void SpawnMob()
        {
            Mob tempMob = new Triangle(new Vector2(Sprite.Position.X, Sprite.Position.Y), OwnerId);

            if (tempMob != null)
            {
                GameCommands.PassCreature(tempMob);

                totalSpawns++;
                if (totalSpawns >= maxSpawns)
                {
                    isDead = true;
                }
            }
        }
    }
}
