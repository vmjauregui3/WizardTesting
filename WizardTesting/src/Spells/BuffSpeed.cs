using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class BuffSpeed : Spell
    {

        private Stat SpeedMultiplier;

        public BuffSpeed(Creature owner) : base(owner, 100, 1000, 100)
        {
            SpeedMultiplier = new Stat(50f);
        }

        public BuffSpeed(Creature owner, int level, int exp) : base(owner, 100, 1000, 100, level, exp)
        {
            SpeedMultiplier = new Stat(50f);
        }

        public override void StartCasting()
        {
            base.StartCasting();
        }

        public override void CastEffect()
        {
            owner.MoveSpeed.AddModifier(2f, StatModifierType.PercentMultiply);
        }

    }
}
