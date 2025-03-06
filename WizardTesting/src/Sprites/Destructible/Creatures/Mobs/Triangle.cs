using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class Triangle : Mob
    {
        public Creature Owner;
        private float orbitAngle, orbitDistance;
        public Triangle(Vector2 position, int ownerId) : base("Sprites/Mobs/Triangle", position, 1f, new Vector2(1, 1), 0, ownerId)
        {
            MoveSpeed = new Stat(300f);
            orbitDistance = 500.0f;
            orbitAngle = 0.0f;
        }

        public Triangle(Vector2 position, Creature owner) : base("Sprites/Mobs/Triangle", position, 1f, new Vector2(1, 1), 0, owner.OwnerId)
        {
            MoveSpeed = new Stat(300f);
            orbitDistance = 500.0f;
            orbitAngle = 0.0f;
            Owner = owner;
        }

        public override void Update(GameTime gameTime, World world)
        {
            base.Update(gameTime, world);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void AI(GameTime gameTime, World world)
        {
            Creature targetCreature = world.User.Wizard;
            //Sprite.Rotation = Pathing.RotateTowards(Sprite.Position, wizard.Sprite.Position);

            orbitAngle += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (orbitAngle > MathF.PI * 2)
            {
                orbitAngle -= MathF.PI*2;
            }

            if (!Owner.IsDead)
            {
                Sprite.Position += Pathing.OrbitToward(Sprite.Position, Owner.Sprite.Position, orbitDistance, orbitAngle) * MoveSpeed.Value * (float)gameTime.ElapsedGameTime.TotalSeconds;
                //Sprite.Rotation = Pathing.RotateTowards(Sprite.Position, Pathing.OrbitToward(Sprite.Position, wizard.Sprite.Position, orbitDistance, orbitAngle + 0.2f) * orbitDistance);
                Sprite.Rotation = orbitAngle + 0.75f * MathF.PI;
            }

            if (Pathing.GetDistance(Sprite.Position, targetCreature.Sprite.Position) < targetCreature.HitDistance)
            {
                targetCreature.AddHealth(-10);
                isDead = true;
            }
        }
    }
}
