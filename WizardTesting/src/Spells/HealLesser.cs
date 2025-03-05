using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class HealLesser : Spell
    {

        private float healValue = 50f;

        public HealLesser(Creature owner) : base(owner, 100, 1000, 100)
        {

        }

        public HealLesser(Creature owner, int level, int exp) : base(owner, 100, 1000, 100, level, exp)
        {

        }

        public override void StartCasting()
        {
            base.StartCasting();
        }

        public override void CastEffect()
        {
            owner.UpdateHealth(-healValue);
        }
    }
}
