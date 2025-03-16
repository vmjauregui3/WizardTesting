using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class StatusEffect
    {
        protected Destructible target;


        public StatusEffect(Destructible target)
        {
            this.target = target;
            ApplyEffect();
        }


        public virtual void ApplyEffect()
        {

        }


        public virtual void RemoveEffect()
        {

        }

        public virtual void Update(GameTime gameTime)
        {
            
        }
    }
}
