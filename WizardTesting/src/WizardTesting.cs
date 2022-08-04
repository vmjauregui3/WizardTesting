using Microsoft.Xna.Framework;
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

        private World world;

        public static Random rand = new Random();

        public static ContentManager WContent;

        public static System.Globalization.CultureInfo Culture = new System.Globalization.CultureInfo("en-US");

        public WizardTesting()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = false;

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

            world = new World();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            { Exit(); }

            // TODO: Add your update logic here

            world.Update(gameTime);

            //camera.Follow(world.wizard.Sprite);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //spriteBatch.Begin(transformMatrix: camera.Transform);
            spriteBatch.Begin(transformMatrix: Camera.Instance.Transform);
            world.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
