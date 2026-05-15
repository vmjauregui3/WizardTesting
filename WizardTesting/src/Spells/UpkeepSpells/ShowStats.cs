using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class ShowStats : UpkeepSpell
    {
        protected new Wizard owner;
        private UI UI;
        public ShowStats(Wizard owner) : base(owner, 200, 5000, 100, 50)
        {
            UI = owner.User.UI;
        }

        public ShowStats(Wizard owner, int level, int exp) : base(owner, 200, 5000, 100, 50, level, exp)
        {
            UI = owner.User.UI;
        }

        public override void CastEffect()
        {
            UI.ToggleStatBars();
            base.CastEffect();
        }

        public override void EndEffect()
        {
            UI.ToggleStatBars();
            base.EndEffect();
        }
    }
}
