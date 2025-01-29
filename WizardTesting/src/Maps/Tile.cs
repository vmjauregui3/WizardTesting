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
        protected Texture2D texture;
        protected Rectangle sourceRect;

        protected bool filled;
        public bool Filled
        {
            get { return filled;  }
        }

        protected bool unpassable;
        public bool Unpassable
        {
            get { return unpassable; }
        }

        protected bool unpathable;
        public bool Upathable
        {
            get { return unpathable; }
        }

        protected float cost;
        public float Cost
        {
            get { return cost; }
        }

        public Tile(Texture2D texture, Rectangle sourceRect, Vector2 dimensions)
        {
            this.texture = texture;
            this.sourceRect = sourceRect;
            this.dimensions = dimensions;
        }

        public void ChangeTile(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)dimensions.X, (int)dimensions.Y),
                sourceRect, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0.0f);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)dimensions.X, (int)dimensions.Y),
                sourceRect, color, 0f, new Vector2(0, 0), SpriteEffects.None, 0.0f);
        }
    } 
}
