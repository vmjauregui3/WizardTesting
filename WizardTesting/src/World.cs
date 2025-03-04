using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Linq;
using System.Xml.Linq;
using System.Xml;

namespace WizardTesting
{
    public class World
    {
        // World defines the environment in which the user interacts with the game objects. Currently, completely static.
        // TODO: LOW PRIORITY. Make the world non-static and interchangeable.

        public Map Map;

        // Creates the user player. Currently static, but may be adapted for multiplayer.
        public User User;

        // Creates the AIPlayer. Currently static, but may be adapted for multiple teams.
        // TODO: Create method of defining AIPlayers that is flexible and replicable. Requires alteration of AIPlayer.
        public AIPlayer AIPlayer;

        // Lists all projectiles in gameworld.
        public List<Projectile> Projectiles = new List<Projectile>();

        // Lists all the destructibles in the gameworld.
        public List<Destructible> AllDestructibles = new List<Destructible>();


        private static int zoneRadius = 5;
        public HashSet<string> LoadedZones;
        public Vector2 PlayerZone, PlayerZonePrev;

        // Adds a Creature to the world under designated Player's control.
        public virtual void AddCreature(object mob)
        {
            Creature tempCreature = (Creature)mob;
            if (User.Id == tempCreature.OwnerId)
            {
                User.AddCreature(tempCreature);
            }
            if (AIPlayer.Id == tempCreature.OwnerId)
            {
                AIPlayer.AddCreature(tempCreature);
            }
        }

        // Adds a Projectile to the World List of Projectiles
        public virtual void AddProjectile(object projectile)
        {
            Projectiles.Add((Projectile)projectile);
        }

        // Adds a SpawnPoint to the world under designated Player's control.
        public virtual void AddSpawnPoint(object spawn)
        {
            SpawnPoint tempSpawn = (SpawnPoint)spawn;
            if (User.Id == tempSpawn.OwnerId)
            {
                User.AddSpawnPoint(tempSpawn);
            }
            if (AIPlayer.Id == tempSpawn.OwnerId)
            {
                AIPlayer.AddSpawnPoint(tempSpawn);
            }
        }

        // Constructor creates the World that the user can interact with.
        public World(string username, int worldNum)
        {
            // Links PassObject Delegates to GameCommands
            GameCommands.PassProjectile = AddProjectile;
            GameCommands.PassCreature = AddCreature;
            GameCommands.PassSpawnPoint = AddSpawnPoint;

            // Creates the User with id 0
            // Currently, creates the singular AIPlayer with id 1
            // TODO: Modify AIPlayer so that multiple can be created.
            LoadData(username, worldNum);

            Map = new Map();

            LoadedZones = new HashSet<string>();
            PlayerZone = getZone(User.Wizard.Sprite.Position);
            PlayerZonePrev = PlayerZone;
            LoadZones();

            // Creates the Camera Instance that follows the user and controls what portion of the gameworld is drawn on screen.
            Camera.Instance.Follow(User.Wizard.Sprite);

        }

        public virtual void LoadData(string username, int worldNum)
        {
            LoadUserData(username);
            XDocument xml = XDocument.Load("XML\\Worlds\\World"+worldNum+".xml");

            XElement tempElement = null;
            if (xml.Element("Root").Element("AIPlayer") != null)
            {
                tempElement = xml.Element("Root").Element("AIPlayer");
            }
            AIPlayer = new AIPlayer(1, tempElement);
        }

        public void LoadUserData(string username)
        {
            XDocument xmlPlayer = XDocument.Load("XML\\Players\\Users\\User" + username + ".xml");

            XElement tempElement = null;
            if (xmlPlayer.Element("Root") != null)
            {
                tempElement = xmlPlayer.Element("Root");
            }
            User = new User(0, tempElement);
        }

