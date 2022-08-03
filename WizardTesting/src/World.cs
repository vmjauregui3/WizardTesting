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
        public UI UI;

        public Sprite Cursor;

        public User User;
        public AIPlayer AIPlayer;

        public int NumKilled;

        public List<Projectile> Projectiles = new List<Projectile>();

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

        public virtual void AddProjectile(object projectile)
        {
            Projectiles.Add((Projectile)projectile);
        }

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

        public World()
        {
            GameCommands.PassProjectile = AddProjectile;
            GameCommands.PassCreature = AddCreature;
            GameCommands.PassSpawnPoint = AddSpawnPoint;

            User = new User(0);
            AIPlayer = new AIPlayer(1);

            
            Camera.Instance.Follow(User.Wizard.Sprite);

            Cursor = new Sprite("Sprites/Cursor", new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y));

            NumKilled = 0;

            UI = new UI();
        }

        public void Update(GameTime gameTime)
        {
            Camera.Instance.FollowSprite(User.Wizard.Sprite);
            InputManager.Instance.Update(gameTime);
            MCursor.Instance.Update();
            Cursor.Position = Vector2.Transform(new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y), Matrix.Invert(Camera.Instance.Transform));

            User.Update(gameTime, AIPlayer, this);
            AIPlayer.Update(gameTime, User, this);

            User.Wizard.Update(gameTime);
            MCursor.Instance.UpdateOld();

            for (int i = Projectiles.Count - 1; i >= 0; i--)
            {
                Projectiles[i].Update(gameTime, AIPlayer.Creatures.ToList<Creature>());

                if (Projectiles[i].Done)
                {
                    Projectiles.RemoveAt(i);
                }
            }

            UI.Update(this);
        }

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
