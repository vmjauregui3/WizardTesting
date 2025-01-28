using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class Tile
    {
        protected Vector2 dimensions;
        protected float scale;

        // Sprites' Textures are what is seen by the users. The sourceRect is what portion of the png is shown.
        protected Texture2D Texture;
        protected Rectangle sourceRect;

        protected bool filled, impassible, unpathable;
        protected float cost;

        public Tile(Texture2D texture, Rectangle sourceRect, Vector2 dimensions)
        {
            Texture = texture;
            this.sourceRect = sourceRect;
            this.dimensions = dimensions;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)position.X, (int)position.Y, (int)dimensions.X, (int)dimensions.Y),
                sourceRect, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0.0f);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)position.X, (int)position.Y, (int)dimensions.X, (int)dimensions.Y),
                sourceRect, color, 0f, new Vector2(0, 0), SpriteEffects.None, 0.0f);
        }
    } 
}