        public void SaveUserData(string username)
        {
            XDocument xmlPlayer = new XDocument(
                new XElement("Root",
                    new XElement("Wizard",
                        new XElement("level", User.Wizard.Level),
                        new XElement("healthMax", User.Wizard.Health.ValueMax),
                        new XElement("manaMax", User.Wizard.Mana.ValueMax),
                        new XElement("manaRegenMax", User.Wizard.ManaRegen.ValueMax),
                        new XElement("Scale", User.Wizard.Scale),
                        new XElement("MoveSpeed", User.Wizard.MoveSpeed),
                        new XElement("Position",
                            new XElement("x", (int)User.Wizard.Sprite.Position.X),
                            new XElement("y", (int)User.Wizard.Sprite.Position.Y)
                        )
                    )
                )
            );
            xmlPlayer.Element("Root").Element("Wizard").Add(new XElement("Spells"));
            for (int i = 0; i < User.Wizard.Spells.Count; i++)
            {
                xmlPlayer.Element("Root").Element("Wizard").Element("Spells").Add(      // new XAttribute("id", i),
                    new XElement(User.Wizard.Spells[i].GetType().Name,
                        new XElement("level", User.Wizard.Spells[i].Level),
                        new XElement("exp", User.Wizard.Spells[i].Exp)
                    )
                );
            }
            //xmlPlayer.Element("Root").Add(new XElement("Spells", User.Wizard.Spells.Select(i => new XElement("Spell", new XAttribute("id", i)))));

            xmlPlayer.Save("XML\\Players\\Users\\User" + username + ".xml");
        }

        public Vector2 getZone(Vector2 position)
        {
            return Map.getZone(position);
        }

        public string getZoneKey(Vector2 position)
        {
            Vector2 zone = Map.getZone(position);
            string zoneKey = (int)zone.X + "_" + (int)zone.Y;

            return zoneKey;
        }

        public void LoadZones()
        {
            for (int j = (int)PlayerZone.Y - zoneRadius; j <= (int)PlayerZone.Y + zoneRadius; j++)
            {
                for (int i = (int)PlayerZone.X - zoneRadius; i <= (int)PlayerZone.X + zoneRadius; i++)
                {
                    string zoneKey = i + "_" + j;
                    Map.CheckHasKey(i, j);
                    LoadedZones.Add(zoneKey);
                }
            }
        }

        // Updates all relevant components used for gameplay by the user and all objects in the game environment.
        public void Update(GameTime gameTime)
        {
            PlayerZonePrev = PlayerZone;
            PlayerZone = getZone(User.Wizard.Sprite.Position);

            if (!PlayerZone.Equals(PlayerZonePrev))
            {
                LoadedZones.Clear();
                LoadZones();
            }
            //Map.Update();

            Camera.Instance.FollowSprite(User.Wizard.Sprite);
            
            AllDestructibles.Clear();
            AllDestructibles.AddRange(User.GetAllDestructibles());
            AllDestructibles.AddRange(AIPlayer.GetAllDestructibles());

            User.Update(gameTime, this);
            AIPlayer.Update(gameTime, this);

            // Loops through all projectiles backward and removes them if they need to be destroyed.
            for (int i = Projectiles.Count - 1; i >= 0; i--)
            {
                string zoneKey = getZoneKey(Projectiles[i].Sprite.Position);
                if (LoadedZones.Contains(zoneKey))
                {
                    Projectiles[i].Update(gameTime, AllDestructibles);
                }
                else
                {
                    Projectiles[i].SetIsDone();
                }

                if (Projectiles[i].Done)
                {
                    Projectiles.RemoveAt(i);
                }
            }
        }

        // Draws all relevant components used for gameplay by the user and all objects in the game environment.
        public void Draw(SpriteBatch spriteBatch)
        {
            Map.Draw(spriteBatch, LoadedZones);

            AIPlayer.Draw(spriteBatch);

            for (int i = Projectiles.Count - 1; i >= 0; i--)
            {
                Projectiles[i].Draw(spriteBatch);
            }

            User.Draw(spriteBatch);
        }
    }
}
