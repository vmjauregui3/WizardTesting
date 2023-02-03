using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class Map
    {
        private int numTiles = 5;
        public Layer Background;
        public int[,] TileGrid;
        public Color[,] TileShades;
        public Map() {
            TileGrid = new int[100, 100];
            TileShades = new Color[TileGrid.GetLength(0), TileGrid.GetLength(1)];

            Random rnd = new Random();
            for (int j = 0; j < TileGrid.GetLength(1); j++)
            {
                for (int i = 0; i < TileGrid.GetLength(0); i++)
                {
                    TileGrid[i, j] = rnd.Next(0, numTiles);
                    TileShades[i, j] = new Color(255, 255, 255);
                }
            }

            Background = new Layer("TileSheets/GroundTilesReduced", new Vector2(numTiles, 1), new Vector2(-50, -50), TileGrid, TileShades);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Background.Draw(spriteBatch);
        }
    }
}
