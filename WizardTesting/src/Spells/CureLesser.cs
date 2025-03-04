using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class CureLesser : Spell
    {

        private float healValue = 10f;

        public CureLesser(Creature owner) : base(owner, 100, 1000, 100)
        {

        }

        public CureLesser(Creature owner, int level, int exp) : base(owner, 100, 1000, 100, level, exp)
        {

        }

        public override void StartCasting()
        {
            owner.UpdateHealth(healValue);
            base.StartCasting();
        }
    }
}
