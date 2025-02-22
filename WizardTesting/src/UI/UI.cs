﻿using System;
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
        private DisplayBar manaBar;

        private Button tempButton;

        private int barWidth;
        private int barHeight;
        private int barBorder;
        public UI()
        {
            font = WizardTesting.WContent.Load<SpriteFont>("Fonts/ComicSansMS16");
            killCountString = "Enemies Killed: ";
            barWidth = 206;
            barHeight = 26;
            barBorder = 3;
            healthBar = new DisplayBar(new Vector2(barWidth, barHeight), barBorder, Color.Red);
            manaBar = new DisplayBar(new Vector2(barWidth, barHeight), barBorder, Color.Blue);

            tempButton = new Button("Sprites/ButtonBlank", Vector2.Zero, new Vector2(100, 50), "Fonts/ComicSansMS16", "TEST", null, null);
        }

        public void Update(Wizard userWizard)
        {
            screenOrigin = Vector2.Transform(Vector2.Zero, Matrix.Invert(Camera.Instance.Transform));
            healthBar.Update(userWizard.Health.Value, userWizard.Health.ValueMax, screenOrigin, barHeight);
            manaBar.Update(userWizard.Mana.Value, userWizard.Mana.ValueMax, screenOrigin, 0);
            tempButton.Update();
        }

        public void Draw(World world, SpriteBatch spriteBatch)
        {
            Vector2 stringDimensions = font.MeasureString(killCountString+world.NumKilled);
            spriteBatch.DrawString(font, killCountString + world.NumKilled, new Vector2(10, 10) + screenOrigin, Color.Black);
            healthBar.Draw(spriteBatch);
            manaBar.Draw(spriteBatch);
            tempButton.Draw(spriteBatch);
        }
    }
}
