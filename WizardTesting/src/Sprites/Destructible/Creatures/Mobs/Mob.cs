using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public abstract class Mob : Creature
    {
        public Mob(string path, Vector2 position, float scale, Vector2 frameCount, int switchFrame, int ownerId) : base(ownerId)
        {
            Sprite = new AnimatedSprite(path, new Vector2(position.X, position.Y), scale, frameCount, switchFrame);
            MoveSpeed = 100f;
        }
        public override void Update(GameTime gameTime, Player enemy)
        {
            AI(gameTime, enemy.Wizard);
            Sprite.IsActive = true;

            base.Update(gameTime, enemy);
        }

        public virtual void AI(GameTime gameTime, Wizard wizard)
        {
            Sprite.Position += Pathing.DirectionToward(Sprite.Position, wizard.Sprite.Position) * MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Sprite.Rotation = Pathing.RotateTowards(Sprite.Position, enemy.Sprite.Position);

            
            if (Pathing.GetDistance(Sprite.Position, wizard.Sprite.Position) < wizard.HitDistance )
            {
                wizard.GetHit(1);
                isDead = true;
            }
            
        }

    }
}
