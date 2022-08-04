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

        public Creature(int ownderId) : base(ownderId)
        {
            MoveSpeed = 100.0f;
            mana = 100.0f;
            manaMax = mana;
            manaRegen = 5;
        }
    }
}
