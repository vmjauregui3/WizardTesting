using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WizardTesting
{
    public abstract class Destructible
    {
        public AnimatedSprite Sprite;

        protected Vector2 Velocity;
        public float MoveSpeed;

        protected float health;
        public float Health
        {
            get { return health; }
        }
        protected float healthMax;
        public float HealthMax
        {
            get { return healthMax; }
        }

        protected float hitDistance;
        public float HitDistance
        {
            get { return hitDistance; }
        }

        protected bool isDead;
        public bool IsDead
        {
            get { return isDead; }
        }

        private int ownerId;
        public int OwnerId
        {
            get { return ownerId; }
        }

        public Destructible(int ownerId)
        {
            this.ownerId = ownerId;
            isDead = false;
            hitDistance = 35.0f;
            MoveSpeed = 0.0f;
            health = 1f;
            healthMax = health;
        }

        public virtual void GetHit(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                isDead = true;
            }
        }

        public virtual void Update(GameTime gameTime, Player enemy)
        {
            Sprite.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }
    }
}
