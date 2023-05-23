using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class Square : Mob
    {
        public FireBolt spell;
        public MTimer CastTimer;
        public Square(Vector2 position, int ownerId) : base("Sprites/Mobs/Square", position, 1f, new Vector2(1, 1), 0, ownerId)
        {
            CastTimer = new MTimer(1000);
            spell = new FireBolt(this);
        }

        public override void Update(GameTime gameTime, Player enemy)
        {
            CastTimer.UpdateTimer(gameTime);
            if (CastTimer.Test())
            {
                spell.CastSpell(enemy.Wizard.Sprite.Position);
                CastTimer.ResetToZero();
            }

            base.Update(gameTime, enemy);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
