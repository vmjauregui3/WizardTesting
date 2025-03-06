using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public abstract class DurationSpell : Spell
    {
        protected bool isActive;

        protected MTimer activeTimer;

        public DurationSpell(Creature owner, int manaCost, int cooldown, int castTime, int duration) : base(owner, manaCost, cooldown, castTime)
        {
            isActive = false;
            activeTimer = new MTimer(duration);
        }

        public DurationSpell(Creature owner, int manaCost, int cooldown, int castTime, int duration, int level, int exp) : base(owner, manaCost, cooldown, castTime, level, exp)
        {
            isActive = false;
            activeTimer = new MTimer(duration);
        }

        public override void CastEffect()
        {
            isActive = true;
            base.CastEffect();
        }

        public override void EndEffect()
        {
            isActive = false;
            base.EndEffect();
        }

        public override void Update(GameTime gameTime)
        {
            if (isActive)
            {
                activeTimer.UpdateTimer(gameTime);
                if (activeTimer.Test())
                {
                    activeTimer.ResetToZero();
                    EndEffect();
                }
            }
            base.Update(gameTime);
        }

    }
}
