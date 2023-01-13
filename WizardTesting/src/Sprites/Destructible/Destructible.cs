using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WizardTesting
{
    // TODO: Requires Updated Stat Variables
    // TODO: Create an inherited Class that defines anything with agency in the game environment (such as indestructible buildings).
    public abstract class Destructible
    {
        // Destructibles are objects that represent everything in the game that has hit points and can be destroyed.

        // Destructibles contain a sprite that represents them visiually and contains their game location.
        public AnimatedSprite Sprite;

        // All game objects have a direction and speed.
        protected Vector2 Velocity;
        public float MoveSpeed;

        // Objects have health which determines when they get destroyed.
        // TODO: Update health with new stats variables.
        protected float health;
        public float Health
        {
            get { return health; }
        }
        protected int healthMax;
        public int HealthMax
        {
            get { return healthMax; }
        }
        
        // Objests current render collisions with their distance from other objects.
        // TODO: Improve collision detection
        protected float hitDistance;
        public float HitDistance
        {
            get { return hitDistance; }
        }

        // isDead tracks when the object still needs to be updated and drawn.
        protected bool isDead;
        public bool IsDead
        {
            get { return isDead; }
        }

        // ownerID determines how the object interacts with its surroundings.
        private int ownerId;
        public int OwnerId
        {
            get { return ownerId; }
        }

        // The constructor requires an ID to be created.
        public Destructible(int ownerId)
        {
            this.ownerId = ownerId;
            isDead = false;
            hitDistance = 35.0f;
            MoveSpeed = 0.0f;
            healthMax = 10;
            health = healthMax;
        }

        // UpdateHealth damages the object and checks its life status afterward.
        // TODO: Complicate the damage calculation using updated stats variables.
        public virtual void UpdateHealth(float damage)
        {
            health -= damage;
            if (health > healthMax)
            {
                health = healthMax;
            }
            CheckIfDead();
        }

        public void CheckIfDead()
        {
            if (health <= 0)
            {
                isDead = true;
            }
        }

        // Updates the Sprite.
        public virtual void Update(GameTime gameTime, Player enemy)
        {
            Sprite.Update(gameTime);
        }

        // Draws the Sprite.
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }
    }
}
