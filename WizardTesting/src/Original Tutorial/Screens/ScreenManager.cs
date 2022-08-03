using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WizardTesting
{
    public class ScreenManager
    {
        /*
        private static ScreenManager instance;
        [XmlIgnore]
        public Vector2 Dimensions { get; private set; }
        [XmlIgnore]
        public ContentManager Content { get; private set; }
        XmlManager<GameScreen> xmlGameScreenManager;
        
        GameScreen currentScreen, newScreen;
        [XmlIgnore]
        public GraphicsDevice GraphicsDevice;
        [XmlIgnore]
        public SpriteBatch SpriteBatch;
        
        public Image Image;
        [XmlIgnore]
        public bool IsTransitioning { get; private set; }

        public static ScreenManager Instance 
        { 
            get 
            {
                if (instance == null)
                {
                    XmlManager<ScreenManager> xml = new XmlManager<ScreenManager>();
                    instance = xml.Load("src/Load/ScreenManager.xml"); 
                }
                return instance; 
            } 
        }

        public void ChangeScreens(string screenName)
        {
            newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("WizardTesting." + screenName));
            Image.IsActive = true;
            Image.FadeEffect.Increase = true;
            Image.Alpha = 0.0f;
            IsTransitioning = true;
        }

        private void Transition(GameTime gameTime)
        {
            if(IsTransitioning)
            {
                Image.Update(gameTime);
                if(Image.Alpha == 1.0f)
                { 
                    currentScreen.UnloadContent();
                    currentScreen = newScreen;
                    xmlGameScreenManager.Type = currentScreen.Type;
                    if(File.Exists(currentScreen.XmlPath))
                    {
                        currentScreen = xmlGameScreenManager.Load(currentScreen.XmlPath);
                    }
                    currentScreen.LoadContent();
                }    
                else if (Image.Alpha == 0.0f)
                {
                    Image.IsActive = false;
                    IsTransitioning = false; 
                }
            }
        }

        public ScreenManager()
        {
            Dimensions = new Vector2(
                (int)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
                (int)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
            currentScreen = new SplashScreen(); // Changed for Testing
            //currentScreen = new GameplayScreen();
            xmlGameScreenManager = new XmlManager<GameScreen>();
            xmlGameScreenManager.Type = currentScreen.Type;
            currentScreen = xmlGameScreenManager.Load("src/Load/SplashScreen.xml"); //Changed for Testing

        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent();
            Image.LoadContent();
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
            Transition(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
            if(IsTransitioning)
            { Image.Draw(spriteBatch); }
        }
        */
    }
}
