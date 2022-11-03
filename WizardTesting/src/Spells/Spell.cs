using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public abstract class Spell
    {
        protected String name;
        public String Name
        {
            get { return name; }
        }

        protected int level;
        protected float manaCost;
        public float ManaCost
        {
            get { return manaCost; }
        }

        protected float damage;

        protected bool isActive;
        public bool IsActive
        {
            get { return isActive;  }
        }

        protected MTimer cooldownTimer;
        protected MTimer castingTimer;

        public Spell(float manaCost, int cooldown, int castTime)
        {
            level = 0;
            isActive = false;
            damage = 0f;
            this.manaCost = manaCost;
            cooldownTimer = new MTimer(cooldown);
            castingTimer = new MTimer(castTime);
        }

        public virtual void Update(GameTime gameTime)
        {
            cooldownTimer.UpdateTimer(gameTime);
            castingTimer.UpdateTimer(gameTime);
            if (cooldownTimer.Test())
            {
                cooldownTimer.ResetToZero();
            }

            if (castingTimer.Test())
            {
                castingTimer.ResetToZero();
            }
        }
    }
}

