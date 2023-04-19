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
        private static int tileSize = 64;
        private static int zoneSize = 10;
        private static int numTiles = 5;
        public Zone[,] ZoneMap;
        public Vector2 PlayerZone, PlayerZonePrev;

        public Map(Vector2 playerPosition) {
            ZoneMap = new Zone[5, 5];
            getPlayerZone(playerPosition);
            PlayerZonePrev = PlayerZone;

            //Random rnd = new Random();
            float[][] floatGrid = Perlin.GeneratePerlinNoise(zoneSize * ZoneMap.GetLength(0), zoneSize * ZoneMap.GetLength(1), 6);

            for (int j = 0; j < ZoneMap.GetLength(1); j++)
            {
                for (int i = 0; i < ZoneMap.GetLength(0); i++)
                {
                    ZoneMap[i, j] = new Zone(zoneSize, numTiles, floatGrid, new Vector2(i, j));
                }
            }
        }

        public void getPlayerZone(Vector2 playerPosition)
        {
            if ( playerPosition.X > 0 && playerPosition.X < ZoneMap.GetLength(0) * zoneSize * tileSize)
            {
                if (playerPosition.Y > 0 && playerPosition.Y < ZoneMap.GetLength(1) * zoneSize * tileSize)
                {
                    PlayerZonePrev = PlayerZone;
                    PlayerZone = new Vector2(playerPosition.X / (tileSize * zoneSize), playerPosition.Y / (tileSize * zoneSize));
                }
            }
        }

        public void Update(Vector2 playerPosition)
        {
            getPlayerZone(playerPosition);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            /*
            for (int j = 0; j < ZoneMap.GetLength(1); j++)
            {
                for (int i = 0; i < ZoneMap.GetLength(0); i++)
                {
                    ZoneMap[i, j].Background.Draw(spriteBatch);
                }
            }
            */
            int startY = 0;
            int endY = ZoneMap.GetLength(1) - 1;
            if ((int)PlayerZone.Y - 1 >= 0 )
            {
                startY = (int)PlayerZone.Y - 1;
            }
            if ((int)PlayerZone.Y + 1 < ZoneMap.GetLength(1))
            {
                endY = (int)PlayerZone.Y + 1;
            }

            int startX = 0;
            int endX = ZoneMap.GetLength(0) - 1;
            if ((int)PlayerZone.X - 1 >= 0)
            {
                startX = (int)PlayerZone.X - 1;
            }
            if ((int)PlayerZone.X + 1 < ZoneMap.GetLength(0))
            {
                endX = (int)PlayerZone.X + 1;
            }

            for (int j = startY; j <= endY; j++)
            {
                for (int i = startX; i <= endX; i++)
                {
                    ZoneMap[i, j].Background.Draw(spriteBatch);
                }
            }
        }
    }
}
