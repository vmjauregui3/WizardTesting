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
        protected int manaMax;
        public int ManaMax
        {
            get { return manaMax; }
        }
        protected float manaRegenMax;
        public float ManaRegenMax
        {
            get { return manaRegenMax; }
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
            manaMax = 100;
            mana = manaMax;
            manaRegenMax = 0.5f;
            manaRegen = manaRegenMax;
            manaTimer = new MTimer(100);
        }

        public override void Update(GameTime gameTime, Player enemy)
        {
            if (mana != manaMax)
            {
                manaTimer.UpdateTimer(gameTime);
                if (manaTimer.Test())
                {
                    if (mana + manaRegen <= manaMax)
                    {
                        mana += manaRegen;
                        manaTimer.ResetToZero();
                    }
                    else if (mana + manaRegen > manaMax)
                    {
                        mana = manaMax;
                        manaTimer.ResetToZero();
                    }
                }
            }

            base.Update(gameTime, enemy);
        }

        // UpdateHealth damages the object and checks its life status afterward.
        // TODO: Complicate the damage calculation using updated stats variables.
        public virtual void UpdateMana(float manaCost)
        {
            mana -= manaCost;
            if (mana > manaMax)
            {
                mana = manaMax;
            }
        }

        public bool HasMana(float manaCost)
        {
            bool hasMana = true;
            if (manaCost > mana)
            {
                hasMana = false;
            }
            return hasMana;
        }
    }
}
