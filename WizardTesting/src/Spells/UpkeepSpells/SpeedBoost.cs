using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class SpeedBoost : UpkeepSpell
    {

        private Stat SpeedMultiplier;

        public SpeedBoost(Creature owner) : base(owner, 200, 5000, 100, 50)
        {
            SpeedMultiplier = new Stat(2f);
            castEffect = AddStatBoost;
            endEffect = RemoveStatBoost;
        }

        public SpeedBoost(Creature owner, int level, int exp) : base(owner, 200, 5000, 100, 50, level, exp)
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
