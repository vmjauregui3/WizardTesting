using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace WizardTesting
{
    public class SpellQuickbarIcon : Sprite
    {
        protected Vector2 iconOffset;

        protected string text;
        protected Vector2 stringDimensions;
        protected Vector2 stringPosition;

        protected Color color;

        protected SpriteFont font;

        protected Spell spell;

        public SpellQuickbarIcon(string path, Vector2 position, Vector2 dimensions, Spell spell, Vector2 offset)
            : base(path, position, dimensions, Vector2.Zero)
        {
            this.spell = spell;
            text = "Firebolt";

            iconOffset = offset;

            font = WizardTesting.WContent.Load<SpriteFont>("Fonts/ComicSansMS16");

            stringDimensions = font.MeasureString(text);
            stringPosition = Position + new Vector2((Dimensions.X - stringDimensions.X) / 2, (Dimensions.Y - stringDimensions.Y) / 2);
        }

        public virtual void Update(Vector2 reference)
        {
            Position = reference + iconOffset;
            //Position = iconOffset;
            stringPosition = Position + new Vector2((Dimensions.X - stringDimensions.X) / 2, (Dimensions.Y - stringDimensions.Y) / 2);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.DrawString(font, text, stringPosition, Color.Black);
        }
    }
}
