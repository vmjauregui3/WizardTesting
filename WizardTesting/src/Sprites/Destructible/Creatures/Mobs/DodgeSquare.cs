using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class DodgeSquare : Mob
    {
        public FireBolt spell;
        public MTimer CastTimer;
        public DodgeSquare(Vector2 position, int ownerId) : base("Sprites/Mobs/Square", position, 1f, new Vector2(1, 1), 0, ownerId)
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

        public override void AI(GameTime gameTime, Wizard wizard)
        {
            
            Sprite.Position += Pathing.DirectionToward(Sprite.Position, wizard.Sprite.Position) * MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (Pathing.GetDistance(Sprite.Position, wizard.Sprite.Position) < wizard.HitDistance)
            {
                wizard.UpdateHealth(100);
                isDead = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
