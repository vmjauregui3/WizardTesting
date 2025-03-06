using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class SpeedBoost : UpkeepSpell
    {

        private Stat SpeedMultiplier;

        public SpeedBoost(Creature owner) : base(owner, 200, 5000, 100, 100)
        {
            SpeedMultiplier = new Stat(2f);
        }

        public SpeedBoost(Creature owner, int level, int exp) : base(owner, 200, 5000, 100, 100, level, exp)
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
