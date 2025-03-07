using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class BuffSpeed : DurationSpell
    {

        private Stat SpeedMultiplier;

        public BuffSpeed(Creature owner) : base(owner, 100, 1000, 50, 1000)
        {
            SpeedMultiplier = new Stat(2f);
        }

        public BuffSpeed(Creature owner, int level, int exp) : base(owner, 100, 1000, 50, 1000, level, exp)
        {
            SpeedMultiplier = new Stat(2f);
        }

        public override void CastEffect()
        {
            owner.MoveSpeed.AddModifier(SpeedMultiplier.Value, StatModifierType.PercentMultiply);
            base.CastEffect();
        }

        public override void EndEffect()
        {
            owner.MoveSpeed.RemoveModifier(SpeedMultiplier.Value, StatModifierType.PercentMultiply);
            base.EndEffect();
        }

    }
}
