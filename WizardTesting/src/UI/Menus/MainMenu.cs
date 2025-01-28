using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WizardTesting
{
    public class MainMenu
    {
        public Sprite background;

        public PassObject PlayClick, ExitClick;

        protected List<Button> buttons = new List<Button>();

        public MainMenu(PassObject playClick, PassObject exitClick) 
        {
            PlayClick = playClick;
            ExitClick = exitClick;

            Vector2 screenDimensions = new Vector2(WizardTesting.GameWidth, WizardTesting.GameHeight);

            background = new Sprite("Sprites/TitleScreenPlaceholder", Vector2.Zero, screenDimensions, Vector2.Zero);

            buttons.Add(new Button("Sprites/ButtonBlank", new Vector2((int)(screenDimensions.X/2 - 50), (int)screenDimensions.Y/2), new Vector2(100, 50), "Fonts/ComicSansMS16", "Start", PlayClick, 1));
            buttons.Add(new Button("Sprites/ButtonBlank", new Vector2((int)(screenDimensions.X / 2 - 50), ((int)screenDimensions.Y / 2 + 100)), new Vector2(100, 50), "Fonts/ComicSansMS16", "Quit", ExitClick, 0));
        }

        public virtual void Update()
        {
            Camera.Instance.UpdatePosition(new Vector2((int)WizardTesting.GameWidth/2, (int)WizardTesting.GameHeight/2));
            for (int i=0; i<buttons.Count; i++)
            {
                buttons[i].Update();
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);

            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Draw(spriteBatch);
            }
        }
    }
}
