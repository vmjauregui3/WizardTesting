using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using static System.Net.Mime.MediaTypeNames;

namespace WizardTesting
{
    public class UI
    {
        private SpriteFont font;
        private Vector2 screenOrigin;

        private StatDisplayBar healthBar;
        private StatDisplayBar manaBar;

        private bool showingStatBars;
        private List<StatDisplayBar> statBars;

        private Button tempButton;

        private int barWidth;
        private int barHeight;
        private int barBorder;

        // Contains the representation of the cursor on the screen and gameworld for user visibility and game referencing.
        public Sprite Cursor;

        public UI()
        {
            // Creates a representation of the cursor on the screen and gameworld for user visibility and game referencing where the mouse is.
            Cursor = new Sprite("Sprites/Cursor", new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y), 1.0f, Vector2.Zero);

            font = WizardTesting.WContent.Load<SpriteFont>("Fonts/ComicSansMS16");
            barWidth = 206;
            barHeight = 26;
            barBorder = 3;
            Vector2 barBackOffset = new Vector2(10, (int)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 10 - 2*barHeight);
            healthBar = new StatDisplayBar(new Vector2(barWidth, barHeight), barBorder, Color.Red, barBackOffset);
            barBackOffset = new Vector2(barBackOffset.X, barBackOffset.Y + barHeight);
            manaBar = new StatDisplayBar(new Vector2(barWidth, barHeight), barBorder, Color.Blue, barBackOffset);

            showingStatBars = false;
            statBars = new List<StatDisplayBar>();

            tempButton = new Button("Sprites/ButtonBlank", Vector2.Zero, new Vector2(100, 50), "Fonts/ComicSansMS16", "TEST", null, null);
        }

        public void ShowStatBars(List<Destructible> destructibles)
        {
            statBars.Clear();
            foreach (Destructible destructible in destructibles)
            {
                if (destructible.IsLoaded)
                {
                    statBars.Add(new StatDisplayBar(new Vector2(destructible.Sprite.Dimensions.X, 10), 1, Color.Red, new Vector2(-(destructible.Sprite.Dimensions.X / 2), -(destructible.Sprite.Dimensions.Y/2)-12)));
                    statBars[^1].Update(destructible.Health, destructible.Sprite.Position);
                }
            }
        }

        public void ToggleStatBars()
        {
            showingStatBars = !showingStatBars;
            statBars.Clear();
        }

        public void Update(User user, World world)
        {
            Cursor.Position = Vector2.Transform(new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y), Matrix.Invert(Camera.Instance.Transform));

            screenOrigin = Vector2.Transform(Vector2.Zero, Matrix.Invert(Camera.Instance.Transform));
            healthBar.Update(user.Wizard.Health, screenOrigin);
            manaBar.Update(user.Wizard.Mana, screenOrigin);
            tempButton.Update();
            if (showingStatBars)
            {
                ShowStatBars(world.AllDestructibles);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Vector2 stringDimensions = font.MeasureString(killCountString+world.NumKilled);
            //spriteBatch.DrawString(font, killCountString + world.NumKilled, new Vector2(10, 10) + screenOrigin, Color.Black);
            healthBar.Draw(spriteBatch);
            manaBar.Draw(spriteBatch);

            foreach (StatDisplayBar statBar in statBars)
            {
                statBar.Draw(spriteBatch);
            }

            tempButton.Draw(spriteBatch);

            Cursor.Draw(spriteBatch);
        }
    }
}
