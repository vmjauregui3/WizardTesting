using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace WizardTesting
{
    public class BackgroundSpriteSheet
    {
        protected Vector2 dimensions;

        public Vector2 AmountOfTiles;

        // Sprites' Textures are what is seen by the users. The sourceRect is what portion of the png is shown.
        protected Texture2D Texture;
        protected Rectangle sourceRect;

        protected int frameWidth;
        protected int frameHeight;

        private List<BackgroundTile> tiles = new List<BackgroundTile>();

        public BackgroundSpriteSheet(string path, Vector2 tileCount)
        {
            Texture = WizardTesting.WContent.Load<Texture2D>(path);
            AmountOfTiles = tileCount;

            if (Texture != null)
            {
                frameWidth = Texture.Width / (int)AmountOfTiles.X;
                frameHeight = Texture.Height / (int)AmountOfTiles.Y;
            }
            dimensions = new Vector2((int)frameWidth, (int)frameHeight);

            for (int i = 0; i < AmountOfTiles.X; i++)
            {
                Rectangle sourceRect = new Rectangle(32 * i, 0, 32, 32);
                tiles.Add(new BackgroundTile(Texture, sourceRect));
            }
        }

        public void Draw(SpriteBatch spriteBatch, int tile, Vector2 startpos, Vector2 endpos)
        {
            int xlength = (int)endpos.X - (int)startpos.X;
            int ylength = (int)endpos.Y - (int)startpos.Y;
            for (int j = 0; j < xlength; j++)
            {
                for (int i = 0; i < ylength; i++)
                {
                    tiles[tile].Draw(spriteBatch, new Vector2(startpos.X * 32 + 32 * i, startpos.Y * 32 + 32 * j));
                }
            }
        }
    }

    public class BackgroundTile
    {
        protected Vector2 dimensions = new Vector2(32, 32);
        protected float scale;

        // Sprites' Textures are what is seen by the users. The sourceRect is what portion of the png is shown.
        protected Texture2D Texture;
        protected Rectangle sourceRect;

        public BackgroundTile(Texture2D texture, Rectangle sourceRect)
        {
            Texture = texture;
            this.sourceRect = sourceRect;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)position.X, (int)position.Y, (int)dimensions.X, (int)dimensions.Y),
                sourceRect, Color.White, 0f, new Vector2(0,0), SpriteEffects.None, 0.0f);
        }
    }
}
