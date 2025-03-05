using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class HealLesser : Spell
    {

        private Stat healValue;

        public HealLesser(Creature owner) : base(owner, 100, 1000, 1000)
        {
            healValue = new Stat(50f);
        }

        public HealLesser(Creature owner, int level, int exp) : base(owner, 100, 1000, 1000, level, exp)
        {
            healValue = new Stat(50f);
        }

        public override void StartCasting()
        {
            base.StartCasting();
        }

        public override void CastEffect()
        {
            owner.UpdateHealth(-healValue.Value);
        }
    }
}
