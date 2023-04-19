using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class Zone
    {
        public Layer Background;
        public int[,] TileGrid;
        public Color[,] TileShades;

        public Zone(int zoneSize, int numTiles, float[][] floatGrid, Vector2 zonePosition)
        {
            TileGrid = new int[zoneSize, zoneSize];
            TileShades = new Color[zoneSize, zoneSize];

            for (int j = 0; j < TileGrid.GetLength(1); j++)
            {
                for (int i = 0; i < TileGrid.GetLength(0); i++)
                {
                    TileGrid[i, j] = GetIDUsingPerlinNoise(floatGrid[(int)zonePosition.X * zoneSize + i][(int)zonePosition.Y * zoneSize + j], 0, 1);
                    TileShades[i, j] = GetShadeUsingPerlinNoise(floatGrid[(int)zonePosition.X * zoneSize + i][(int)zonePosition.Y * zoneSize + j]);
                }
            }

            Background = new Layer("TileSheets/GroundTilesReduced", new Vector2(numTiles, 1), new Vector2(zoneSize * zonePosition.X, zoneSize * zonePosition.Y), TileGrid, TileShades);
        }

        public int GetIDUsingPerlinNoise(float noiseFloat, int min, int max)
        {
            float perlin = Math.Clamp(noiseFloat, 0.0f, 1.0f);
            perlin = min + perlin * max;
            if (perlin >= max)
            {
                perlin = max - 1;
            }
            return (int)MathF.Floor(perlin);
        }

        public Color GetShadeUsingPerlinNoise(float noiseFloat)
        {
            float perlin = Math.Clamp(noiseFloat, 0.0f, 1.0f);
            perlin = 100 + perlin * 155;
            if (perlin >= 255)
            {
                perlin = 255;
            }
            return new Color((int)MathF.Floor(perlin), (int)MathF.Floor(perlin), (int)MathF.Floor(perlin));
        }
    }
}
