using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class Player
    {
        public Wizard Wizard;
        public List<Creature> Creatures = new List<Creature>();
        public List<SpawnPoint> SpawnPoints = new List<SpawnPoint>();

        private int id;
        public int Id
        {
            get { return id; }
        }

        public Player(int id)
        {
            this.id = id;
        }

        public virtual void Update(GameTime gameTime, Player enemy, World world)
        {
            if(Wizard != null)
            {
                Wizard.Update(gameTime);
            }

            for (int i = SpawnPoints.Count - 1; i >= 0; i--)
            {
                SpawnPoints[i].Update(gameTime);
            }

            for (int i = Creatures.Count - 1; i >= 0; i--)
            {
                Creatures[i].Update(gameTime, enemy);

                if (Creatures[i].IsDead)
                {
                    ChangeScore(world, 1);
                    Creatures.RemoveAt(i);
                    i--;
                }
            }
        }
        
        public virtual void AddCreature(Object info)
        {
            Creatures.Add((Creature)info);
        }

        public virtual void AddSpawnPoint(Object info)
        {
            SpawnPoints.Add((SpawnPoint)info);
        }

        public virtual void ChangeScore(World world, int score)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Wizard != null)
            {
                Wizard.Draw(spriteBatch);
            }

            for (int i = SpawnPoints.Count - 1; i >= 0; i--)
            {
                SpawnPoints[i].Draw(spriteBatch);
            }

            for (int i = Creatures.Count - 1; i >= 0; i--)
            {
                Creatures[i].Draw(spriteBatch);
            }
        }
    }
}
