using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WizardTesting
{
    public class UI
    {
        private SpriteFont font;
        private Vector2 screenOrigin;

        private string killCountString;
        private DisplayBar healthBar; 
        public UI()
        {
            font = WizardTesting.WContent.Load<SpriteFont>("Fonts/ComicSansMS16");
            killCountString = "Enemies Killed: ";
            healthBar = new DisplayBar(new Vector2(206,26), 3, Color.Red);
        }

        public void Update(World world)
        {
            screenOrigin = Vector2.Transform(Vector2.Zero, Matrix.Invert(Camera.Instance.Transform));
            healthBar.Update(world.User.Wizard.Health, world.User.Wizard.HealthMax, screenOrigin);
        }

        public void Draw(World world, SpriteBatch spriteBatch)
        {
            Vector2 stringDimensions = font.MeasureString(killCountString+world.NumKilled);
            spriteBatch.DrawString(font, killCountString + world.NumKilled, new Vector2(10, 10) + screenOrigin, Color.Black);
            healthBar.Draw(spriteBatch);
        }
    }
}
