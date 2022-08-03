﻿using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class Player
    {
        // Players are teams that organize cohesive intelligent control over game objects. Primarily used for inheritence.

        // The Wizard is the primary unit controlled by a player. Currently, mainly used by player, but AI may utilize in future.
        // TODO: LOW PRIORITY. Create AI with Wizard usage as central command.
        public Wizard Wizard;

        // Lists all Creatures and SpawnPoints under control of Player.
        public List<Creature> Creatures = new List<Creature>();
        public List<SpawnPoint> SpawnPoints = new List<SpawnPoint>();

        // Player id is used to organize Creatures under Player control.
        private int id;
        public int Id
        {
            get { return id; }
        }

        // Constructor requires and id to create for organizing behaviour.
        public Player(int id)
        {
            this.id = id;
        }

        // Updates all objects under player control.
        public virtual void Update(GameTime gameTime, Player enemy, World world)
        {
            if(Wizard != null)
            {
                Wizard.Update(gameTime);
            }

            for (int i = SpawnPoints.Count - 1; i >= 0; i--)
            {
                SpawnPoints[i].Update(gameTime);

                if (SpawnPoints[i].IsDead)
                {
                    SpawnPoints.RemoveAt(i);
                    i--;
                }
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
        
        // Adds a Creature to Player control.
        public virtual void AddCreature(Object info)
        {
            Creatures.Add((Creature)info);
        }

        // Adds a SpawnPoint to Player control.
        public virtual void AddSpawnPoint(Object info)
        {
            SpawnPoints.Add((SpawnPoint)info);
        }

        // Records the Score of the Player. Used for testing primarily by AIPlayer.
        public virtual void ChangeScore(World world, int score)
        {

        }

        // Draws all objects under Player control.
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
