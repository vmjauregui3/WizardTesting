using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public abstract class Creature : Destructible
    {
        // Creature is an abstract grouping of destructibles that have some form of intelligence commanding them.

        // Creatures have mana which determines when what abilities they can use and when.
        // TODO: Update mana with new stats variables.
        protected float mana;
        public float Mana
        {
            get { return mana; }
        }
        protected float manaMax;
        public float ManaMax
        {
            get { return manaMax; }
        }
        protected float manaRegen;
        public float ManaRegen
        {
            get { return manaRegen; }
        }
        protected MTimer manaTimer;

        public Creature(int ownderId) : base(ownderId)
        {
            MoveSpeed = 100.0f;
            mana = 100.0f;
            manaMax = mana;
            manaRegen = 0.5f;
            manaTimer = new MTimer(100);
        }

        public override void Update(GameTime gameTime, Player enemy)
        {
            manaTimer.UpdateTimer(gameTime);
            if (manaTimer.Test())
            {
                if (mana == manaMax)
                {

                }
                else if (mana + manaRegen <= manaMax)
                {
                    mana += manaRegen;
                    manaTimer.ResetToZero();
                }
                else if(mana + manaRegen > manaMax)
                {
                    mana = manaMax;
                    manaTimer.ResetToZero();
                }
            }

            base.Update(gameTime, enemy);
        }
    }
}
