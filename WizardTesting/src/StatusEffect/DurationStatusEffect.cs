using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class DurationStatusEffect : StatusEffect
    {

        protected bool isActive;
        protected MTimer activeTimer;

        public DurationStatusEffect(Destructible target, int duration) : base(target) 
        {
            activeTimer = new MTimer(duration);
        }

        public override void ApplyEffect()
        {
            isActive = true;
        }

        public override void RemoveEffect()
        {
            isActive = false;
            base.RemoveEffect();
        }

        public override void Update(GameTime gameTime)
        {
            if (isActive)
            {
                activeTimer.UpdateTimer(gameTime);
                if (activeTimer.Test())
                {
                    activeTimer.ResetToZero();
                    RemoveEffect();
                }
            }
            base.Update(gameTime);
        }


    }
}
