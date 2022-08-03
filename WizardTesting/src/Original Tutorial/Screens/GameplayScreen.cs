using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Linq;
/*
namespace WizardTesting
{
    public class GameplayScreen : GameScreen
    {
        public Sprite Cursor;
        Player wizard;
        //Map map;

        public List<Projectile> Projectiles = new List<Projectile>();
        public List<Mob> Mobs = new List<Mob>();
        public List<SpawnPoint> SpawnPoints = new List<SpawnPoint>();

        public virtual void AddMob(object mob)
        {
            Mobs.Add((Mob)mob);
        }

        public virtual void AddProjectile(object projectile)
        { 
            Projectiles.Add((Projectile)projectile);
        }

        public override void LoadContent()
        {
            GameCommands.PassProjectile = AddProjectile;
            GameCommands.PassMob = AddMob;
            base.LoadContent();

            XmlManager<Player> playerLoader = new XmlManager<Player>();
            wizard = playerLoader.Load("src/GamePlay/Player.xml");
            wizard.LoadContent();

            //wizard = new Player("Sprites/BaseWizard", new Vector2(100,300));

            //XmlManager<Map> mapLoader = new XmlManager<Map>();
            //map = mapLoader.Load("src/GamePlay/Maps/Map1.xml");
            //map.LoadContent();

            Cursor = new Sprite("Sprites/Cursor", new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y));

            SpawnPoints.Add(new SpawnPoint(new Vector2(1300, 100)));

            SpawnPoints.Add(new SpawnPoint(new Vector2(1300, 800)));
            SpawnPoints[SpawnPoints.Count - 1].SpawnTimer.AddToTimer(500);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            wizard.UnloadContent();
            //map.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MCursor.Instance.Update();
            wizard.Update(gameTime);
            //map.Update(gameTime, ref wizard);
            MCursor.Instance.UpdateOld();
            Cursor.Position = new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y);

            for (int i = SpawnPoints.Count - 1; i >= 0; i--)
            {
                SpawnPoints[i].Update(gameTime);
            }

            for (int i = Projectiles.Count - 1; i >= 0; i--)
            {
                Projectiles[i].Update(gameTime, Mobs.ToList<Creature>());

                if(Projectiles[i].Done)
                {
                    Projectiles.RemoveAt(i);
                    i--;
                }
            }

            for (int i = Mobs.Count - 1; i >= 0; i--)
            {
                Mobs[i].Update(gameTime, wizard);

                if (Mobs[i].IsDead)
                {
                    Mobs.RemoveAt(i);
                    i--;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            //map.Draw(spriteBatch, "Underlay");
            wizard.Draw(spriteBatch);
            //map.Draw(spriteBatch, "Overlay");
            
            for (int i = SpawnPoints.Count - 1; i >= 0; i--)
            {
                SpawnPoints[i].Draw(spriteBatch);
            }

            for (int i = Projectiles.Count - 1; i >= 0; i--)
            {
                Projectiles[i].Draw(spriteBatch);
            }

            for (int i = Mobs.Count - 1; i >= 0; i--)
            {
                Mobs[i].Draw(spriteBatch);
            }

            Cursor.Draw(spriteBatch);
        }
    }
}

/*
namespace WizardTesting
{
    public class GameplayScreen : GameScreen
    {
        public Sprite Cursor;
        Player wizard;
        //Map map;

        public List<Projectile> Projectiles = new List<Projectile>();
        public List<Mob> Mobs = new List<Mob>();
        public List<SpawnPoint> SpawnPoints = new List<SpawnPoint>();

        public virtual void AddMob(object mob)
        {
            Mobs.Add((Mob)mob);
        }

        public virtual void AddProjectile(object projectile)
        { 
            Projectiles.Add((Projectile)projectile);
        }

        public override void LoadContent()
        {
            GameCommands.PassProjectile = AddProjectile;
            GameCommands.PassMob = AddMob;
            base.LoadContent();

            XmlManager<Player> playerLoader = new XmlManager<Player>();
            wizard = playerLoader.Load("src/GamePlay/Player.xml");
            wizard.LoadContent();

            //wizard = new Player("Sprites/BaseWizard", new Vector2(100,300));

            //XmlManager<Map> mapLoader = new XmlManager<Map>();
            //map = mapLoader.Load("src/GamePlay/Maps/Map1.xml");
            //map.LoadContent();

            Cursor = new Sprite("Sprites/Cursor", new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y));

            SpawnPoints.Add(new SpawnPoint(new Vector2(1300, 100)));

            SpawnPoints.Add(new SpawnPoint(new Vector2(1300, 800)));
            SpawnPoints[SpawnPoints.Count - 1].SpawnTimer.AddToTimer(500);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            wizard.UnloadContent();
            //map.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MCursor.Instance.Update();
            wizard.Update(gameTime);
            //map.Update(gameTime, ref wizard);
            MCursor.Instance.UpdateOld();
            Cursor.Position = new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y);

            for (int i = SpawnPoints.Count - 1; i >= 0; i--)
            {
                SpawnPoints[i].Update(gameTime);
            }

            for (int i = Projectiles.Count - 1; i >= 0; i--)
            {
                Projectiles[i].Update(gameTime, Mobs.ToList<Creature>());

                if(Projectiles[i].Done)
                {
                    Projectiles.RemoveAt(i);
                    i--;
                }
            }

            for (int i = Mobs.Count - 1; i >= 0; i--)
            {
                Mobs[i].Update(gameTime, wizard);

                if (Mobs[i].IsDead)
                {
                    Mobs.RemoveAt(i);
                    i--;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            //map.Draw(spriteBatch, "Underlay");
            wizard.Draw(spriteBatch);
            //map.Draw(spriteBatch, "Overlay");
            
            for (int i = SpawnPoints.Count - 1; i >= 0; i--)
            {
                SpawnPoints[i].Draw(spriteBatch);
            }

            for (int i = Projectiles.Count - 1; i >= 0; i--)
            {
                Projectiles[i].Draw(spriteBatch);
            }

            for (int i = Mobs.Count - 1; i >= 0; i--)
            {
                Mobs[i].Draw(spriteBatch);
            }

            Cursor.Draw(spriteBatch);
        }
    }
}
*/