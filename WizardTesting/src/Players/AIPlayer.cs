using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class AIPlayer : Player
    {
        // AIPlayer defines a collection of computer-controlled objects working toward an objective; typically seeks to restrict user agency.

        // Constructor uses id to create objects under AIPlayer control. Currently, this class is static and unflexible in the game.
        // TODO: Create method of defining AIPlayers that is flexible and replicable. Likely requires this class to become an inheritor class.
        public AIPlayer(int id, XElement data) : base(id, data)
        {
            //SpawnPoints.Add(new Portal(new Vector2(1300, 100), id));

            //SpawnPoints.Add(new Portal(new Vector2(1300, 800), id));
            //SpawnPoints[SpawnPoints.Count - 1].SpawnTimer.AddToTimer(500);
        }

        // Updates their Player.
        public override void Update(GameTime gameTime, Player enemy, World world)
        {
            base.Update(gameTime, enemy, world);
        }
        
        // Used to track user progress for testing.
        public override void ChangeScore(World world, int score)
        {
            world.NumKilled++;
        }

    }
}
