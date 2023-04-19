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
        private static int zoneSize = 5;
        private static int numTiles = 5;
        public Dictionary<string, Zone> Zones;
        public HashSet<string> LoadedZones;
        public Vector2 PlayerZone, PlayerZonePrev;

        public Map(Vector2 playerPosition) {
            Zones = new Dictionary<string, Zone>();
            LoadedZones = new HashSet<string>();
            getPlayerZone(playerPosition);
            PlayerZonePrev = PlayerZone;

            //Random rnd = new Random();
            //float[][] floatGrid = Perlin.GeneratePerlinNoise(zoneSize * ZoneMap.GetLength(0), zoneSize * ZoneMap.GetLength(1), 6);

            for (int j = (int)PlayerZone.Y - 3; j < (int)PlayerZone.Y + 3; j++)
            {
                for (int i = (int)PlayerZone.X - 3; i < (int)PlayerZone.X + 3; i++)
                {
                    string zoneKey = i + "_" + j;
                    Zones.Add(zoneKey, new Zone(zoneSize, numTiles, new Vector2(i, j)));
                    LoadedZones.Add(zoneKey);
                }
            }
        }

        public void getPlayerZone(Vector2 playerPosition)
        {
            PlayerZonePrev = PlayerZone;
            PlayerZone = new Vector2(playerPosition.X / (tileSize * zoneSize), playerPosition.Y / (tileSize * zoneSize));
        }

        public void Update(Vector2 playerPosition)
        {
            LoadedZones.Clear();
            getPlayerZone(playerPosition);

            int startY = (int)PlayerZone.Y - 1;
            int endY = (int)PlayerZone.Y + 1;
            if (playerPosition.Y < 0)
            {
                startY -= 1;
                endY -= 1;
            }
            int startX = (int)PlayerZone.X - 1;
            int endX = (int)PlayerZone.X + 1;
            if (playerPosition.X < 0)
            {
                startX -= 1;
                endX -= 1;
            }
            for (int j = startY; j <= endY; j++)
            {
                for (int i = startX; i <= endX; i++)
                {
                    string zoneKey = i + "_" + j;
                    if (!Zones.ContainsKey(zoneKey))
                    {
                        Zones.Add(i + "_" + j, new Zone(zoneSize, numTiles, new Vector2(i, j)));
                    }
                    LoadedZones.Add(zoneKey);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (string key in LoadedZones)
            {
                Zones[key].Background.Draw(spriteBatch);
            }
        }
    }
}
