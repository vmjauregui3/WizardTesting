using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public abstract class Building : Destructible
    {
        // Building is an abstract grouping of destructibles that are stationary structures.
        public Building(string path, Vector2 position, float scale, Vector2 frameCount, int switchFrame, int ownerId) : base(ownerId)
        {
            Sprite = new AnimatedSprite(path, new Vector2(position.X, position.Y), scale, frameCount, switchFrame);
        }
    }
}
