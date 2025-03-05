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
        protected VariableStat mana;
        public VariableStat Mana
        {
            get { return mana; }
        }
        protected VariableStat manaRegen;
        public VariableStat ManaRegen
        {
            get { return mana; }
        }
        protected MTimer manaTimer;

        public bool IsCasting;
        public List<Spell> Spells = new List<Spell>();
        protected Spell primarySpell;
        protected Spell secondarySpell;

        private float[] attributeMods;

        public Creature(int ownerId) : base(ownerId)
        {
            MoveSpeed = new Stat(100.0f);
            mana = new VariableStat(1000);
            manaRegen = new VariableStat(5);
            manaTimer = new MTimer(100);
            IsCasting = false;

            attributeMods = new float[Enum.GetNames(typeof(SpellAttribute)).Length];
            for (int i = 0; i < Enum.GetNames(typeof(SpellAttribute)).Length; i++)
            {
                attributeMods[i] = 1;
            }
        }

        public void ToggleCasting()
        {
            IsCasting = !IsCasting;
        }

        public void StartCasting()
        {
            IsCasting = true;
            MoveSpeed.AddModifier(0.1f, StatModifierType.PercentMultiply);
        }
        public void StopCasting()
        {
            IsCasting = false;
            MoveSpeed.RemoveModifier(0.1f, StatModifierType.PercentMultiply);
        }

        public override void Update(GameTime gameTime)
        {
            if (mana.Value != mana.ValueMax)
            {
                manaTimer.UpdateTimer(gameTime);
                if (manaTimer.Test())
                {
                    if (mana.Value + manaRegen.Value <= mana.ValueMax)
                    {
                        mana.AddValue(manaRegen.Value);
                        manaTimer.ResetToZero();
                    }
                    else if (mana.Value + manaRegen.Value > mana.ValueMax)
                    {
                        mana.SetValue(mana.ValueMax);
                        manaTimer.ResetToZero();
                    }
                }
            }

            base.Update(gameTime);
        }

        public override void Update(GameTime gameTime, World world)
        {
            if (mana.Value != mana.ValueMax)
            {
                manaTimer.UpdateTimer(gameTime);
                if (manaTimer.Test())
                {
                    if (mana.Value + manaRegen.Value <= mana.ValueMax)
                    {
                        mana.AddValue(manaRegen.Value);
                        manaTimer.ResetToZero();
                    }
                    else if (mana.Value + manaRegen.Value > mana.ValueMax)
                    {
                        mana.SetValue(mana.ValueMax);
                        manaTimer.ResetToZero();
                    }
                }
            }

            base.Update(gameTime, world);
        }

        // UpdateHealth damages the object and checks its life status afterward.
        // TODO: Complicate the damage calculation using updated stats variables.
        public virtual void UpdateMana(int manaCost)
        {
            mana.AddValue(-manaCost);
            if (mana.Value > mana.ValueMax)
            {
                mana.SetValue(mana.ValueMax);
            }
        }

        public override void UpdateHealthModified(float damage, SpellAttribute attribute)
        {
            float finalDamage = damage;

            finalDamage *= attributeMods[(int)attribute];

            UpdateHealth(finalDamage);
        }

        public bool HasMana(int manaCost)
        {
            bool hasMana = true;
            if (manaCost > mana.Value)
            {
                hasMana = false;
            }
            return hasMana;
        }
    }
}
