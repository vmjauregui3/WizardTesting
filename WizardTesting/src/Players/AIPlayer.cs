using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class AIPlayer : Player
    {

        public AIPlayer(int id) : base(id)
        {

            SpawnPoints.Add(new SpawnPoint("Sprites/SpawnPoint", new Vector2(1300, 100), id));

            SpawnPoints.Add(new SpawnPoint("Sprites/SpawnPoint", new Vector2(1300, 800), id));
            SpawnPoints[SpawnPoints.Count - 1].SpawnTimer.AddToTimer(500);
        }

        public override void Update(GameTime gameTime, Player enemy, World world)
        {
            base.Update(gameTime, enemy, world);
        }

        public override void ChangeScore(World world, int score)
        {
            world.NumKilled++;
        }

    }
}
