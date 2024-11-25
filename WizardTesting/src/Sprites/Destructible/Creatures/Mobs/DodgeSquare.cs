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

        public override void Update(GameTime gameTime, World world)
        {
            CastTimer.UpdateTimer(gameTime);
            if (CastTimer.Test())
            {
                spell.CastSpell(world.User.Wizard.Sprite.Position);
                CastTimer.ResetToZero();
            }

            base.Update(gameTime, world);
        }

        public override void AI(GameTime gameTime, World world)
        {
            Creature targetCreature = world.User.Wizard;
            for (int i = world.Projectiles.Count - 1; i >= 0; i--)
            {
                if (world.Projectiles[i].Owner.OwnerId != OwnerId)
                {
                    Vector2 ThreatVector = Pathing.DirectionToward(world.Projectiles[i].Sprite.Position, Sprite.Position);
                }
            }
            Sprite.Position += Pathing.DirectionToward(Sprite.Position, targetCreature.Sprite.Position) * MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (Pathing.GetDistance(Sprite.Position, targetCreature.Sprite.Position) < targetCreature.HitDistance)
            {
                targetCreature.UpdateHealth(100);
                isDead = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
