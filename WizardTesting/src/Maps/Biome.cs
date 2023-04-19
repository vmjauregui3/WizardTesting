using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class Biome
    {
        public int Type;
        public Biome(int type)
        {
            Type = type;
        }

        public Color GetShadeUsingPerlinNoise(float noiseFloat)
        {
            float perlin = Math.Clamp(noiseFloat, 0.0f, 1.0f);
            float baseColor = 100 + perlin * 100;
            float redVal = baseColor;
            float blueVal = baseColor;
            float greenVal = baseColor;
            perlin = 100 + perlin * 155;
            if (perlin >= 255)
            {
                perlin = 255;
            }

            if ( Type == 0 )
            {
                redVal = perlin;
            }
            else if ( Type == 1 )
            {
                blueVal = perlin;
            }
            else if (Type == 2)
            {
                greenVal = perlin;
            }

            return new Color((int)MathF.Floor(redVal), (int)MathF.Floor(blueVal), (int)MathF.Floor(greenVal));
        }
    }
}
