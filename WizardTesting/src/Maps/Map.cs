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

        public Map() {
            Zones = new Dictionary<string, Zone>();
            
            //Random rnd = new Random();
            //float[][] floatGrid = Perlin.GeneratePerlinNoise(zoneSize * ZoneMap.GetLength(0), zoneSize * ZoneMap.GetLength(1), 6);
        }

        public Vector2 getZone(Vector2 position)
        {
            return new Vector2( (int)Math.Floor(position.X / (tileSize * zoneSize)), (int)Math.Floor(position.Y / (tileSize * zoneSize)));
        }

        public void CheckHasKey(int i, int j)
        {
            string zoneKey = i + "_" + j;
            if (!Zones.ContainsKey(zoneKey))
            {
                Zones.Add(i + "_" + j, new Zone(zoneSize, numTiles, new Vector2(i, j)));
            }
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, HashSet<string> loadedZones)
        {
            foreach (string key in loadedZones)
            {
                Zones[key].Layer.Draw(spriteBatch);
            }
        }
    }
}
