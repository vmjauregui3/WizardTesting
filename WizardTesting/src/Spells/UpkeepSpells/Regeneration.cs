using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class Regeneration : UpkeepSpell
    {

        private Stat healValue;

        public Regeneration(Creature owner) : base(owner, 200, 5000, 1000, 50)
        {
            healValue = new Stat(50);
        }

        public Regeneration(Creature owner, int level, int exp) : base(owner, 200, 5000, 100, 50, level, exp)
        {
            healValue = new Stat(50);
        }

        public override void CastEffect()
        {
            owner.AddHealth(healValue.Value);
            base.CastEffect();
        }

        public override void UpkeepEffect()
        {
            owner.AddHealth(healValue.Value);
            base.UpkeepEffect();
        }

        public override void EndEffect()
        {
            base.EndEffect();
        }

    }
}
