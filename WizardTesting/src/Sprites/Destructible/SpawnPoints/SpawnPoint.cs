﻿using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WizardTesting
{
    public class SpawnPoint : Destructible
    {
        public MTimer SpawnTimer;

        public SpawnPoint(string path, Vector2 position, int ownerId) : base(ownerId)
        {
            Sprite = new AnimatedSprite(path, new Vector2(position.X, position.Y), 1f, Vector2.One, 0);

            SpawnTimer = new MTimer(2500);
            isDead = false;
            hitDistance = 25.0f;
            health = 10;
            healthMax = health;
        }

        public virtual void Update(GameTime gameTime)
        {
            SpawnTimer.UpdateTimer(gameTime);
            if(SpawnTimer.Test())
            {
                SpawnMob();
                SpawnTimer.ResetToZero();
            }
        }

        public virtual void GetHit()
        {
            isDead = true;
        }

        public virtual void SpawnMob()
        {
            GameCommands.PassCreature(new Triangle("Sprites/Mobs/Triangle", new Vector2(Sprite.Position.X, Sprite.Position.Y), new Vector2(1,1), 0, OwnerId));
        }
    }
}
