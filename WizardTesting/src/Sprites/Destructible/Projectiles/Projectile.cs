using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public abstract class Projectile
    {
        public Sprite Sprite;

        public Vector2 Direction;
        public float Speed;

        protected bool done;
        public bool Done
        {
            get { return done; }
        }

        public Creature Owner;
        public MTimer Timer;

        public Projectile(string path, Vector2 position, Creature owner, Vector2 target)
        {
            Sprite = new Sprite(path, new Vector2(position.X, position.Y));
            Sprite.Rotation = Pathing.RotateTowards(Sprite.Position, target);

            done = false;
            Owner = owner;

            Speed = 100.0f;

            Timer = new MTimer(1000);

            Direction = target - position;
            Direction.Normalize();
        }

        public virtual void Update(GameTime gameTime, List<Creature> creatures)
        {
            Sprite.Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            Timer.UpdateTimer(gameTime);
            if(Timer.Test())
            {
                done = true;
            }

            if (HitSomething(creatures))
            {
                done = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public virtual bool HitSomething(List<Creature> creatures)
        {
            for (int i = creatures.Count - 1; i >= 0; i--)
            {
                if (Pathing.GetDistance(Sprite.Position, creatures[i].Sprite.Position) < creatures[i].HitDistance)
                {
                    creatures[i].GetHit(1);
                    return true;
                }
            }
            return false;
        }
    }
}
