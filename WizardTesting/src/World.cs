using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Linq;

namespace WizardTesting
{
    public class World
    {
        // World defines the environment in which the user interacts with the game objects. Currently, completely static.
        // TODO: LOW PRIORITY. Make the world non-static and interchangeable.
        
        // Contains the UI overlay for the user to better understand game variables.
        public UI UI;

        // Contains the representation of the cursor on the screen and gameworld for user visibility and game referencing.
        public Sprite Cursor;

        // Creates the user player. Currently static, but may be adapted for multiplayer.
        public User User;

        // Creates the AIPlayer. Currently static, but may be adapted for multiple teams.
        // TODO: Create method of defining AIPlayers that is flexible and replicable. Requires alteration of AIPlayer.
        public AIPlayer AIPlayer;

        // Variable currently used for testing (not required for RPG progression).
        public int NumKilled;

        // Lists all projectiles in gameworld.
        public List<Projectile> Projectiles = new List<Projectile>();

        // Lists all the destructibles in the gameworld.
        public List<Destructible> AllDestructibles = new List<Destructible>();

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
        public World()
        {
            // Links PassObject Delegates to GameCommands
            GameCommands.PassProjectile = AddProjectile;
            GameCommands.PassCreature = AddCreature;
            GameCommands.PassSpawnPoint = AddSpawnPoint;

            // Creates the User with id 0
            User = new User(0);
            // Currently, creates the singular AIPlayer with id 1
            // TODO: Modify AIPlayer so that multiple can be created.
            AIPlayer = new AIPlayer(1);

            // Creates the Camera Instance that follows the user and controls what portion of the gameworld is drawn on screen.
            Camera.Instance.Follow(User.Wizard.Sprite);

            // Creates a representation of the cursor on the screen and gameworld for user visibility and game referencing where the mouse is.
            Cursor = new Sprite("Sprites/Cursor", new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y));

            // Variable tracked for testing.
            NumKilled = 0;

            // Creates the UI Overlay.
            UI = new UI();
        }

        // Updates all relevant components used for gameplay by the user and all objects in the game environment.
        public void Update(GameTime gameTime)
        {
            Camera.Instance.FollowSprite(User.Wizard.Sprite);
            InputManager.Instance.Update(gameTime);
            MCursor.Instance.Update();
            Cursor.Position = Vector2.Transform(new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y), Matrix.Invert(Camera.Instance.Transform));


            AllDestructibles.Clear();
            AllDestructibles.AddRange(User.GetAllDestructibles());
            AllDestructibles.AddRange(AIPlayer.GetAllDestructibles());

            User.Update(gameTime, AIPlayer, this);
            AIPlayer.Update(gameTime, User, this);

            User.Wizard.Update(gameTime, AIPlayer);
            MCursor.Instance.UpdateOld();

            // Loops through all projectiles backward and removes them if they need to be destroyed.
            for (int i = Projectiles.Count - 1; i >= 0; i--)
            {
                Projectiles[i].Update(gameTime, AllDestructibles);

                if (Projectiles[i].Done)
                {
                    Projectiles.RemoveAt(i);
                }
            }

            UI.Update(User.Wizard);
        }

        // Draws all relevant components used for gameplay by the user and all objects in the game environment.
        public void Draw(SpriteBatch spriteBatch)
        {

            User.Draw(spriteBatch);
            AIPlayer.Draw(spriteBatch);

            for (int i = Projectiles.Count - 1; i >= 0; i--)
            {
                Projectiles[i].Draw(spriteBatch);
            }

            Cursor.Draw(spriteBatch);

            UI.Draw(this, spriteBatch);
        }
        
    }
}
