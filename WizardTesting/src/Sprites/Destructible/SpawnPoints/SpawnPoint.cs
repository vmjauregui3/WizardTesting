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
            health = new VariableStat(100);
        }

        public override void Update(GameTime gameTime, World world)
        {
            SpawnTimer.UpdateTimer(gameTime);
            if(SpawnTimer.Test())
            {
                SpawnMob();
                SpawnTimer.ResetToZero();
            }

            base.Update(gameTime, world);
        }

        public virtual void GetHit()
        {
            isDead = true;
        }

        public virtual void SpawnMob()
        {
            GameCommands.PassCreature(new Triangle(new Vector2(Sprite.Position.X, Sprite.Position.Y), OwnerId));
        }
    }
}
