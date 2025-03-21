﻿using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public abstract class Mob : Creature
    {
        // Mobs are creatures with an AI that instructs them on how to behave; they actively interact with the game environment.

        // The constructor requires the components to create both the Mob Creature and its Sprite.
        public Mob(string path, Vector2 position, float scale, Vector2 frameCount, int switchFrame, int ownerId) : base(ownerId)
        {
            Sprite = new AnimatedSprite(path, new Vector2(position.X, position.Y), scale, frameCount, switchFrame);
            MoveSpeed = new Stat(100f);
        }

        // Update requires the information of the Mob's enemy.
        public override void Update(GameTime gameTime, World world)
        {
            // Generic Mobs target the User's Wizard using default AI and are always active.
            AI(gameTime, world);
            Sprite.IsActive = true;

            base.Update(gameTime, world);
        }

        // Default AI moves straight toward User Wizard and deals 1 damage before dying.
        public virtual void AI(GameTime gameTime, World world)
        {
            Creature targetCreature = world.User.Wizard;
            Sprite.Position += Pathing.DirectionToward(Sprite.Position, targetCreature.Sprite.Position) * MoveSpeed.Value * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Sprite.Rotation = Pathing.RotateTowards(Sprite.Position, enemy.Sprite.Position);

            
            if (Pathing.GetDistance(Sprite.Position, targetCreature.Sprite.Position) < targetCreature.HitDistance )
            {
                targetCreature.AddHealth(-100);
                isDead = true;
            }
        }

    }
}
