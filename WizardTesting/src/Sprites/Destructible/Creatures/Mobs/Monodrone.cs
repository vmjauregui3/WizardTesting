using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class Monodrone : Mob
    {
        public Monodrone(string path, Vector2 position, float scale, Vector2 frameCount, int switchFrame, int ownerId) : base(path, position, scale, frameCount, switchFrame, ownerId)
        {

        }

        public override void Update(GameTime gameTime, Player enemy)
        {
            if (enemy.Wizard.Sprite.Position.X > Sprite.Position.X)
            {
                if (Sprite.CurrentFrame.Y != 2)
                { Sprite.CurrentFrame.Y = 2; }
            }
            else if (enemy.Wizard.Sprite.Position.X < Sprite.Position.X)
            {
                if (Sprite.CurrentFrame.Y != 1)
                { Sprite.CurrentFrame.Y = 1; }
            }

            base.Update(gameTime, enemy);
        }

    }
}
