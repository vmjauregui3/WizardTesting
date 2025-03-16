using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class FrostEffect : DurationStatusEffect
    {



        public FrostEffect(Destructible target) : base(target, 5000) 
        { 

        }

        public override void ApplyEffect()
        {
            target.MoveSpeed.AddModifier(0.75f, StatModifierType.PercentMultiply);
            base.ApplyEffect();
        }

        public override void RemoveEffect()
        {
            target.MoveSpeed.RemoveModifier(0.75f, StatModifierType.PercentMultiply);
            base.RemoveEffect();
        }

    }
}
