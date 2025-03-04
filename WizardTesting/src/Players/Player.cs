using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
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
        public List<Building> Buildings = new List<Building>();

        // Player id is used to organize Creatures under Player control.
        private int id;
        public int Id
        {
            get { return id; }
        }

        // Constructor requires and id to create for organizing behaviour.
        public Player(int id, XElement data)
        {
            this.id = id;

            LoadData(data);
        }

        public virtual void LoadData(XElement data)
        {
            List<XElement> spawnList = (from t in data.Descendants("SpawnPoint") select t).ToList<XElement>();
            for (int i = 0; i < spawnList.Count; i++)
            {
                SpawnPoints.Add(new Portal(new Vector2(Convert.ToInt32(spawnList[i].Element("Position").Element("x").Value,WizardTesting.Culture), Convert.ToInt32(spawnList[i].Element("Position").Element("y").Value, WizardTesting.Culture)), id));
                SpawnPoints[SpawnPoints.Count - 1].SpawnTimer.AddToTimer(Convert.ToInt32(spawnList[i].Element("timerOffset").Value));
            }

            List<XElement> buildingList = (from t in data.Descendants("Building") select t).ToList<XElement>();
            for (int i = 0; i < buildingList.Count; i++)
            {
                Buildings.Add(new Tower(new Vector2(Convert.ToInt32(buildingList[i].Element("Position").Element("x").Value, WizardTesting.Culture), Convert.ToInt32(buildingList[i].Element("Position").Element("y").Value, WizardTesting.Culture)), id));
            }
        }

        // Updates all objects under player control.
        public virtual void Update(GameTime gameTime, World world)
        {
            for (int i = Buildings.Count - 1; i >= 0; i--)
            {
                UpdateIfLoaded(gameTime, world, Buildings[i]);

                if (Buildings[i].IsDead)
                {
                    Buildings.RemoveAt(i);
                    //i--;
                }
            }

            for (int i = SpawnPoints.Count - 1; i >= 0; i--)
            {
                UpdateIfLoaded(gameTime, world, SpawnPoints[i]);

                if (SpawnPoints[i].IsDead)
                {
                    SpawnPoints.RemoveAt(i);
                    //i--;
                }
            }

            for (int i = Creatures.Count - 1; i >= 0; i--)
            {
                UpdateIfLoaded(gameTime, world, Creatures[i]);

                if (Creatures[i].IsDead)
                {
                    Creatures.RemoveAt(i);
                    //i--;
                }
            }

            if (Wizard != null)
            {
                Wizard.Update(gameTime);
            }
        }

        public void UpdateIfLoaded(GameTime gameTime, World world, Destructible obj)
        {
            string zoneKey = world.getZoneKey(obj.Sprite.Position);
            if (world.LoadedZones.Contains(zoneKey))
            {
                obj.SetIsLoaded(true);
                obj.Update(gameTime, world);
            }
            else
            {
                obj.SetIsLoaded(false);
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

        // Creates a List of all Destructibles the Player controls.
        public virtual List<Destructible> GetAllDestructibles()
        {
            List<Destructible> tempObjects = new List<Destructible>();
            if(Wizard != null)
            {
                tempObjects.Add(Wizard);
            }
            tempObjects.AddRange(Creatures.ToList<Destructible>());
            tempObjects.AddRange(SpawnPoints.ToList<Destructible>());
            tempObjects.AddRange(Buildings.ToList<Destructible>());

            return tempObjects;
        }

        // Draws all objects under Player control.
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = Buildings.Count - 1; i >= 0; i--)
            {
                if (Buildings[i].IsLoaded)
                {
                    Buildings[i].Draw(spriteBatch);
                }
            }

            for (int i = SpawnPoints.Count - 1; i >= 0; i--)
            {
                if (SpawnPoints[i].IsLoaded)
                {
                    SpawnPoints[i].Draw(spriteBatch);
                }
            }

            for (int i = Creatures.Count - 1; i >= 0; i--)
            {
                if (Creatures[i].IsLoaded)
                {
                    Creatures[i].Draw(spriteBatch);
                }
            }

            if (Wizard != null)
            {
                Wizard.Draw(spriteBatch);
            }
        }
    }
}
