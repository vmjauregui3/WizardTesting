using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class HealLesser : InstantSpell
    {

        private Stat healValue;

        public HealLesser(Creature owner) : base(owner, 100, 1000, 1000)
        {
            healValue = new Stat(50f);
            castEffect = heal;
        }

        public HealLesser(Creature owner, int level, int exp) : base(owner, 100, 1000, 1000, level, exp)
        {
            healValue = new Stat(50f);
            castEffect = heal;
        }

        protected void heal()
        {
            owner.AddHealth(healValue.Value);
        }
    }
}
