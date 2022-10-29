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
        protected int manaCost;
        public int ManaCost
        {
            get { return manaCost; }
        }

        protected bool isActive;
        public bool IsActive
        {
            get { return isActive;  }
        }

        protected MTimer cooldownTimer;
        protected MTimer castingTimer;

        public Spell()
        {
            level = 0;
            isActive = true;
            manaCost = 1;
            cooldownTimer = new MTimer(100);
            castingTimer = new MTimer(0);
        }

        public void Update(GameTime gameTime)
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

