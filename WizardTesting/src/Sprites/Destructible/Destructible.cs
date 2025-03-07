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
        public Vector2 Velocity;
        public Stat MoveSpeed;

        // Objects have health which determines when they get destroyed.
        protected VariableStat health;
        public VariableStat Health
        {
            get { return health; }
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

        protected bool isLoaded;
        public bool IsLoaded
        {
            get { return isLoaded; }
        }

        // The constructor requires an ID to be created.
        public Destructible(int ownerId)
        {
            this.ownerId = ownerId;
            isDead = false;
            hitDistance = 35.0f;
            MoveSpeed = new Stat(0.0f);
            health = new VariableStat(10);
        }

        public void CheckIfDead()
        {
            if (health.Value <= 0)
            {
                isDead = true;
            }
        }
        public void SetIsLoaded(bool isLoaded)
        {
            this.isLoaded = isLoaded;
        }

        // UpdateHealth damages the object and checks its life status afterward.
        // TODO: Complicate the damage calculation using updated stats variables.
        public virtual void AddHealthModified(float damage, SpellAttribute attribute)
        {
            AddHealth(-damage);
        }

        public virtual void AddHealth(float damage)
        {
            health.AddValue(damage);
            if (health.Value > health.ValueMax)
            {
                health.SetValue(health.ValueMax);
            }
            else if (health.Value < 0)
            {
                health.SetValue(0);
            }
            CheckIfDead();
        }

        public virtual void TranslatePosition(Vector2 translation)
        {
            Sprite.Position += translation;
        }

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        // Updates the Sprite.
        public virtual void Update(GameTime gameTime, World world)
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
