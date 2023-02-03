using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace WizardTesting
{
    public class Layer
    {
        protected Vector2 dimensions;

        public Vector2 AmountOfTiles;

        // Sprites' Textures are what is seen by the users. The sourceRect is what portion of the png is shown.
        protected Texture2D Texture;
        protected Rectangle sourceRect;

        protected int frameWidth;
        protected int frameHeight;

        private Vector2 position;

        private List<Tile> tiles = new List<Tile>();
        private int[,] tileGrid;
        private Color[,] tileShades;

        int squareSize = 64;

        public Layer(string path, Vector2 tileCount, Vector2 position, int[,] tileGrid, Color[,] tileShades)
        {
            Texture = WizardTesting.WContent.Load<Texture2D>(path);
            AmountOfTiles = tileCount;
            this.position = position;
            this.tileGrid = tileGrid;
            this.tileShades = tileShades;

            if (Texture != null)
            {
                frameWidth = Texture.Width / (int)AmountOfTiles.X;
                frameHeight = Texture.Height / (int)AmountOfTiles.Y;
            }
            dimensions = new Vector2(frameWidth, frameHeight);

            for (int i = 0; i < AmountOfTiles.X; i++)
            {
                Rectangle sourceRect = new Rectangle(squareSize * i, 0, squareSize, squareSize);
                tiles.Add(new Tile(Texture, sourceRect));
            }

            this.tileShades = tileShades;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int j = 0; j < tileGrid.GetLength(1); j++)
            {
                for (int i = 0; i < tileGrid.GetLength(0); i++)
                {
                    tiles[tileGrid[i, j]].Draw(spriteBatch, new Vector2(position.X * 32 + 32 * i, position.Y * 32 + 32 * j), tileShades[i,j]);
                }
            }
        }
    }
}
