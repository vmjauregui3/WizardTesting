﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;

namespace WizardTesting
{
    public class WizardTesting : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //private Camera camera;

        private static int gameHeight;
        public static int GameHeight
        {
            get { return gameHeight; }
        }
        private static int gameWidth;
        public static int GameWidth
        {
            get { return gameWidth; }
        }
        private static Vector2 gameOrigin;
        public static Vector2 GameOrigin 
        { 
            get { return gameOrigin; } 
        }

        public int gameState;
        private MainMenu mainMenu;

        private World world;

        public bool paused = false;

        public static Random rand = new Random();

        public static ContentManager WContent;

        public static System.Globalization.CultureInfo Culture = new System.Globalization.CultureInfo("en-US");

        private string username = "Gary";

        public WizardTesting()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //camera = new Camera();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            gameWidth = (int)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            gameHeight = (int)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            gameOrigin = new Vector2(gameWidth / 2, gameHeight / 2);

            graphics.PreferredBackBufferWidth = gameWidth;
            graphics.PreferredBackBufferHeight = gameHeight;

            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            base.Initialize();

            WContent = new ContentManager(Content.ServiceProvider, "Content");

            gameState = 0;
            mainMenu = new MainMenu(ChangeGameState, ExitGame);

            world = new World(username, 1);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            InputManager.Instance.Update(gameTime);
            MCursor.Instance.Update();

            if (gameState == 0)
            {
                mainMenu.Update();
            }
            else if (gameState == 1)
            {
                if (InputManager.Instance.KeyPressed(Keys.Escape))
                {
                    paused = !paused;
                    IsMouseVisible = !IsMouseVisible;
                } // Exit();

                if (paused)
                {
                    if (InputManager.Instance.KeyPressed(Keys.S))
                    {
                        world.SaveUserData(username);
                    }
                    else if (InputManager.Instance.KeyPressed(Keys.Delete))
                    {
                        ChangeGameState(0);
                    }
                }
                else
                {
                    // TODO: Add your update logic here
                    world.Update(gameTime);
                }
            }
            
            MCursor.Instance.UpdateOld();

            //camera.Follow(world.wizard.Sprite);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //spriteBatch.Begin(transformMatrix: camera.Transform);
            spriteBatch.Begin(transformMatrix: Camera.Instance.Transform);
            if (gameState == 0)
            {
                mainMenu.Draw(spriteBatch);
            }
            else if (gameState == 1)
            {
                world.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public virtual void ChangeGameState(object info)
        {
            gameState = Convert.ToInt32(info, Culture);
            if (gameState == 0)
            {
                IsMouseVisible = true;
            }
            else if (gameState == 1)
            {
                paused = false;
                IsMouseVisible = false;
            }
        }

        public virtual void ExitGame(object info)
        {
            System.Environment.Exit(0);
        }
    }
}
