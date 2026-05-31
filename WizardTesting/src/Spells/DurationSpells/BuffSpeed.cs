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
            castEffect = AddStatBoost;
            endEffect = RemoveStatBoost;
        }

        public BuffSpeed(Creature owner, int level, int exp) : base(owner, 100, 1000, 50, 1000, level, exp)
        {
            SpeedMultiplier = new Stat(2f);
            castEffect = AddStatBoost;
            endEffect = RemoveStatBoost;
        }

        protected void AddStatBoost()
        {
            owner.MoveSpeed.AddModifier(SpeedMultiplier.Value, StatModifierType.PercentMultiply);
        }

        protected void RemoveStatBoost()
        {
            owner.MoveSpeed.RemoveModifier(SpeedMultiplier.Value, StatModifierType.PercentMultiply);
        }

    }
}
